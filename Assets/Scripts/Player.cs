using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float Health;
    public float health
    {
        get { return Health; }
        set
        {
            if (value < 0) value = 0;
            statsCanvas.UpdateHealth(value);
            Health = value;
        }
    }
    private float Score;
    public float score
    {
        get { return Score; }
        set
        {
            value = Math.Clamp(value, 0, Constants.maxHealth);
            statsCanvas.UpdateScore(value);
            Score = value;
        }
    }
    private float Experience;
    public float experience
    {
        get { return Experience; }
        set
        {
            if (value < 0) value = 0;
            statsCanvas.UpdateXP(value);
            Experience = value;
        }
    }

    [SerializeField] StatsCanvas statsCanvas;
    
    void Start()
    {
        
    }

    void Update()
    {
        
    }
}