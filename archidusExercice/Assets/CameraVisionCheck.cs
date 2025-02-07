using UnityEngine;

public class CameraVisionCheck : MonoBehaviour
{
    [SerializeField] private Transform _sphere; 
    [SerializeField] private LayerMask _obstacleLayer; 
    [SerializeField] private float _fieldOfViewAngle = 45f; 

    private Renderer sphereRenderer;

    private void Start()
    {
        if (_sphere != null)
        {
            sphereRenderer = _sphere.GetComponent<Renderer>();
        }
        else
        {
            Debug.LogError("La référence à la sphère est manquante !");
        }
    }

    private void Update()
    {
        if (_sphere == null || sphereRenderer == null) return;

        Vector3 _directionToSphere = (_sphere.position - transform.position).normalized;

        float dotProduct = Vector3.Dot(transform.forward, _directionToSphere);
        float angleToSphere = Mathf.Acos(dotProduct) * Mathf.Rad2Deg;

        if (angleToSphere <= _fieldOfViewAngle / 2f)
        {
           
            if (!Physics.Raycast(transform.position, _directionToSphere, out RaycastHit hit, Mathf.Infinity, _obstacleLayer) ||
                hit.transform == _sphere)
            {
                
                sphereRenderer.material.color = Color.green;
                return;
            }
        }

        sphereRenderer.material.color = Color.red;
    }
}
