using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KeyCountManager : MonoBehaviour
{
    public UIKey key1;
    public UIKey key2;
    public UIKey key3;
    public UIKey key4;

    public int CountKeys;

    public GameObject finalDoor;
    bool DoorOpened;

    ItemKey _itemKey;
    UIKey _uiKey;

    // Start is called before the first frame update
    void Start()
    {
        DoorOpened = false;
        _itemKey = GetComponent<ItemKey>();
        _uiKey = GetComponent<UIKey>();
        OpenDoorByKeys();
        CountKeys++;
    }

    // Update is called once per frame
    void Update()
    {
        if (!DoorOpened)
        {
            OpenDoorByKeys();
        }
    }

    void OpenDoorByKeys()
    {
        bool gotKey1 = false;
        bool gotKey2 = false;
        bool gotKey3 = false;
        bool gotKey4 = false;

        if (key1)
        {
            if (key1.isCollected == true)
            {
                gotKey1 = true;
            }
        }

        if (key2)
        {
            if (key2.isCollected == true)
            {
                gotKey2 = true;
            }
        }

        if (key3)
        {
            if (key3.isCollected == true)
            {
                gotKey3 = true;
            }
        }

        if (key4)
        {
            if (key4.isCollected == true)
            {
                gotKey4 = true;
            }
        }

        if (gotKey1 && gotKey2 && gotKey3 && gotKey4)
        {
            finalDoor.transform.Rotate(0, 0, -90);
            DoorOpened = true;

            SceneManager.LoadScene("WinningEnding");
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (CountKeys >= 4)
        {
            //finalDoor.transform.Rotate(0, 0, -90);
            SceneManager.LoadScene("Winning Ending");
        }
    }
}