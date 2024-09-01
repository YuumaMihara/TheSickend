using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chestMove : MonoBehaviour
{
    [SerializeField] GameObject drag;
    [SerializeField] GameObject hole;
    [SerializeField] Animator animator;
    private LookUpSimple sc;
    private bool isFirst = true;
    void Start()
    {
        sc = drag.GetComponent<LookUpSimple>();

    }

    // Update is called once per frame
    void Update()
    {
        if(sc.GetBool() == false && isFirst){
            this.gameObject.layer = 7;
        }
    }

    public void Move(){
        animator.SetBool("move",true);
        isFirst = false;
        this.gameObject.layer = 1;
        Invoke(nameof(setLayer), 3.0f);
    }

    void setLayer(){
        hole.gameObject.layer = 7;
    }
}
