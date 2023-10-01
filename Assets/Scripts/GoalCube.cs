using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalCube : MonoBehaviour
{
    GameManager gameManager;
    [SerializeField] GameManager.Scenes sceneToLoad;

    void Start()
    {
        FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
            return;
        gameManager.LoadScene(sceneToLoad);
    }
}