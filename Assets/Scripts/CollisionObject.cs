using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionObject : MonoBehaviour
{

    public AudioSource audio;

    private void OnCollisionEnter(Collision collision)
    {
        Debug.LogError("Golpe");
        audio.Play();
    }

}
