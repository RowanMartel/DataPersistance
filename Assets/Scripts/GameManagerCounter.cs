using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerCounter : MonoBehaviour
{
    private static int GameManagerCount = 0;
    public static int gameManagerCount
    {
        get { return GameManagerCount; }
        set
        {
            GameManagerCount = value;
            StatsCanvas[] statsCanvases = FindObjectsByType<StatsCanvas>(FindObjectsSortMode.None);
            foreach (StatsCanvas c in statsCanvases)
            {
                c.UpdateGMCount(gameManagerCount);
            }
        }
    }
}