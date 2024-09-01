using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerNavMesh : MonoBehaviour
{
    [SerializeField]public Transform[] movePosition;
    [SerializeField]private Transform Player;
    [SerializeField]private Transform targetPos;
    [SerializeField]private GameObject bgm;
    private Animator animator;
    public NavMeshAgent navMeshAgent;
    private MomState TempState;
    private SearchCharactor search;
    private ChaseBGM CB;
    private GameObject SearchArea;
    private NavMeshPath path;
    private float elapsedTime = 0f;
    private int LastTime = 6;
    private bool isStart,isArrive;
    private bool OneToilet,BathRoom,DadRoom,MomRoom,EmmaRoom,Strage,Toilet;

    public enum MomState {
        MoveOut ,
        Idle ,
        Walk ,
        Follow ,
        Return ,
        Chase 
    };
    
    void Start(){
        SearchArea = GameObject.Find("SearchArea");
        search = SearchArea.GetComponent<SearchCharactor>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        CB = bgm.GetComponent<ChaseBGM>();
        animator = GetComponent<Animator>();
        SetState(MomState.Idle);

        path = new NavMeshPath();
    }

    void Update(){
        if(TempState != MomState.Idle) animator.SetFloat("Speed", navMeshAgent.velocity.sqrMagnitude);
        else animator.SetFloat("Speed", 0f);

        if(navMeshAgent.pathPending == false){
            if(TempState == MomState.Walk || TempState == MomState.Follow){
                if(CalcuDist() < 0.3){
                    animator.SetFloat("Speed", 0f);
                    isStart = true;
                    SetState(MomState.Idle);
                }
            }
        }else{
            if(TempState == MomState.Chase){
                //localPosition = Vector3.MoveTowards(player.localPosition, tragetPosition, 5.0f);
            }
        }

        if(TempState == MomState.MoveOut){
            elapsedTime += Time.deltaTime;
            if(elapsedTime > 5.0f) SetState(MomState.Walk);
        }

        if(TempState == MomState.Idle && isStart){
            if(CalcuDist() < 0.3f){
                elapsedTime += Time.deltaTime;
                Debug.Log("目的地に着いたので待機中 :" + elapsedTime);
                if(elapsedTime > 5.0f) SetState(MomState.Walk);
            }
        }else if(TempState == MomState.Idle && !isStart 
                && CalcuDist() > 0.1f && !isArrive){
            SetState(MomState.Return);
        }

        if(TempState == MomState.Return && CalcuDist() > 0.1f){
            isArrive = true;
            SetState(MomState.Idle);
            animator.SetFloat("Speed", 0f);
            if(CalcuDist() < 0.3f) LookAtPos();

        }
        if(TempState == MomState.Chase){
            SetState(MomState.Chase);
            NavMesh.CalculatePath(transform.position, Player.transform.position, NavMesh.AllAreas, path);
        }
    }

    public void SetState(MomState state){
        TempState = state;

        if(TempState == MomState.Idle){
            search.isEnter = false;
            elapsedTime = 0f;
            CB.StopBGM();
        }
        if(TempState == MomState.MoveOut){
            search.isEnter = false;
            elapsedTime = 0f;
        }
        if(TempState == MomState.Walk){
            search.isEnter = false;
            elapsedTime = 0f;
            navMeshAgent.speed = 1.5f;
            Rove(ChoicePos());
            CB.StopBGM();
        }
        if(TempState == MomState.Follow){
            isArrive = false;
            elapsedTime = 0f;
            navMeshAgent.speed = 5.0f;
            Rove(movePosition[7]);
            CB.PlayBGM();
        }
        if(TempState == MomState.Return){
            elapsedTime = 0f;
            navMeshAgent.speed = 1.5f;
            Rove(movePosition[0]);
            CB.StopBGM();
        }
        if(TempState == MomState.Chase){
            isArrive = false;
            elapsedTime = 0f;
            navMeshAgent.speed = 5.0f;
            navMeshAgent.SetDestination(Player.position);
            CB.PlayBGM();
        }
    }
    public void Rove(Transform target){
        Debug.Log(target.transform);
        navMeshAgent.SetDestination(target.position);
    }

    public MomState GetState(){
        return TempState; 
    }

    public bool GetIsStart(){
        return isStart;
    }

    public void SetSpeed(float speed){
        navMeshAgent.speed = speed;
    }

    public void LookAtPos(){
        if(!isStart) this.transform.LookAt(targetPos);
    }

    public Transform ChoicePos(){
        int r;
        do{
            r = Random.Range(1, movePosition.Length);
        }while(LastTime == r);

        if(r == 6) SetMomBool("Tiolet",true);
        if(r == 7) SetMomBool("EmmaRoom",true);
        if(r == 8) SetMomBool("DadRoom",true);
        if(r == 9) SetMomBool("MomRoom",true);
        if(r == 10) SetMomBool("Strage",true);

        if(LastTime == 6) SetMomBool("Tiolet",false);
        if(LastTime == 7) SetMomBool("EmmaRoom",false);
        if(LastTime == 8) SetMomBool("DadRoom",false);
        if(LastTime == 9) SetMomBool("MomRoom",false);
        if(LastTime == 10) SetMomBool("Strage",false);

        LastTime = r;
        return movePosition[r];
    }

    public bool GetMomBool(string room){
        if(room == "Toilet") return Toilet;
        if(room == "EmmaRoom") return EmmaRoom;
        if(room == "DadRoom") return DadRoom;
        if(room == "MomRoom") return MomRoom;
        if(room == "Strage") return Strage;
        return false;
    }

    private float CalcuDist(){
        NavMeshPath path = navMeshAgent.path;
        Vector3 corner = transform.position;
        float dist = 0f;
        for (int i = 0; i < path.corners.Length; i++){
            Vector3 corner2 = path.corners[i];
            dist += Vector3.Distance(corner, corner2);
            corner = corner2;
        }

        return dist;
    }

    public void SetMomBool(string room,bool a){
        if(room == "Toilet") Toilet = a;
        if(room == "EmmaRoom") EmmaRoom = a;
        if(room == "DadRoom") DadRoom = a;
        if(room == "MomRoom") MomRoom = a;
        if(room == "Strage") Strage = a;
    }

    
}
