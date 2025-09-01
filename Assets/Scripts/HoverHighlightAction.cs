using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverHighlightAction : MonoBehaviour
{
    private Renderer _renderer;
    private Material _materialInstance;
    private Color originalColor;
    private Color originalEmissionColor;
    public Color highlightColor = Color.yellow;
    public Color highlightEmissionColor = Color.yellow;

    void Start()
    {
        _renderer = GetComponent<Renderer>();
        if(_renderer != null)
        {
            _materialInstance = _renderer.material;
            
            originalColor = _materialInstance.color;
        }

        if (_materialInstance.HasProperty("_EmissionColor"))
        {
            originalEmissionColor = _materialInstance.GetColor("_EmissionColor");
            _materialInstance.EnableKeyword("_EMISSION");
        }
    }

    public void OnHoverEnter()
    {
        if (_materialInstance == null) return;

        _materialInstance.color = highlightColor;

        if (_materialInstance.HasProperty("_EmissionColor"))
        {
            _materialInstance.SetColor("_EmissionColor", highlightEmissionColor * 20f);
        }


    }

    public void OnHoverExit()
    {
        if (_materialInstance == null) return;

        _materialInstance.color = originalColor;

        if (_materialInstance.HasProperty("_EmissionColor"))
        {
            _materialInstance.SetColor("_EmissionColor", originalEmissionColor);
        }
    }
}
