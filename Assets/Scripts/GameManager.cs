using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] StatsCanvas statsCanvas;
    [SerializeField] Animation saveAnimation;

    private float Health;
    public float health
    {
        get{ return Health; }
        set
        {
            if (value < 0) value = 0;
            statsCanvas.UpdateHealth(value);
            Health = value;
        }
    }
    private float Score;
    public float score
    {
        get { return Score; }
        set
        {
            value = Math.Clamp(value, 0, Constants.maxHealth);
            statsCanvas.UpdateScore(value);
            Score = value;
        }
    }
    private float Experience;
    public float experience
    {
        get { return Experience; }
        set
        {
            if (value < 0) value = 0;
            statsCanvas.UpdateXP(value);
            Experience = value;
        }
    }

    public event EventHandler<SceneChangedEventArgs> SceneChanged;

    public enum Scenes
    {
        titleScreen,
        level1,
        level2,
        level3
    }
    Scenes currentScene;

    void Start()
    {
        GetScene();
        OnSceneChanged();
    }

    public void LoadScene(Scenes newScene)
    {
        switch (newScene)
        {
            case Scenes.titleScreen:
                SceneManager.LoadSceneAsync(0);
                break;
            case Scenes.level1:
                SceneManager.LoadSceneAsync(1);
                break;
            case Scenes.level2:
                SceneManager.LoadSceneAsync(2);
                break;
            case Scenes.level3:
                SceneManager.LoadSceneAsync(3);
                break;
        }
        OnSceneChanged();
    }

    public void GetScene()
    {
        switch (SceneManager.GetActiveScene().buildIndex)
        {
            case 0:
                currentScene = Scenes.titleScreen;
                break;
            case 1:
                currentScene = Scenes.level1;
                break;
            case 2:
                currentScene = Scenes.level2;
                break;
            case 3:
                currentScene = Scenes.level3;
                break;
        }
    }

    public void OnSceneChanged()
    {
        if (SceneChanged != null)
            SceneChanged(this, new SceneChangedEventArgs(currentScene));
    }

    public void Save()
    {
        saveAnimation.Play();

        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/playerInfo.dat");

        PlayerData data = new PlayerData(health, score, currentScene);

        bf.Serialize(file, data);
        file.Close();
    }

    public void Load()
    {
        if (File.Exists(Application.persistentDataPath + "/playerInfo.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);
            PlayerData data = (PlayerData)bf.Deserialize(file);
            file.Close();

            health = data.health;
            score = data.score;
            LoadScene(data.currentScene);
        }
    }
}

[Serializable]
class PlayerData
{
    public float health;
    public float score;
    public GameManager.Scenes currentScene;

    public PlayerData(float health, float score, GameManager.Scenes currentScene)
    {
        this.health = health;
        this.score = score;
        this.currentScene = currentScene;
    }
}

public class SceneChangedEventArgs : EventArgs
{
    public GameManager.Scenes currentScene;

    public SceneChangedEventArgs(GameManager.Scenes currentScene)
    {
        this.currentScene = currentScene;
    }
}