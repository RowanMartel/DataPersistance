using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleScreen : MonoBehaviour
{
    [SerializeField] GameManager gameManager;

    public void NewGame()
    {
        gameManager.NewGame();
    }
    public void LoadGame()
    {
        gameManager.Load();
    }
}