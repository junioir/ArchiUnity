using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WorkerDelegqte : MonoBehaviour
{

    [SerializeField] private WorkType workType;
    [SerializeField] private Button _Button;

    private delegate void Workfunctiondelegate();
    
    private Workfunctiondelegate _delegate;
    private enum WorkType
    {
        Mining,
        Logging,
        Farming

    }

     void Start()

    {
       _Button.onClick.AddListener(Work);
    }


    private void UpdatWorktype()
         
    {
        _delegate=null;

        switch (workType) { 
        
        case WorkType.Mining:
                _delegate += Mining;
              break;
                case WorkType.Logging:
                _delegate += Loging;
                break;
                case WorkType.Farming:
                _delegate += Farming;
                break;
        
        
        }
        
    }

    private void Farming()

    {
        Debug.Log("workeer is farming");
    }

    private void Loging()

    {
        Debug.Log("workeer is Loging");

    }

    private void Mining()

    {
        Debug.Log("workeer is Mining");
    }


    public void Work()
    {
        UpdatWorktype();
        _delegate?.Invoke();
    }
}
