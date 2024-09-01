using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleSE : MonoBehaviour
{
    public AudioClip BurnSE,WindSE;
    AudioSource audioSource;
    GameObject fade;
    FadeController fadeController;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        fade = GameObject.Find("fade");
        fadeController = fade.GetComponent<FadeController>();
    }

    void burnPlay(){
        audioSource.PlayOneShot(BurnSE);
    }
    void windPlay(){
        audioSource.PlayOneShot(WindSE);
    }
    void goToBackOut(){
        fadeController.BlackOut();
        AudioListener.volume = 0f;
    }
    void ChangeScene(){
        SceneManager.sceneLoaded += SceneLoaded;
        SceneManager.LoadScene("Main");
    }
    void SceneLoaded(Scene scene, LoadSceneMode mode){
        AudioListener.volume = 1f;
        fadeController.BlackOut();
        fadeController.isFadeIn = true;
    }
}
