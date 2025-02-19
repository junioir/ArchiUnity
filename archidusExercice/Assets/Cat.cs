using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Cat : Animal,IShowName
{
    
    public void Show()
    {
        _Text.text = gameObject.name;
    }
}
