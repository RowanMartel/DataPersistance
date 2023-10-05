using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] GameManager gameManager;

    private float Health;
    public float health
    {
        get { return Health; }
        set
        {
            if (value >= Constants.maxHealth)
                value = Constants.maxHealth;
            if (value < 0) value = 0;
            statsCanvas.UpdateHealth(value);
            Health = value;
            silliness++;
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
            silliness++;
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
            silliness++;
        }
    }
    private float Silliness;
    public float silliness
    {
        get { return Silliness; }
        set
        {
            if (value < 0) value = 0;
            statsCanvas.UpdateSilliness(value);
            Silliness = value;
        }
    }
    private float Level;
    public float level
    {
        get { return Level; }
        set
        {
            if (value < 0) value = 0;
            statsCanvas.UpdateLevel(value);
            Level = value;
            silliness++;
        }
    }
    private float Stage;
    public float stage
    {
        get { return Stage; }
        set
        {
            if (value < 0) value = 0;
            statsCanvas.UpdateStage(value);
            Stage = value;
            silliness++;
        }
    }

    [SerializeField] StatsCanvas statsCanvas;

    private void Start()
    {
        ResetStats();
    }

    public void Heal(float health)
    {
        this.health += health;
        if (this.health > Constants.maxHealth)
            health = Constants.maxHealth;
    }
    public void Damage(float damage)
    {
        health -= damage;
        if (health == 0)
        {
            Die();
        }
    }
    public void Die()
    {
        gameManager.LoadScene(GameManager.Scenes.titleScreen);
    }
    public void GetXP(float experience)
    {
        this.experience += experience;
        if (this.experience >= 25)
        {
            experience = this.experience - 25;
            LevelUp(experience);
        }
    }
    public void LevelUp(float leftOverXP = 0)
    {
        experience = leftOverXP;
        level++;
    }

    public void ResetStats()
    {
        health = Constants.startingHealth;
        experience = 0;
        level = 1;
        silliness = 0;
    }
}