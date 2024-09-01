using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReStart : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject Mom;
    [SerializeField] GameObject MomPos;
    [SerializeField] GameObject fade;
    [SerializeField] GameObject vase;
    CharacterController cc;
    UnityEngine.AI.NavMeshAgent navMeshAgent;
    VaseFall vaseFall;
    PlayerNavMesh PNM;
    PlayerController pc;
    FadeController fd;
    DoorClose DC;
    Transform Startpos;
    GameObject vaseClone;
    GameObject Serach;
    Animator animator;
    void Start()
    {
        Startpos = transform.Find("StartPos").transform;
        Serach = Mom.transform.GetChild(2).gameObject;
        navMeshAgent = Mom.GetComponent<UnityEngine.AI.NavMeshAgent>();
        PNM = Mom.GetComponent<PlayerNavMesh>();
        fd = fade.GetComponent<FadeController>();
        cc = player.GetComponent<CharacterController>();
        pc = player.GetComponent<PlayerController>();
        vaseFall = vase.GetComponent<VaseFall>();
        DC = GetComponent<DoorClose>();
        animator = Mom.GetComponent<Animator>();
    }

    public void reStart(){
        animator.SetBool("Dead", false);
        navMeshAgent.enabled = false;
        player.transform.position = Startpos.transform.position;
        Mom.transform.position = MomPos.transform.position;
        navMeshAgent.enabled = true;
        PNM.LookAtPos();
        cc.enabled = true;
        pc.enabled = true;
        fd.isFadeIn = true;
        Serach.SetActive(true);
        DC.DoorCloser();
        if(!PNM.GetIsStart()){
            vaseClone = GameObject.Find("vaseBroken(Clone)");
            Destroy(vaseClone);
            vaseFall.FallAnime(false);
            vase.SetActive(true);
        }
    }
}
