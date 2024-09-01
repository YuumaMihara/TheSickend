using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseBGM : MonoBehaviour
{
    public AudioClip gameOver;
    private AudioSource audioSource;
    private bool isFadeIn,isFadeOut,isFadeOutDead;
    private float FadeInTime = 2.5f,FadeDeltaTime = 0f,FadeOutTime = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isFadeIn){
            FadeDeltaTime += Time.deltaTime;
            if(isFadeOut) isFadeIn = false;
            if(FadeDeltaTime >= FadeInTime){
                FadeDeltaTime = FadeInTime;
                isFadeIn = false;
            }
            audioSource.volume = (float)(FadeDeltaTime / FadeInTime);
        }

        if(isFadeOut){
            FadeDeltaTime += Time.deltaTime;
            Debug.Log("経過時間 : " + FadeDeltaTime);
            if(FadeDeltaTime >= FadeOutTime){
                FadeDeltaTime = FadeOutTime;
                isFadeOut = false;
                audioSource.Stop();
                FadeDeltaTime = 0f;
            }
            audioSource.volume = (float)(1.0 - FadeDeltaTime / FadeOutTime);
        }
    }

    public void PlayBGM(){
        if(!audioSource.isPlaying){
            FadeDeltaTime = 0f;
            audioSource.Play();
            isFadeIn = true;
        }
    }

    public void StopBGM(){
        if(audioSource.isPlaying){
            isFadeOut = true;
        }
    }

    public void DeadBGM(){
        audioSource.Stop();
        audioSource.PlayOneShot(gameOver);
    }
}
