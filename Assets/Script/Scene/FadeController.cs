using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeController : MonoBehaviour
{
    public static bool isFadeInstance = false;

    float fadeSpeed = 0.03f;
    float red, green, blue, alfa;
    public bool isFadeIn = false;
    public bool isFadeOut = false;

    Image fadeImage;
    // Start is called before the first frame update
    void Start()
    {
        fadeImage = GetComponent<Image>();
		red = fadeImage.color.r;
		green = fadeImage.color.g;
		blue = fadeImage.color.b;
		alfa = fadeImage.color.a;

        StartCoroutine(SceneFade());        
    }

    // Update is called once per frame
    void Update()
    {
        if(isFadeIn){
            StartFadeIn();
        }

        if(isFadeOut){
            StartFadeOut();
        }
    }

    void StartFadeIn(){
        alfa -= fadeSpeed;
        SetAlfa();
        if(alfa <= 0){
            isFadeIn = false;
        }
    }

    void StartFadeOut(){
        fadeImage.enabled = true;
        alfa += fadeSpeed;
        SetAlfa();
        if(alfa >= 1){
            isFadeOut = false;
        }
    }

    void SetAlfa(){
        fadeImage.color = new Color(red, green, blue, alfa);
    }

    public void BlackOut(){
        fadeImage.color = new Color(red, green, blue, 255);
        alfa = 1;
    }

    IEnumerator SceneFade(){
        BlackOut();
        Debug.Log("fadeIn1");
        yield return new WaitForSeconds(0.5f);
        isFadeIn = true;
        Debug.Log(isFadeIn);
    }
}
