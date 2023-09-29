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

    private void Start()
    {
        UpdateHealth(player.health);
        UpdateScore(player.score);
        UpdateXP(player.experience);
    }

    public void UpdateHealth(float health)
    {
        if (health >= 0)
            health_Text.text = "Health: " + health.ToString();
    }
    public void UpdateScore(float score)
    {
        if (score >= 0)
            score_Text.text = "Score: " + score.ToString();
    }
    public void UpdateXP(float xp)
    {
        if (xp >= 0)
            xp_Text.text = "XP: " + xp.ToString();
    }
}