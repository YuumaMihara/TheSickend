using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookPeephole : MonoBehaviour
{
    public GameObject mainCamera;
    public GameObject peepCamera;
    public GameObject Player;
    public GameObject fade;
    public GameObject Light;
    public GameObject DoorCol;
    public GameObject holeImg;

    private GameObject tv;
    private GameObject moveCon;

    PeepMove pm;
    TVcontroller TVc;
    CharacterController cc;
    PlayerController pc;
    LookUpController LUC;
    AudioSource audioSource;
    FadeController fd;
    private bool peep;
    private bool isFirst = true;
    void Start()
    {
        moveCon = GameObject.Find("MoveCon");
        tv = GameObject.Find("TVsearchArea");
        pm = moveCon.GetComponent<PeepMove>();
        TVc = tv.GetComponent<TVcontroller>();
        cc = Player.GetComponent<CharacterController>();
        pc = Player.GetComponent<PlayerController>();
        LUC = mainCamera.GetComponent<LookUpController>();
        fd = fade.GetComponent<FadeController>();
        peepCamera.SetActive(false);
        holeImg.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("e") && peep){
            StartCoroutine(PeepOut());
        }
    }

    public IEnumerator Peep(){
        DoorCol.SetActive(false);
        cc.enabled = false;
        pc.enabled = false;
        fd.isFadeOut = true;
        yield return new WaitForSeconds(2.0f);
        if(TVc.GetBool() && isFirst) pm.PeepAndMove();
        holeImg.SetActive(true);
        Light.SetActive(false);
        mainCamera.SetActive(false);
        peepCamera.SetActive(true);
        fd.isFadeIn = true;
        peep = true;
        if(TVc.GetBool() && isFirst) {
            pm.soundCon();
            isFirst = false;
        }

        
    }

    private IEnumerator PeepOut(){
        fd.isFadeOut = true;
        yield return new WaitForSeconds(2.0f);
        holeImg.SetActive(false);
        Light.SetActive(true);
        mainCamera.SetActive(true);
        peepCamera.SetActive(false);
        cc.enabled = true;
        pc.enabled = true;
        fd.isFadeIn = true;
        peep = false;
        LUC.ON = false;
        DoorCol.SetActive(true);
    }
}
