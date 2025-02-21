using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Bull : Animal,Iwork,IShowName
{
    
    public void Isworking()
    {
        Debug.Log("Work");
    }

    public  void Show()
    {

        _Text.text = gameObject.name;

    }


}
