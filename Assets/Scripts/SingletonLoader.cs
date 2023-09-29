using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    }
}