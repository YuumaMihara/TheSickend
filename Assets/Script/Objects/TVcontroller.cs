using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TVcontroller : MonoBehaviour
{
    [SerializeField] GameObject UIText;
    [SerializeField] GameObject Light;
    [SerializeField] GameObject noise;
    [SerializeField] GameObject player;
    [SerializeField] GameObject candle;
    [SerializeField] GameObject Mom;
    [SerializeField] GameObject MomWarpPos;
    CharacterController cc;
    UnityEngine.AI.NavMeshAgent navMeshAgent;
    PlayerNavMesh PNM;
    AudioSource audiosource;
    Light playerLight;

    private bool sw = true;

    void Start()
    {
        audiosource = Mom.GetComponent<AudioSource>();
        cc = player.GetComponent<CharacterController>();
        navMeshAgent = Mom.GetComponent<UnityEngine.AI.NavMeshAgent>();
        PNM = Mom.GetComponent<PlayerNavMesh>();
        playerLight = candle.GetComponent<Light>();
    }

    void Update()
    {
        
    }

    void OnTriggerStay(Collider col){
        if(sw){
            if(col.tag == "Player"){
                UIText.SetActive(true);
                if(Input.GetKeyDown("e")){
                    Light.SetActive(false);
                    noise.SetActive(false);
                    UIText.SetActive(false);
                    sw = false;
                    StartCoroutine(SwicthOff());
                }
            }
        }
    }

    void OnTriggerExit(Collider col){
        if(col.tag == "Player"){
            UIText.SetActive(false);
        }
    }

    public IEnumerator SwicthOff(){
        playerLight.enabled = false;

        navMeshAgent.enabled = false;
        Mom.transform.position = MomWarpPos.transform.position;
        navMeshAgent.enabled = true;
        audiosource.Stop();
        PNM.SetState(PlayerNavMesh.MomState.Idle);
        yield return new WaitForSeconds(2.0f);
        audiosource.Play();
        PNM.SetState(PlayerNavMesh.MomState.Chase);
        playerLight.enabled = true;
    }

    public bool GetBool(){
        return !sw;
    }
}
