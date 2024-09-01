using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TxtFade : MonoBehaviour
{
    public GameObject TxtPanel;
    private Text alphaImg;
    private float alpha;
    private bool isFadeIn;
    private bool isFadeOut;
    private bool isFadeEnd = true;
    // Start is called before the first frame update
    void Start()
    {
        alphaImg = TxtPanel.GetComponent<Text>();
        alpha = alphaImg.color.a;
    }

    // Update is called once per frame
    void Update()
    {
        if(isFadeIn) FadeIn();
        if(isFadeOut) FadeOut();
    }

    void FadeIn(){
        isFadeEnd = false;
        alpha += Time.deltaTime * 2;
        alphaImg.color = new Color(255,255,255,alpha);
        if(alpha >= 1){
            isFadeIn = false;
            StartCoroutine(coroutine());
        }
    }

    void FadeOut(){
        alpha -= Time.deltaTime * 2;
        alphaImg.color = new Color(255,255,255,alpha);
        if(alpha <= 0){
            isFadeOut = false;
            isFadeEnd = true;
        }
    }

    IEnumerator coroutine(){
        yield return new WaitForSeconds(1.0f);
        isFadeOut = true;
    }
    public void SetBool(){
        isFadeIn = !isFadeIn;
    }
    public bool GetFadeEnd(){
        return isFadeEnd;
    }
}
