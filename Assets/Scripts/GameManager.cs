﻿using System;
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

    public Animator winScreenAnimation;

    public GameObject[] WinMeshes;

    public int winItems;

    internal void Win()
    {
        winScreen.SetActive(true);

        StartCoroutineWaitForSec();

        for (int i = 0; i < winItems; i++)
        {
            if (WinMeshes[i] != null)
            {
                WinMeshes[i].SetActive(true);
            }
        }
    }

    public void LoadLevel()
    {
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

    public void AddWinItems()
    {
        winItems++;
    }

    void StartCoroutineWaitForSec()
    {
        StartCoroutine(Example());
    }

    IEnumerator Example()
    {
        yield return new WaitForSeconds(winScreenDelay);

        if (winScreenAnimation != null)
        {
            winScreenAnimation.SetTrigger("Win");
        }
    }


}
