using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public MapCamera MapCamera;

    public GameObject winScreen;

    public float winScreenDelay;

    internal void Win()
    {
        winScreen.SetActive(true);
        SceneManager.LoadScene(0);
    }

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }

        Instance = this;
    }


}
