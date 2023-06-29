using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControls : MonoBehaviour
{
    //Control X & Z
    private float horizontalMovement;
    private float verticalMovement;

    //i am speed
    public float speed = 5.0f;
    public float DashSpeed = 1000.0f;

    // How much will the player slide on the ground
    // The lower the value, the greater distance the user will slide
    public float drag;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        //gets the Rigid Body so it can be used 
        rb = GetComponent<Rigidbody>();
        //freezes the Rotation when moving the rigid body so it doesnt fall over with gravity 
        rb.freezeRotation = true;

    }

    // Update is called once per frame
    void Update()
    {
        //Foward Backwards detection,movemenrt
        horizontalMovement = Input.GetAxisRaw("Horizontal");

        // Left and Right Movement
        verticalMovement = Input.GetAxisRaw("Vertical");

        // Calculate the direction to move the player
        Vector3 movementDirection = transform.forward * verticalMovement + transform.right * horizontalMovement;

        // Move the player
        rb.AddForce(movementDirection * speed, ForceMode.Force);
        rb.AddForce(movementDirection * speed, ForceMode.Force);
        // Apply drag
        rb.drag = drag;
        if (Input.GetKeyDown(KeyCode.E) == true)
        {
            //Dash Script 
            Debug.Log("dash");
            //if press E they do a rigid impluse force to simulate a dash 
            rb.AddForce(movementDirection.normalized * DashSpeed, ForceMode.Impulse);
            rb.drag = 0;
        }
        //Restart Game 
        if (Input.GetKeyDown(KeyCode.R) == true)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}