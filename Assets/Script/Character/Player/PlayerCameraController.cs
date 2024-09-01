using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraController : MonoBehaviour
{
    [SerializeField] private Transform Mom;
    [SerializeField] GameObject fade;
    [SerializeField] GameObject Restart;    
    [SerializeField] GameObject Light;
    [SerializeField] GameObject BGM;
    
    public Transform Player;
    Transform cam;
    Vector3 roteuler;
    CharacterController cc;
    PlayerController pc;
    handLightController hlc;
    FadeController fd;
    ReStart rs;
    GameObject parentObj;
    
    float y_Rotation;
    float x_Rotation;
    public bool caught = true;
    void Start()
    {
        parentObj = transform.parent.gameObject;

        cam = GetComponent<Transform>();
        cc = parentObj.GetComponent<CharacterController>();
        hlc = Light.GetComponent<handLightController>();
        pc = parentObj.GetComponent<PlayerController>();
        fd = fade.GetComponent<FadeController>();
        rs = Restart.GetComponent<ReStart>();

        Player = transform.parent;

        roteuler = new Vector3(0,transform.localEulerAngles.y, 0f);
    }

    void Update()
    {
        y_Rotation = Input.GetAxis("Mouse Y");
        x_Rotation = Input.GetAxis("Mouse X");
    }

    void FixedUpdate(){
        if(!caught){
            roteuler = new Vector3(Mathf.Clamp(roteuler.x - y_Rotation, -80, 60), 0, 0f);

            Player.transform.Rotate(0, x_Rotation, 0);
            cam.transform.localEulerAngles = roteuler;
        }

    }

    public IEnumerator Caught(){
            cc.enabled = false;
            pc.enabled = false;
            caught = true;
            this.transform.LookAt(Mom);
            hlc.look(Mom);
            yield return new WaitForSeconds(1.0f);
            fd.isFadeOut = true;
            yield return new WaitForSeconds(4.0f);
            caught = false;
            rs.reStart();

    }

}
