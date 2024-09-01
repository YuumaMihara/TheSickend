using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockDoorController : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject Mom;
    [SerializeField] GameObject Door;
    [SerializeField] AudioClip DoorLockOpen;
    [SerializeField] AudioClip StillLockDoor;
    [SerializeField] AudioClip DoorOpenSound;
    [SerializeField] AudioClip DoorCloseSound;
    private bool isNear,isEnter; //ドアエリアに入っているか
    private float elapsedTime;
    private Animator animator;
    private PlayerItemController playerItem;
    private PlayerNavMesh PNM;
    private AudioSource audioSource;

    void Start() {
        isNear = false;
        animator = Door.GetComponent<Animator>();
        playerItem = player.GetComponent<PlayerItemController>();
        PNM = Mom.GetComponent<PlayerNavMesh>();
        audioSource = GetComponent<AudioSource>();
    }
 
    void Update() {
        if (Input.GetKeyDown("space") && isNear) {
            if(playerItem.getKeyBool(transform.name)){
                DoorControl();
            }else{
                audioSource.PlayOneShot(StillLockDoor);
                Debug.Log(transform.name);
            }
            
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
        if(col.tag == "Mother" && isEnter) {
            elapsedTime = 0f;
            if(!animator.GetBool("Open")){
                return;
            } else{
                DoorControl();
                isEnter = false;
            }
        }
    }
    void OnTriggerStay(Collider col){
        if(col.tag == "Mother" && PNM.GetState() != PlayerNavMesh.MomState.Idle
            && PNM.GetState() != PlayerNavMesh.MomState.Chase){
            elapsedTime += Time.deltaTime;
            Debug.Log(transform.name + "経過中 :" + elapsedTime);
            if(elapsedTime > 6.0f){
                DoorControl();
                elapsedTime = 0f;
                isEnter = true;
            }
        }else if(PNM.GetMomBool(transform.name)){
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
