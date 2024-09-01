using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyController4Player : MonoBehaviour
{
    [SerializeField]private GameObject PlayerCam;
    [SerializeField]private GameObject bgm;
    private PlayerCameraController PCC;
    private PlayerNavMesh PNM;
    private ChaseBGM CB;
    private GameObject Mom;
    private GameObject Search;
    private Animator animator; 
    // Start is called before the first frame update
    void Start()
    {
        Mom = transform.parent.gameObject;
        animator = Mom.GetComponent<Animator>();
        PNM = Mom.GetComponent<PlayerNavMesh>();
        CB = bgm.GetComponent<ChaseBGM>();
        PCC = PlayerCam.GetComponent<PlayerCameraController>();
        Search = Mom.transform.GetChild(2).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider col){
        if(col.tag == "Player"){
            PNM.navMeshAgent.isStopped = true;
            animator.SetBool("Dead", true);
            Search.SetActive(false);
            CB.DeadBGM();
            StartCoroutine(PCC.Caught());
            PNM.SetState(PlayerNavMesh.MomState.Idle);
        }
    }
}
