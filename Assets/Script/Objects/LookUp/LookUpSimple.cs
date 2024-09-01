using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookUpSimple : MonoBehaviour
{
    [SerializeField] GameObject SimpleCan;
    private bool isFirst = true;
    // Start is called before the first frame update
    public void TextAppear()
    {
        SimpleCan.SetActive(true);
    }

    public void TextClose(){
        SimpleCan.SetActive(false);
        isFirst = false;
    }

    public bool GetBool(){
        return isFirst;
    }
}
