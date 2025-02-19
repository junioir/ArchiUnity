using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Tooltiper : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler
{
    [SerializeField] private string _tooltipString;
    public static Action<string> _OnMouseOver;
   // public static Action<GameObject> _OnMouseOver2;

    public void OnPointerEnter(PointerEventData eventData)
    {
        _OnMouseOver?.Invoke(_tooltipString);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _OnMouseOver?.Invoke("");
    }

    private void OnMouseEnter()
    {
         _OnMouseOver?.Invoke(_tooltipString);
    }

    private void OnMouseExit()
    {
        _OnMouseOver?.Invoke("");
    }

}

