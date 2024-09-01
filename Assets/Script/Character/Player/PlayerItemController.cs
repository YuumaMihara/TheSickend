using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItemController : MonoBehaviour
{
    [SerializeField]bool EmmaRoomKey = false;
    [SerializeField]bool DadRoomKey = false; 
    [SerializeField]bool StrageRoomKey = false; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setKeyBool(string keyName){
        switch(keyName)
        {
            case "EmmaRoomKey":
                EmmaRoomKey = true;
                Debug.Log("getEmma'sKey");
                break;
            case "DadRoomKey":
                DadRoomKey = true;
                Debug.Log("getDad'sKey");
                break;
            case "StrageOpen":
                StrageRoomKey = true;
                break;
            default:
                Debug.Log("nothing");
                break;
        }
    }

    public bool getKeyBool(string RoomName){

        if(RoomName == "EmmaRoom") return EmmaRoomKey;
        if(RoomName == "DadRoom") return DadRoomKey;
        if(RoomName == "Strage") return StrageRoomKey;
        else return false;
        
    }
}
