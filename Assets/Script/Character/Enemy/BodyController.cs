using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyController : MonoBehaviour
{
    private PlayerNavMesh PNM;
    private GameObject Mom;
    private float ElapsedTime = 0f;
    
    void Start()
    {
        Mom = transform.parent.gameObject;
        PNM = Mom.GetComponent<PlayerNavMesh>();
    }

    void Update()
    {
        
    }

    void OnTriggerStay(Collider col){
        if(col.tag == "Door"){
            ElapsedTime += Time.deltaTime;
            Debug.Log(col.transform.name + "時間経過" + ElapsedTime);
            if(ElapsedTime >= 7.0f){
                PNM.SetMomBool(col.transform.name, true);
                ElapsedTime = 0f;
            }
        }
    }

    void OnTriggerExit(Collider col){
        if(col.tag == "Door"){
            ElapsedTime = 0f;
            if(PNM.GetMomBool(col.transform.name)) PNM.SetMomBool(col.transform.name, false);
        }
    }
}
