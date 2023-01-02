using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public GameObject _door;
    public bool isOpen = false;
    

    private void Start()
    {

    }

    public void OnCollisionEnter(Collision collision)
    {
        if (isOpen)
        {
            _door.transform.position = new Vector3(0, 0, -90);
        }

        else
        {
            _door.transform.position = new Vector3(0, 0, 0);
        }
    }
}

