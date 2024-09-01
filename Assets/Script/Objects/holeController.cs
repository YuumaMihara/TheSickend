using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class holeController : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject position;
    [SerializeField] GameObject ray;
    [SerializeField] GameObject fade;
    LookUpController sc;
    FadeController fd;
    CharacterController cc;
    // Start is called before the first frame update
    void Start()
    {
        sc = ray.GetComponent<LookUpController>();
        fd = fade.GetComponent<FadeController>();
        cc = player.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(sc.getTarget() == "hole" && Input.GetKeyDown("e")){
            //Time.timeScale = 0f;
            fd.isFadeOut = true;
            Invoke(nameof(transformPlayer), 3.0f);
        }
    }

    void transformPlayer(){
        cc.enabled = false;
        player.transform.position = position.transform.position;
        cc.enabled = true;
        Debug.Log("move");
        fd.isFadeIn = true;
        //Time.timeScale = 1f;
    }
}
