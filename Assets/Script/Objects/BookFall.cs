using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookFall : MonoBehaviour
{

    [SerializeField]Animator animator;
    private LookUpSimple sc;
    private bool isFirst = true;
    // Start is called before the first frame update
    void Start()
    {
        sc = gameObject.GetComponent<LookUpSimple>();
    }

    // Update is called once per frame
    void Update()
    {
        if(sc.GetBool() == false && isFirst){
            animator.SetBool("Fall",true);
        }
    }
}
