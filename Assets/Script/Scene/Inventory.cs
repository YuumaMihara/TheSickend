using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public GameObject inventoryUI;
    public Text text;
    private GameObject cam;
    private LookUpController lookUpController;
    private int ItemCnt = 0;
    private bool isOn = false;
    // Start is called before the first frame update
    void Start()
    {
        cam = transform.GetChild(0).gameObject;
        lookUpController = cam.GetComponent<LookUpController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!lookUpController.ON && !isOn && Input.GetKeyDown(KeyCode.Tab)){
            inventoryUI.SetActive(true);
            Time.timeScale = 0f;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            isOn = true;
        }else if(isOn && Input.GetKeyDown(KeyCode.Tab)) closeInventory();
    }

    public void AddItemCnt(){
        ItemCnt++;
        text.text = ItemCnt.ToString();
    }

    public int GetItemCnt(){
        return ItemCnt;
    }

    public void closeInventory(){
        inventoryUI.SetActive(false);
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = false;
        isOn = false;
    }
}
