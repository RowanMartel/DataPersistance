using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehaviourToggle : MonoBehaviour
{
    [SerializeField] bool onTitle;
    [SerializeField] bool onLvl1;
    [SerializeField] bool onLvl2;
    [SerializeField] bool onLvl3;
    GameObject container;

    private void Start()
    {
        container = transform.GetChild(0).gameObject;
        FindObjectOfType<GameManager>().SceneChanged += OnSceneChanged;
    }

    public void OnSceneChanged(object source, SceneChangedEventArgs e)
    {
        switch (e.currentScene)
        {
            case GameManager.Scenes.titleScreen:
                if (onTitle) container.SetActive(true);
                else container.SetActive(false);
                break;
            case GameManager.Scenes.level1:
                if (onLvl1) container.SetActive(true);
                else container.SetActive(false);
                break;
            case GameManager.Scenes.level2:
                if (onLvl2) container.SetActive(true);
                else container.SetActive(false);
                break;
            case GameManager.Scenes.level3:
                if (onLvl3) container.SetActive(true);
                else container.SetActive(false);
                break;
        }
    }
}