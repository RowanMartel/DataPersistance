using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleScreen : MonoBehaviour
{
    [SerializeField] GameManager gameManager;

    public void NewGame()
    {
        gameManager.LoadScene(GameManager.Scenes.level1);
    }
    public void LoadGame()
    {
        gameManager.Load();
    }
}