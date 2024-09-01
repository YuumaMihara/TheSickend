using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookFallSE : MonoBehaviour
{
     private AudioSource audioSource;
     public AudioClip[] fallSE;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlaySE01(){
        audioSource.PlayOneShot(fallSE[0]);
    }
    public void PlaySE02(){
        audioSource.PlayOneShot(fallSE[1]);
        this.gameObject.layer = 7;
    }
}
