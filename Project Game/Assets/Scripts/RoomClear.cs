using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomClear : MonoBehaviour
{
    public GameObject EasierDoor;
    public GameObject HarderDoor;
    public bool NoDoors = false;

    // Update is called once per frame
    void Update()
    {
        //print(GameObject.FindGameObjectsWithTag("Enemy").Length);

        if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
        {
            Doors();
        }
    }

    void Doors()
    {
        while(NoDoors == false)
        {
            Instantiate(EasierDoor, new Vector3(-2.0f, 4f, 0), Quaternion.identity);
            Instantiate(HarderDoor, new Vector3(2.0f, 4f, 0), Quaternion.identity);

            Debug.Log("Room Cleared!");

            NoDoors = true;
        }
    }
}
