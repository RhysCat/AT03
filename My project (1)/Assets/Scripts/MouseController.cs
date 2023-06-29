using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseController : MonoBehaviour
{
    // Start is called before the first frame update
    public float mouseSensitivity = 2.5f;
    public float mouseDrag = 1.5f;

    private Transform character;
    private Vector2 mouseDirection;
    private Vector2 smoothing;
    private Vector2 result;
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    private void Awake()
    {
        character = transform.root;
    }

    // Update is called once per frame
    void Update()
    {
        //direction structured by vector with mouse x and y
        //smoothing to giuve camera rotation 
        mouseDirection = new Vector2(Input.GetAxisRaw("Mouse X") * mouseSensitivity, Input.GetAxisRaw("Mouse Y") * mouseSensitivity);
        smoothing = Vector2.Lerp(smoothing, mouseDirection, 1 / mouseDrag);
        result += smoothing;

        //clamping camera 
        result.y = Mathf.Clamp(result.y, -60, 70);


        //angles apllied to the rotation
        transform.localRotation = Quaternion.AngleAxis(-result.y, Vector3.right);
        character.rotation = Quaternion.AngleAxis(result.x, character.up);
        
    }
}
