using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StatsCanvas : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    [SerializeField] Player player;
    [SerializeField] private TMP_Text health_Text;
    [SerializeField] private TMP_Text score_Text;
    [SerializeField] private TMP_Text xp_Text;
    [SerializeField] private TMP_Text silliness_Text;
    [SerializeField] private TMP_Text level_Text;
    [SerializeField] private TMP_Text stage_Text;

    private void Start()
    {
        UpdateHealth(player.health);
        UpdateScore(player.score);
        UpdateXP(player.experience);
    }

    public void UpdateHealth(float health)
    {
        health_Text.text = "Health: " + health.ToString();
    }
    public void UpdateScore(float score)
    {
        score_Text.text = "Score: " + score.ToString();
    }
    public void UpdateXP(float xp)
    {
        xp_Text.text = "XP: " + xp.ToString();
    }
    public void UpdateSilliness(float silliness)
    {
        silliness_Text.text = "Silliness: " + silliness.ToString();
    }
    public void UpdateLevel(float level)
    {
        level_Text.text = "Level: " + level.ToString();
    }
    public void UpdateStage(float stage)
    {
        stage_Text.text = "Stage: " + level_Text.ToString();
    }
}