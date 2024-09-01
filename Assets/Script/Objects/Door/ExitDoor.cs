using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitDoor : MonoBehaviour
{
    [SerializeField] GameObject Mom;
    [SerializeField] GameObject SearchArea;
    [SerializeField] GameObject BodyCol;
    [SerializeField] GameObject mainCamera;
    [SerializeField] GameObject EndCamera;
    [SerializeField] GameObject EndCameraCandle;
    [SerializeField] GameObject fadeCon;
    GameObject candle;
    GameObject LookPos;
    GameObject player;
    GameObject parent;
    GameObject MomPosition;
    Inventory inventory;
    TxtFade tf;
    Animator DoorAnimator;
    Animator MomAnimator;
    Animator cameraAnime;
    Animator candleAnime;
    UnityEngine.AI.NavMeshAgent navMeshAgent;
    PlayerNavMesh PNM;
    FadeController fc;
    private bool isNear = false;
    // Start is called before the first frame update
    void Start()
    {
        parent = transform.parent.gameObject;
        cameraAnime = EndCamera.GetComponent<Animator>();
        DoorAnimator = parent.GetComponent<Animator>();
        MomAnimator = Mom.GetComponent<Animator>();
        candleAnime = EndCameraCandle.GetComponent<Animator>();

        MomPosition = GameObject.Find("MomPosition");
        LookPos = GameObject.Find("EndLookPos");
        player = GameObject.Find("Player");
        candle = GameObject.Find("candle");

        fc = fadeCon.GetComponent<FadeController>();
        inventory = player.GetComponent<Inventory>();
        tf = this.GetComponent<TxtFade>();
        navMeshAgent = Mom.GetComponent<UnityEngine.AI.NavMeshAgent>();
        PNM = Mom.GetComponent<PlayerNavMesh>();

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("space") && isNear) StartCoroutine(DoorControl());
    }

    void OnTriggerEnter(Collider col){
        if(col.tag == "Player") isNear = true;
    }

    void OnTriggerExit(Collider col){
        if(col.tag == "Player") isNear = false;
    }

    IEnumerator DoorControl(){
        if(inventory.GetItemCnt() < 14 && tf.GetFadeEnd()){
            Debug.Log("まだ");
            tf.SetBool();
        }else if(inventory.GetItemCnt() < 20){
            mainCamera.SetActive(false);
            candle.SetActive(false);
            EndCameraCandle.SetActive(true);
            EndCamera.SetActive(true);

            DoorAnimator.SetBool("Open", true);
            candleAnime.SetBool("Start", true);
            cameraAnime.SetBool("Start", true);
            yield return new WaitForSeconds(3.0f);
            navMeshAgent.enabled = false;
            SearchArea.SetActive(false);
            BodyCol.SetActive(false);
            Mom.transform.position = MomPosition.transform.position;
            navMeshAgent.enabled = true;
            Mom.transform.LookAt(LookPos.transform.position);
            yield return play();
        }

    }

    IEnumerator play(){
        yield return new WaitForSeconds(2.0f);
        MomAnimator.Play("LastCaught");
    }

}
