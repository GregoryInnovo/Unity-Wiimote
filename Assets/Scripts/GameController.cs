using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    public static GameController instance;
    public AudioSource audioController;
    public AudioClip audio1, audio2, audio3;
    void Start()
    {
        instance = this;
        audioController.clip = audio1;
        audioController.Play();
    }


    public void Audio2()
    {
        audioController.clip = audio2;
        audioController.Play();
    }

    public void Audio3()
    {
        audioController.clip = audio3;
        audioController.Play();
    }
}
