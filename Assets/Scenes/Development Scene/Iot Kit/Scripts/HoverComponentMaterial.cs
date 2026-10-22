using UnityEngine;
using System.Collections;

public class HoverComponentMaterial : MonoBehaviour
{
    [Header("Material")]
    [SerializeField] private Material _material;

    [Header("Alpha Value Settings")]
    [SerializeField, Range(0, 255)] private float _minValue;
    [SerializeField, Range(0, 255)] private float _maxValue;
    [SerializeField] private float _duration; 
    
    private Coroutine _coroutine;

    private void Start()
    {
        StartHover();
    }
    
    public void StartHover()
    {
        if(_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(HoverAlpha()); 
    }

    public void StopHover()
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
            _coroutine = null;
        }
    }

    private IEnumerator HoverAlpha()
    {
        while (true)
        {
            yield return StartCoroutine(ChangeAlpha(_minValue / 255f, _maxValue / 255f)); 
            yield return StartCoroutine(ChangeAlpha(_maxValue/ 255f, _minValue / 255f));
        }
    }

    private IEnumerator ChangeAlpha(float _startAlpha_, float _endAlpha_)
    {
        float elapsed = 0f;
        Color color = _material.color;

        while (elapsed < _duration)
        {
            elapsed += Time.deltaTime;

            float t = Mathf.Clamp01(elapsed / _duration);
            color.a = Mathf.Lerp(_startAlpha_, _endAlpha_, t);

            _material.color = color;

            yield return null;
        }

        color.a = _endAlpha_;
        _material.color = color;
    }
    
}
