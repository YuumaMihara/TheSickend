using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchCharactor : MonoBehaviour
{
    [SerializeField] private LayerMask obstacle;
    private PlayerNavMesh pnm;
    public bool isEnter = false;
    void Start()
    {
        pnm = GetComponentInParent<PlayerNavMesh>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay(Collider col)
    {
        if(col.tag == "Player")
        {
            //momの状態を確認
            PlayerNavMesh.MomState state = pnm.GetState();
            if(!Physics.Linecast(transform.position + Vector3.up, col.transform.position
                + Vector3.up, obstacle))
                {
                    isEnter = true;
                    pnm.SetState(PlayerNavMesh.MomState.Chase);
                }
        }
    }

    void OnTriggerExit(Collider col)
    {
        if(col.tag == "Player" && isEnter)
        {
            isEnter = false;
            pnm.SetState(PlayerNavMesh.MomState.Idle);
            Debug.Log("範囲外に出た");
        }
    }
}
