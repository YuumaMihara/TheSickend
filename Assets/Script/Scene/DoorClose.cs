using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorClose : MonoBehaviour
{
    [SerializeField]GameObject[] Door;
    Animator animator;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DoorCloser(){
        for(int i = 0;i < Door.Length;i++){
            animator = Door[i].GetComponent<Animator>();
            if(animator.GetBool("Open")) animator.SetBool("Open", false);
        }
    }
}
