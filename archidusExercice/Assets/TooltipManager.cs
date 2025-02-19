using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TooltipManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _Text;
    void Start()
    {
        Tooltiper._OnMouseOver += UpdateText;
    }

   public void  UpdateText(string VALUE)
    {
        _Text.text = VALUE;
    }

    public void OnDestroy()
    {
        Tooltiper._OnMouseOver -= UpdateText;
    }
}
