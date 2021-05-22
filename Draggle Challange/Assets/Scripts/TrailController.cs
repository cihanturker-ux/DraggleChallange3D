using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailController : MonoBehaviour
{
    public static TrailController Instance { get; private set; }

    [SerializeField] private TrailRenderer leftTrail;
    [SerializeField] private TrailRenderer rightTrail;
    
    private void Awake()
    {
        Instance = this;
    }

    public void ToggleTrails(bool toggle)
    {
        leftTrail.emitting = toggle;
        rightTrail.emitting = toggle;
    }
}
