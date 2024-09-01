using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeepMove : MonoBehaviour
{
    [SerializeField] GameObject Mom;
    [SerializeField] Transform LookPos;
    [SerializeField] AudioClip wowSound;
    UnityEngine.AI.NavMeshAgent NMA;
    PlayerNavMesh PNM;
    AudioSource audioSource;
    AudioSource SE;
    GameObject point;
    // Start is called before the first frame update
    void Start()
    {
        NMA = Mom.GetComponent<UnityEngine.AI.NavMeshAgent>();
        PNM = Mom.GetComponent<PlayerNavMesh>();
        audioSource = Mom.GetComponent<AudioSource>();
        SE = this.GetComponent<AudioSource>();
        point = transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PeepAndMove(){
        NMA.enabled = false;
        Mom.transform.position = point.transform.position;
        NMA.enabled = true;
        audioSource.Stop();
        PNM.SetState(PlayerNavMesh.MomState.MoveOut);
        Mom.transform.LookAt(LookPos);
    }

    public void soundCon(){
        Debug.Log("peepMove:41");
        SE.PlayOneShot(wowSound);
        audioSource.Play();
    }
}
