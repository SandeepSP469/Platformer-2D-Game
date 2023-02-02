using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

[RequireComponent(typeof(Button))]
public class Levelloader : MonoBehaviour
{
    private Button button;

    public string Levelname;

    private void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(Click);
    }

    private void Click()
    {
        LevelStatus levelStatus = LevelManager.Instance.GetLevelStatus(Levelname);
        switch (levelStatus)
        {
            case LevelStatus.Locked:
                Debug.Log("Locked");
                break;
            case LevelStatus.Unlocked:
                SceneManager.LoadScene(Levelname);
                break;
            case LevelStatus.Completed:
                SceneManager.LoadScene(Levelname);
                break;
        }
    }
}
