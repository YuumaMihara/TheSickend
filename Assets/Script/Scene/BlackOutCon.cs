using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BlackOutCon : MonoBehaviour
{
    GameObject fade;
    FadeController fadeCon;
    void Start(){
        fade = GameObject.Find("Fade");
        fadeCon = fade.GetComponent<FadeController>();
    }
    void BlackOut(){       
        fadeCon.BlackOut();
    }
    void ChangeScene(){
        SceneManager.sceneLoaded += SceneLoaded;
        SceneManager.LoadScene("Title");
    }
    void SceneLoaded(Scene scene, LoadSceneMode mode){
        AudioListener.volume = 1f;
        fadeCon.BlackOut();
        fadeCon.isFadeIn = true;
    }
}

