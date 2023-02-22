using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EasyDoor : MonoBehaviour
{
    public bool easyRoom = false;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (easyRoom == true)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Collision on Green Door");
            easyRoom = true;
        }
    }
}
