using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    public static bool isDoorUnlocked = false; // Statut de la porte (verrouill�e ou d�verrouill�e)

    public void UnlockDoor()
    {
        isDoorUnlocked = true; // D�verrouille la porte
        Debug.Log("La porte est maintenant d�verrouill�e.");
    }

    public void OpenDoor(DoorController door)
    {
        if (isDoorUnlocked)
        {
            door.ToggleDoor(); // Ouvre ou ferme la porte
        }
        else
        {
            Debug.Log("La porte est verrouill�e !");
        }
    }
}
