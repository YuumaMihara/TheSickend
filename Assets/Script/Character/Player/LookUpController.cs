using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookUpController : MonoBehaviour
{

    [SerializeField] GameObject UIText;
    [SerializeField] GameObject Door;
    PlayerCameraController PCC;
    Camera mainCamera;
    RaycastHit hit;
    GameObject targetObject;
    Vector3 pos;
    
    //Layer7のみをrayCastの対象とするようなマスク
    int centerX,centerY;
    int layerMask = 1 << 7 | 1 << 8;
    int OutCount = 0;
    float elapsedTime;
    public bool ON = false;
    PlayerItemController PIC;
    Animator animator;
    void Start()
    {
        animator = Door.GetComponent<Animator>();
        centerX = Screen.width / 2;
        centerY = Screen.height / 2;
        pos = new Vector3(centerX, centerY, 0.1f);
        PCC = GetComponent<PlayerCameraController>();
        PIC = GetComponent<PlayerItemController>();
        //画面中央を探索の中心とする
        mainCamera = Camera.main;
        UIText.SetActive(false);
    }
    void Update()
    {
        CastRay();
    }

    // 画面中央の位置から「レイ」を飛ばして、何かのコライダーに当たるかどうかをチェック
    void CastRay()
    {
        Ray ray = mainCamera.ScreenPointToRay(pos);
        if (Physics.Raycast(ray.origin, ray.direction,out hit, 3.5f, layerMask))
        {
            //ヒットしたオブジェクトを格納
            targetObject = hit.collider.gameObject;
            if(targetObject.layer == 8){
                UIText.SetActive(false);
                return;
            }
            if(!ON) UIText.SetActive(true);
            OutCount = 1;
            elapsedTime = 0;
            if(Input.GetKeyDown("e"))
            { 
                if(ON == false)
                {
                    if(targetObject.CompareTag("Letter"))                               //タグがletterの時
                    {
                        //ターゲットオブジェクト内のスクリプトを呼び出し(eが押されたときの挙動)
                        targetObject.GetComponent<LookUpText>().LetterAppear(ON);
                    }
                    else if(targetObject.CompareTag("Key"))                             //タグがkeyの時
                    {
                        targetObject.GetComponent<LookUpKey>().KeyAppear(ON);
                        PIC.setKeyBool(targetObject.name);
                    }else if(targetObject.CompareTag("Book"))
                    {
                        targetObject.GetComponent<LookUpBook>().BookOpen();
                    }else if(targetObject.CompareTag("Chest"))
                    {
                        targetObject.GetComponent<chestMove>().Move();
                        return;
                    }else if(targetObject.CompareTag("Vase"))
                    {
                        targetObject.GetComponent<VaseFall>().Fall();
                        return;
                    }else if(targetObject.CompareTag("Peephole") && !animator.GetBool("Open")){
                        UIText.SetActive(false);
                        ON = true;
                        StartCoroutine(targetObject.GetComponent<LookPeephole>().Peep());
                        return;
                    }else if(targetObject.CompareTag("other"))
                    {
                        targetObject.GetComponent<LookUpSimple>().TextAppear();
                    }else{
                        return;
                    }
                    ON = true;
                    Time.timeScale = 0f;
                }else
                {
                    if(targetObject.CompareTag("Letter"))                               
                    {
                        targetObject.GetComponent<LookUpText>().LetterClose();
                    }else if(targetObject.CompareTag("Key"))
                    {
                        targetObject.GetComponent<LookUpKey>().KeyClose();
                    }else if(targetObject.CompareTag("Book"))
                    {
                        targetObject.GetComponent<LookUpBook>().BookClose();
                    }else if(targetObject.CompareTag("other"))
                    {
                        targetObject.GetComponent<LookUpSimple>().TextClose();
                    }
                    ON = false;
                    Time.timeScale = 1f;
                }
            }
        }
        else
        {
            targetObject = null;
            if(OutCount == 1){
                elapsedTime += Time.deltaTime;
                if(elapsedTime > 0.5)
                {
                    UIText.SetActive(false);
                    OutCount = 0;
                    elapsedTime = 0;
                }
            }
        }
    }
  // 対象のオブジェクトを調べる処理

    public string getTarget(){
        if(targetObject == null){
            return "";
        }
        return targetObject.name;
    }
}
