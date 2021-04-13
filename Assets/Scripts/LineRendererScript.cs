using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineRendererScript : MonoBehaviour
{
    [SerializeField] private Transform[] points;
    LineRenderer lineRenderer;
    private bool enable = false;

    public void DrawLine()
    {
        lineRenderer = new GameObject("Line").AddComponent<LineRenderer>();
        lineRenderer.startColor = Color.red;
        lineRenderer.endColor = Color.red;
        lineRenderer.material = default;
        lineRenderer.startWidth = 1f;
        lineRenderer.endWidth = 1f;
        lineRenderer.positionCount = 2;
        lineRenderer.useWorldSpace = true;
    }

    public void Start() 
    {
       DrawLine();
    }
    public void Update()
    {
        if (enable) 
        {
            lineRenderer.SetPosition(0, points[0].position);
            lineRenderer.SetPosition(1, points[1].position);
        }
    }

    public bool GetEnable() {
        return enable;
    }

    public void SetEnable(bool en)
    {
        this.enable = en;
    }
}
