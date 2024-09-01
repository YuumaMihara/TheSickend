using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockSE : MonoBehaviour
{
    public AudioClip SE;
    public GameObject book;
    private AudioSource audioSource;
    private LookUpBook lub;
    private bool isPlay;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        lub = book.GetComponent<LookUpBook>();
    }

    // Update is called once per frame
    void Update()
    {
        if(lub.IsFirst && !isPlay){
            audioSource.PlayOneShot(SE);
            isPlay = true;
        }
    }

}
