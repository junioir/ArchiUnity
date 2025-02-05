using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    public static bool isDoorUnlocked = false; // Statut de la porte (verrouillée ou déverrouillée)

    public void UnlockDoor()
    {
        isDoorUnlocked = true; // Déverrouille la porte
        Debug.Log("La porte est maintenant déverrouillée.");
    }

    public void OpenDoor(DoorController door)
    {
        if (isDoorUnlocked)
        {
            door.ToggleDoor(); // Ouvre ou ferme la porte
        }
        else
        {
            Debug.Log("La porte est verrouillée !");
        }
    }
}
