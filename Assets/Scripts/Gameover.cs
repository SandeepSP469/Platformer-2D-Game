using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class Gameover : MonoBehaviour
{
    public Button restartbutton;
    public Button quitbutton;

    private void Awake()
    {
        restartbutton.onClick.AddListener(ReloadLevel);
        quitbutton.onClick.AddListener(Quit);
    }

    private void Quit()
    {
        SceneManager.LoadScene(0);
    }

    public void Playerdies()
    {
        gameObject.SetActive(true);

    }

    private void ReloadLevel()
    {
        Debug.Log("Reloaded");
        SceneManager.LoadScene(1);
    }
}
