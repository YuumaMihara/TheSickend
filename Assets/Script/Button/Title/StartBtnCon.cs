using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class StartBtnCon : MonoBehaviour
{
    GameObject Maincam,TitleObj,StartBtn,MenuBtn,StartBurn,MenuBurn;
    VideoPlayer Title,Start,Menu;
    Animator animator;
    void Awake() {
        Maincam = Camera.main.gameObject;
        TitleObj = GameObject.Find("TitleMovie");
        StartBtn = GameObject.Find("Start");
        MenuBtn = GameObject.Find("Menu");
        StartBurn = GameObject.Find("StartBurn");
        MenuBurn = GameObject.Find("MenuBurn");
        Title = TitleObj.GetComponent<VideoPlayer>();
        Start = StartBurn.GetComponent<VideoPlayer>();
        Menu = MenuBurn.GetComponent<VideoPlayer>();
        animator = Maincam.GetComponent<Animator>();
    }

    public void onStartClick(){
        Title.enabled = true;
        StartBtn.SetActive(false);
        MenuBtn.SetActive(false);
        Start.enabled = true;
        Menu.enabled = true;
        animator.SetBool("Start", true);
    }
}
