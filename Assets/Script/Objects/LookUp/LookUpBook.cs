using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookUpBook : MonoBehaviour
{
    [SerializeField] GameObject BookCan;
    [SerializeField] AudioClip BookSE;
    AudioSource audioSource;
    Inventory inventory;
    GameObject player;
    public bool IsFirst;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        inventory = player.GetComponent<Inventory>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    public void BookOpen(){
        if(!IsFirst) inventory.AddItemCnt();
        BookCan.SetActive(true);
        audioSource.PlayOneShot(BookSE);
    }

    public void BookClose(){
        BookCan.SetActive(false);
        IsFirst = true;
    }
}
