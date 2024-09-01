using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrageDoorController : MonoBehaviour
{
    [SerializeField] GameObject Mom;
    [SerializeField] GameObject player;
    [SerializeField] AudioClip DoorOpenSound;
    [SerializeField] AudioClip DoorCloseSound;
    private PlayerItemController PIC;
    private PlayerNavMesh PNM;
    //　ドアエリアに入っているかどうか
    private bool isNear,isFirst = true;
    private float elapsedTime = 0f;
    //　ドアのアニメーター
    private Animator animator;
    private AudioSource audioSource;
    void Start() {
        animator = transform.parent.GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        PIC = player.GetComponent<PlayerItemController>();
        PNM = Mom.GetComponent<PlayerNavMesh>();
    }
 
    void Update() {
        if (Input.GetKeyDown("space") && isNear) {
            if(isFirst){
                PIC.setKeyBool(transform.name);
            }
            DoorControl();
        }
    }
 
    void OnTriggerEnter(Collider col) {
        if (col.tag == "Player") {
            isNear = true;
        }
    }

    void OnTriggerStay(Collider col){
        if(col.tag == "Mother" && PNM.GetState() != PlayerNavMesh.MomState.Idle){
            elapsedTime += Time.deltaTime;
            Debug.Log(transform.name + "経過中 :" + elapsedTime);
            if(elapsedTime > 6.0f){
                DoorControl();
                elapsedTime = 0f;
            }
        }
    }
 
    void OnTriggerExit(Collider col) {
        if (col.tag == "Player") {
            isNear = false;
        }
        if(col.tag == "Mother"){
            if(animator.GetBool("Open")) return;
            else DoorControl();
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
