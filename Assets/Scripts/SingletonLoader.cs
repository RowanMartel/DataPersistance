using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SingletonLoader : MonoBehaviour
{
    void Awake()
    {
        SceneManager.LoadScene(4, LoadSceneMode.Additive);
    }
}