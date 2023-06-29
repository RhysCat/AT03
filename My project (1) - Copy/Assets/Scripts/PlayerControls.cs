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
    // Thawde lower the value, the greater distance the user will slide
    public float drag;

    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
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
        // Apply drag
        rb.drag = drag;
        if (Input.GetKeyDown(KeyCode.E) == true)
        {
            Debug.Log("dash");
            rb.AddForce(movementDirection.normalized * DashSpeed, ForceMode.Impulse);
            rb.drag = 0;
        }
        if (Input.GetKeyDown(KeyCode.Escape) == true)
            {
                Debug.Log("Quit");
                Application.Quit();
            }
        if (Input.GetKeyDown(KeyCode.R) == true)
        {
            Debug.Log("Restart");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}