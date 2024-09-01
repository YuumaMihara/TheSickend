using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookUpKey : MonoBehaviour
{
    [SerializeField] GameObject KeyCan;
    [SerializeField] GameObject UIText;
    [SerializeField] AudioClip KeySE;
    AudioSource audioSource;
    GameObject player;
    DoorController closeDoor;
    Inventory inventory;
    // Start is called before the first frame update
    void Start(){
        player = GameObject.Find("Player");
        inventory = player.GetComponent<Inventory>();
        audioSource = GetComponent<AudioSource>();
    }

    public void KeyAppear(bool isFirst)
    {
        KeyCan.SetActive(true);
        if(isFirst == false)
        {
            audioSource.PlayOneShot(KeySE);
            inventory.AddItemCnt();
        }
        
    }

    public void KeyClose(){
        KeyCan.SetActive(false);
        this.gameObject.SetActive(false);
    }
}
