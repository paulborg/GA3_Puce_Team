using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarkerProximityEffect : MonoBehaviour
{
    public float maxEffectDistance = 5f;
    public float minScale = 0.5f;
    public float maxScale = 1.5f;
    private Color baseEmissionColor;
    private Color highlightEmissionColor = Color.yellow * 5f;

    private Renderer renderer;
    private Material material;
    private Vector3 baseScale;

    void Start()
    {
        renderer = GetComponentInChildren<Renderer>();
        material = renderer.material;
        baseScale = transform.localScale;

        baseEmissionColor = material.color;

    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = CameraMousePointer.mouseRay; // Getting the raycast from CameraMousePointer
        Vector3 closestPoint = CameraMousePointer.ClosestPointOnRay(ray, transform.position); // Getting the "closest point" helper method from CameraMousePointer


        float distance = Vector3.Distance(closestPoint, transform.position);

        if (distance < maxEffectDistance)
        {
            float t = 1f - (distance / maxEffectDistance);
            float scale = Mathf.Lerp(minScale, maxScale, t);
            transform.localScale = baseScale * scale;
        }

    }
}
