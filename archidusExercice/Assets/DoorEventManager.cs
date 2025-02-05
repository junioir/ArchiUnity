using UnityEngine;
using UnityEngine.UI;
using System;

public class DoorEventManager : MonoBehaviour
{
    public Button keyButton;
    public Button openButton;
    public static event Action OnDoorUnlocked;
    public static event Action<bool> OnDoorOpened;
    // public static event Action OnDoorclosed;

    private bool isUnlocked = false;
    private bool isOpen = false;

    void Start()
    {
        keyButton.onClick.AddListener(UnlockDoor);
        openButton.onClick.AddListener(OpenDoor);


        openButton.interactable = false;
    }

    void UnlockDoor()
    {
        isUnlocked = true;
        keyButton.interactable = false;
        openButton.interactable = true;
        OnDoorUnlocked?.Invoke();
    }

    void OpenDoor()
    {
        if (isUnlocked)

        {
            if (isOpen)

            {
                OnDoorOpened?.Invoke(true);
                isOpen = false;
            }
            else
            {
                isOpen = true;
                OnDoorOpened?.Invoke(false);
            }

        }




    }

}
