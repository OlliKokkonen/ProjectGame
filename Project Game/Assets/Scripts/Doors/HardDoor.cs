using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HardDoor : MonoBehaviour
{
    public bool hardRoom = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            if (hardRoom == true)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Collision on Green Door");
            hardRoom = true;
        }
    }
}
