using UnityEngine;

public class DoorController : MonoBehaviour
{
    private Animator animator;

    void Update()
    {
        animator = GetComponent<Animator>();
        DoorEventManager.OnDoorUnlocked += UnlockDoor;
        DoorEventManager.OnDoorOpened += ToggleDoor;
       // DoorEventManager.OnDoorclosed += CloseDoor;
    }

    void UnlockDoor()
    {
        Debug.Log("La porte est déverrouillée !");
    }

    void ToggleDoor(bool value)
    {
        // animator.SetTrigger("Open");
        animator.SetBool("Open",value);
    }

   

    private void OnDestroy()
    {
        DoorEventManager.OnDoorUnlocked -= UnlockDoor;
        DoorEventManager.OnDoorOpened -= ToggleDoor;
       // DoorEventManager.OnDoorclosed -= CloseDoor;
    }
}
