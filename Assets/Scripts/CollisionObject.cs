using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;
using System;
using WiimoteApi;
using System.Diagnostics;

public class CollisionObject : MonoBehaviour
{

    public AudioSource audio;
    public Wiimote wiimote;

    private void OnCollisionEnter(Collision collision)
    {
        UnityEngine.Debug.LogError("Golpe");
        audio.Play();
        StartCoroutine(GenerarVibracion(0.0f));
    }

    IEnumerator GenerarVibracion(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        WiimoteDemo.vibrarWii = true;
        yield return new WaitForSeconds(waitTime + 0.5f);
        WiimoteDemo.vibrarWii = false;

    }
}
