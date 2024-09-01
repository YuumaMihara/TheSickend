using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kitchenDoorC : MonoBehaviour
{
    public AudioClip openSE;
    public GameObject cam;
    public GameObject book;
    private LookUpController lookUpController;
    private Animator animator;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        lookUpController = cam.GetComponent<LookUpController>();
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(lookUpController.getTarget() == this.transform.name 
            && !animator.GetBool("open")){
                if(Input.GetKeyDown("e")) StartCoroutine(Open());
        }
        
    }

    private IEnumerator Open(){
        animator.SetBool("open",true);
        audioSource.PlayOneShot(openSE);
        this.gameObject.layer = 1;
        yield return new WaitForSeconds(2.0f);
        book.gameObject.layer = 7;
    }
}
