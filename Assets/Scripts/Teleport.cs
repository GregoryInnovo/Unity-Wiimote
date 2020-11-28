using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public GameObject mainPlayer;

    public void Start()
    {

        mainPlayer.transform.position = new Vector3(-188.5f, 28f, -345f);

    }

    //Other es el player
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(this.gameObject.name);
        if (other.gameObject.CompareTag("Player") && this.gameObject.name.Equals("RoomTwo"))
        {
            mainPlayer.transform.position = new Vector3(20.59949f, 33.78136f, -264f);
        }
        else if (other.gameObject.CompareTag("Player") && this.gameObject.name.Equals("RoomThree"))
        {
            mainPlayer.transform.position = new Vector3(-4f, 52.1f, 102.5f);
        }

    }

}
