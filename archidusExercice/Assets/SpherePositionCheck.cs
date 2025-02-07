using UnityEngine;

public class SpherePositionCheck : MonoBehaviour
{
    [SerializeField] private Transform _planeTransform;
    private Renderer _sphereRenderer;

    private void Start()
    {
        _sphereRenderer = GetComponent<Renderer>();
        if (_sphereRenderer == null)
        {
            Debug.LogError("Le Renderer de la sphère est introuvable !");
        }

        if (_planeTransform == null)
        {
            Debug.LogError("La référence au plan est manquante !");
        }
    }

    private void Update()
    {
        if (_planeTransform == null || _sphereRenderer == null) return;
        Vector3 planeNormal = _planeTransform.up;
        Vector3 sphereToPlane = transform.position - _planeTransform.position;

        float dotProduct = Vector3.Dot(planeNormal, sphereToPlane);

        if (dotProduct > 0)
        {
            _sphereRenderer.material.color = Color.green;
        }
        else
        {
            _sphereRenderer.material.color = Color.red;
        }
    }
}
