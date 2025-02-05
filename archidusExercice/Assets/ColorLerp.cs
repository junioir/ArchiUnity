using UnityEngine;

public class ColorLerp : MonoBehaviour
{
    [SerializeField] Color _startColor = Color.black;
    [SerializeField] Color _endColor = Color.red;
    [SerializeField] float _duration = 5f;
    private Material _sphereMaterial;
    private float _lerpTime = 0f;

    void Start()
    {
        _sphereMaterial = GetComponent<Renderer>().material;
        _sphereMaterial.color = _startColor; 
    }

    void Update()
    {
        if (_lerpTime < _duration)
        {
            _lerpTime += Time.deltaTime; 
            float time = _lerpTime / _duration; 
            _sphereMaterial.color = Color.Lerp(_startColor, _endColor, time); 
        }
    }
}
