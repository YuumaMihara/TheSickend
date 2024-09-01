using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vaseButtonController : MonoBehaviour
{
    [SerializeField] GameObject vase;
    VaseFall vaseFall;
    // Start is called before the first frame update
    void Start()
    {
        vaseFall = vase.GetComponent<VaseFall>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickYes(){
        vaseFall.FallAnime(true);
        transform.parent.gameObject.SetActive(false);
        Off();
    }

    public void OnClickNo(){
        transform.parent.gameObject.SetActive(false);
        Off();
    }

    void Off(){
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Time.timeScale = 1f;
    }
}
