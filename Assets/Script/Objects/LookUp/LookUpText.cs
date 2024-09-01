using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class LookUpText : MonoBehaviour
{
    [SerializeField] GameObject LetterCan;
    [SerializeField] AudioClip letterSE;
    GameObject player;
    Inventory inventory;
    AudioSource audioSource;

    private bool isCnt;
    // Start is called before the first frame update
    void Start(){
        audioSource = GetComponent<AudioSource>();
        player = GameObject.Find("Player");
        inventory = player.GetComponent<Inventory>();
    }

    public void LetterAppear(bool isFirst)
    {
        LetterCan.SetActive(true);
        if(isFirst == false)
        {
            audioSource.PlayOneShot(letterSE);
        }
        if(!isCnt){
            isCnt = true;
            inventory.AddItemCnt();
        }
        
    }

    public void LetterClose(){
        LetterCan.SetActive(false);
    }
}
