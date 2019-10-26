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

    public Animator winScreenAnimation;
    public float animationDelay;

    public GameObject[] WinMeshes;

    public int winItems;

    public Char_ char_;

    internal void Win()
    {
        Debug.Log("Win");

        char_.enabled = false;

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
        yield return new WaitForSeconds(animationDelay);

        if (winScreenAnimation != null)
        {
            winScreenAnimation.enabled = true;
            winScreenAnimation.SetTrigger("Win");
        }

        yield return new WaitForSeconds(winScreenDelay);

        winScreen.SetActive(true);
    }


}
