using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadPlay : MonoBehaviour
{
    [SerializeField] private string gameLevel = "level1";
    public void play(){
        SceneManager.LoadScene(gameLevel);
    }
}
