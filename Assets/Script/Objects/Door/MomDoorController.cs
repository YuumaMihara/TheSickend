using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MomDoorController : MonoBehaviour
{
    [SerializeField] AudioClip DoorOpenSound;
    [SerializeField] AudioClip DoorCloseSound;
    [SerializeField] GameObject DadRoomKey;
    [SerializeField] GameObject Door;
    [SerializeField] GameObject Mom;

    private float elapsedTime = 0f;
    private bool isNear,isEnter;
    private bool isFirst = true;
    //　ドアのアニメーター
    private Animator animator;
    private AudioSource audioSource;
    private PlayerNavMesh PNM;
    void Start() {
        isNear = false;
        animator = Door.GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        PNM = Mom.GetComponent<PlayerNavMesh>();
    }
 
    void Update() {
        if (Input.GetKeyDown("space") && isNear) {
            DoorControl();
        }
        if(!DadRoomKey.activeSelf && isFirst){
            DoorControl();
            isFirst = false;
        }
    }
 
    void OnTriggerEnter(Collider col) {
        if (col.tag == "Player") {
            isNear = true;
        }
        if(col.tag == "Mother"){
            if(PNM.GetMomBool(transform.name)){
                if(animator.GetBool("Open")) return;
                else DoorControl();
                isEnter = true;
            }
        }
    }
 
    void OnTriggerExit(Collider col) {
        if (col.tag == "Player") {
            isNear = false;
        }
                if(col.tag == "Mother") {
            elapsedTime = 0f;
            if(isEnter){
                if(!animator.GetBool("Open")) return;
                else DoorControl();
                isEnter = false;
            }
        }
    }

    void OnTriggerStay(Collider col){
        if(col.tag == "Mother" && PNM.GetState() != PlayerNavMesh.MomState.Idle
            && PNM.GetState() != PlayerNavMesh.MomState.Chase)
            {
            elapsedTime += Time.deltaTime;
            if(elapsedTime > 6.0)
            {
                DoorControl();
                elapsedTime = 0f;
            }
        }else if(PNM.GetMomBool(transform.name))
        {
            DoorControl();
            PNM.SetMomBool(transform.name, false);
        } 
    }

    public void DoorControl(){
        animator.SetBool("Open", !animator.GetBool("Open"));
        if(animator.GetBool("Open")){
            audioSource.PlayOneShot(DoorOpenSound);
        }else{
            audioSource.PlayOneShot(DoorCloseSound);
        }
    }
}
