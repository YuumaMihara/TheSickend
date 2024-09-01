using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndSE : MonoBehaviour
{
    public AudioClip endSE;
    AudioSource audioSource;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void play(){
        audioSource.PlayOneShot(endSE);
    }
}
