using UnityEngine;

public class DoorController : MonoBehaviour
{
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void ToggleDoor()
    {
        if (animator.GetBool("Open"))
        {
            animator.SetBool("Open", false); // Ferme la porte
            Debug.Log("La porte est fermée.");
        }
        else
        {
            animator.SetBool("Open", true); // Ouvre la porte
            Debug.Log("La porte est ouverte.");
        }
    }
}
