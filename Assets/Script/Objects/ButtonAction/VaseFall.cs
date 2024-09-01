using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VaseFall : MonoBehaviour
{
    Animator animator;
    [SerializeField] GameObject vaseBroken;
    [SerializeField] Transform parent;
    [SerializeField] GameObject button;
    [SerializeField] GameObject mom;
    private PlayerNavMesh pnm;

    // Start is called before the first frame update
    void Start()
    {
        button.SetActive(false);
        pnm = mom.GetComponent<PlayerNavMesh>();
        animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void Fall(){
        button.SetActive(true);
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void Appear(){
        gameObject.SetActive(false);
        GameObject cloneVase = Instantiate(vaseBroken, parent);
        cloneVase.gameObject.SetActive(true);
        pnm.SetState(PlayerNavMesh.MomState.Follow);
    }

    public void FallAnime(bool isLet){
        animator.SetBool("let'sFall",isLet);
    }

}
