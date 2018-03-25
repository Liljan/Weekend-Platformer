using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FillBar : MonoBehaviour {

    public Transform fillTransform;

    public void Awake()
    {
        SetFill(1.0f);
    }

    public void SetFill(float f)
    {
        Vector3 scale = fillTransform.localScale;
        scale.x = Mathf.Clamp01(f);
        fillTransform.localScale = scale;
    }
}
