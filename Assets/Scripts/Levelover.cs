using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelOver : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<PlayerController>() != null)
        {
            Debug.Log(" Level Over ");
            int nextLevel = SceneManager.GetActiveScene().buildIndex + 1;
            if (nextLevel == 5)
                SceneManager.LoadScene(0);
            PlayerPrefs.SetInt("ReachedLEvel", nextLevel);
            SceneManager.LoadScene(nextLevel);
        }
    }
}
