using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class handLightController : MonoBehaviour
{
    public GameObject handLight;
    public GameObject cam;
    Vector3 roteuler;
    PlayerCameraController PCC;

    float y_Rotation;
    float x_Rotation;
    void Start()
    {
        handLight.GetComponent<Light>();
        PCC = cam.GetComponent<PlayerCameraController>();
        roteuler = new Vector3(0,transform.localEulerAngles.y, 0f);
    }

    void Update()
    {
        y_Rotation = Input.GetAxis("Mouse Y");
        x_Rotation = Input.GetAxis("Mouse X");

        /*if (Input.GetKey ("j")) {
            x_Rotation -= Time.deltaTime * 5;
        }else if (Input.GetKeyUp("j")){
            x_Rotation = 0;
        }
        // 右に移動
        if (Input.GetKey ("l")) {
            x_Rotation += Time.deltaTime * 5;
        }else if (Input.GetKeyUp("l")){
            x_Rotation = 0;
        }
        // 前に移動
        if (Input.GetKey ("i")) {
            y_Rotation += Time.deltaTime * 5;
        }else if (Input.GetKeyUp("i")){
            y_Rotation = 0;
        }
        // 後ろに移動
        if (Input.GetKey ("k")) {
            y_Rotation -= Time.deltaTime * 5;
        }else if (Input.GetKeyUp("k")){
            y_Rotation = 0;
        }*/
        
    }

    void FixedUpdate()
    {
        if(!PCC.caught){
            handLight.transform.Rotate(0, x_Rotation,0);

            roteuler = new Vector3(Mathf.Clamp(roteuler.x - y_Rotation, -80, 60), 0, 0f);
            handLight.transform.localEulerAngles = roteuler;
        }
    }

    public void look(Transform target)
    {
        this.transform.LookAt(target);
    }
}
