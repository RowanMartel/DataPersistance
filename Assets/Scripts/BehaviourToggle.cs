using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehaviourToggle : MonoBehaviour
{
    [SerializeField] Behaviour behaviourToToggle;
    [SerializeField] bool onTitle;
    [SerializeField] bool onLvl1;
    [SerializeField] bool onLvl2;
    [SerializeField] bool onLvl3;

    private void Start()
    {
        FindObjectOfType<GameManager>().SceneChanged += OnSceneChanged;
    }

    public void OnSceneChanged(object source, SceneChangedEventArgs e)
    {
        switch (e.currentScene)
        {
            case GameManager.Scenes.titleScreen:
                behaviourToToggle.enabled = onTitle;
                break;
            case GameManager.Scenes.level1:
                behaviourToToggle.enabled = onLvl1;
                break;
            case GameManager.Scenes.level2:
                behaviourToToggle.enabled = onLvl2;
                break;
            case GameManager.Scenes.level3:
                behaviourToToggle.enabled = onLvl3;
                break;
        }
    }
}