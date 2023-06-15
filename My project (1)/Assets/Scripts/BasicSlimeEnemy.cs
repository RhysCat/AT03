using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicSlimeEnemy : MonoBehaviour
{
    [Header("Setup")]
    [SerializeField] private SphereCollider triggerSphere;
    [SerializeField] private bool MoveRigidBody = true;
    [SerializeField] private float RgbRotationSpeed = 5f;
    [SerializeField] private float TriggerRadius = 5f;
    [SerializeField] private float ChaseSpeed = 3f;
    [SerializeField] private float ChaseDelay = 1f;
    [SerializeField] private float Jump = 1f;

    #region private
    private bool jumpCooldown = true;
    private Transform localTrans;
    private bool detected = false;
    private Transform TargetTrans;
    private Vector3 targetPos;
    private Rigidbody localRgb;
    #endregion


    // Start is called before the first frame update
    void Start()
    {
        localRgb = GetComponent<Rigidbody>();
        localTrans = GetComponent<Transform>();

        if (!triggerSphere) triggerSphere = GetComponent<SphereCollider>();
        if (triggerSphere)
            triggerSphere.radius = TriggerRadius;

        TargetTrans = null;
    }

    // Update is called once per frame
    void Update()
    {
        if (jumpCooldown)
        {
            Debug.Log("Jump");
            localRgb.AddForce(Vector2.up * Jump, ForceMode.Impulse);
            StartCoroutine(StartCooldown());
        } 
        if (detected && TargetTrans != null)
        {
            localRgb.freezeRotation = true;

            Chase(TargetTrans);
        }
       
        
    }


    void Chase(Transform _target)
    {
        var speed = ChaseSpeed;

        targetPos = _target.position;
        targetPos.y = localTrans.position.y;

        //Move Rigibody;
        if (MoveRigidBody)
        {
            RotateRgb(_target);
            localRgb.MovePosition(localRgb.position + localTrans.forward * speed * Time.deltaTime);
            localRgb.MovePosition(localRgb.position + localTrans.forward * speed * Time.deltaTime);

        }
    }
    public IEnumerator StartCooldown()
    {
        jumpCooldown = false;

        yield return new WaitForSeconds(2);

        jumpCooldown = true;
    }

    private void RotateRgb(Transform _target)
    {
        Vector3 localTarget = localTrans.InverseTransformPoint(_target.position);

        float angle = Mathf.Atan2(localTarget.x, localTarget.z) * Mathf.Rad2Deg;

        Vector3 eulerAngleVelocity = new Vector3(0, angle, 0);
        Quaternion deltaRotation = Quaternion.Euler(eulerAngleVelocity * Time.deltaTime * RgbRotationSpeed);
        localRgb.MoveRotation(localRgb.rotation * deltaRotation);

    }
   

    private void OnTriggerEnter(Collider other)
    {
        if (detected) return;

        //Follow only if the Detected one is the Player..
        if (other.CompareTag("Player"))
        {
            Debug.Log("Detected: " + other.name);
            detected = true;
            StartCoroutine(ActivateChasing(other.transform, ChaseDelay));
        }
    }

    IEnumerator ActivateChasing(Transform other, float _waitSec = 1f)
    {
        yield return new WaitForSeconds(_waitSec);
        TargetTrans = other;
    }


    public void StopChasing()
    {
        detected = false;
    }

}

