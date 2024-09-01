using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestMoveSE : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip[] moveSE;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SE01(){
        audioSource.PlayOneShot(moveSE[0]);
    }

    public void SE02(){
        audioSource.PlayOneShot(moveSE[1]);
    }
}
