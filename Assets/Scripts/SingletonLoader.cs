using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static GameManager;

public class SingletonLoader : MonoBehaviour
{
    GameManager gameManager;

    void Awake()
    {
        SceneManager.LoadScene(4, LoadSceneMode.Additive);
    }

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        gameManager.GetScene();
        gameManager.OnSceneChanged();
        if (gameManager.GetScene() != Scenes.titleScreen)
            gameManager.Save();
    }
}