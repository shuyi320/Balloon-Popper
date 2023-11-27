using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{
    [SerializeField] private string gameLevel = "Menu";
    public void menu(){
        SceneManager.LoadScene(gameLevel);
    }

    public void pause(){
        Time.timeScale = 0f;
    }

    public void resume(){
        Time.timeScale = 1.0f;
    }
}
