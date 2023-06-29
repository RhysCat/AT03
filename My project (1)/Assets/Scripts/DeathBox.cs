using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathBox : MonoBehaviour
{

    public GameObject WinScreen;
    public GameObject Menu;
    public float Score = 0f;

    void Start()
    {
        WinScreen.SetActive(false);
    }
    void Update()
    {
        //score for win condition 
        if (Score == 2f)
            {
            Menu.SetActive(false);
            WinScreen.SetActive(true);
            }
    }
    //Deathbox if collide
    private void OnCollisionEnter(Collision collision)
    {
      
        Rigidbody rb = collision.collider.GetComponent<Rigidbody>();
        if (rb != null && collision.gameObject.tag == "Player")
        {
         SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        if (rb != null && collision.gameObject.tag == "Enemy")
        {
            Score = Score + 1f;
            Destroy(collision.gameObject);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        
    }
}