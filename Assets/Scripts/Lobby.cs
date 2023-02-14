using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class Lobby : MonoBehaviour
{
    public Button startbutton;
    public GameObject LevelSelection;
    private void Awake()
    {
        startbutton.onClick.AddListener(Playgame);

    }

    private void Playgame()
    {
        //SceneManager.LoadScene(1);
        LevelSelection.SetActive(true);
    }
}
