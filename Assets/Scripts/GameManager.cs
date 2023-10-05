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
    [SerializeField] public Animation saveAnimation;
    [SerializeField] Player player;

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
                player.stage = 0;
                SceneManager.LoadSceneAsync(0);
                break;
            case Scenes.level1:
                player.stage = 1;
                SceneManager.LoadSceneAsync(1);
                break;
            case Scenes.level2:
                player.stage = 2;
                SceneManager.LoadSceneAsync(2);
                break;
            case Scenes.level3:
                player.stage = 3;
                SceneManager.LoadSceneAsync(3);
                break;
        }
    }

    public Scenes GetScene()
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
        return currentScene;
    }

    public void OnSceneChanged()
    {
        if (SceneChanged != null)
            SceneChanged(this, new SceneChangedEventArgs(currentScene));
    }

    public void NewGame()
    {
        player.ResetStats();
        LoadScene(Scenes.level1);
    }

    public void Save()
    {
        saveAnimation.Play();

        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/playerInfo.dat");

        PlayerData data = new PlayerData(player.health, player.score, player.experience, player.silliness, player.level, player.stage, currentScene);
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

            player.health = data.health;
            player.score = data.score;
            player.experience = data.experience;
            player.silliness = data.silliness;
            player.level = data.level;
            player.stage = data.stage;
            currentScene = data.currentScene;
            LoadScene(data.currentScene);
        }
    }
}

[Serializable]
class PlayerData
{
    public float health;
    public float score;
    public float experience;
    public float silliness;
    public float level;
    public float stage;
    public GameManager.Scenes currentScene;

    public PlayerData(float health, float score, float experience, float silliness, float level, float stage, GameManager.Scenes currentScene)
    {
        this.health = health;
        this.score = score;
        this.experience = experience;
        this.silliness = silliness;
        this.level = level;
        this.stage = stage;
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