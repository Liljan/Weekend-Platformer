﻿using System;
using UnityEngine;

public class LevelEvents : MonoBehaviour
{
    private static LevelEvents instance;
    // Level events
    public event Action<Transform> SetCheckpoint;

    private void Awake()
    {
        instance = this;
    }

    public static LevelEvents Instance()
    {
        return instance;
    }

    public void InvokeSetCheckpoint(Transform t)
    {
        SetCheckpoint.Invoke(t);
    }
}
