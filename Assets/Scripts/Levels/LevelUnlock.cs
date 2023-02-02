using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelUnlock : MonoBehaviour
{
    public Button[] levelButtons;

    private void Start()
    {
        foreach (Button b in levelButtons)
            b.interactable = false;

        int reachedLevel = PlayerPrefs.GetInt("Reached Level 1", 1);

        for (int i = 0; i < reachedLevel; i++)
            levelButtons[i].interactable = true;
    }
}
