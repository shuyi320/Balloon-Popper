using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadVolume : MonoBehaviour
{
    [SerializeField] private string gameLevel = "VolumnSetting";
    public void volumn(){
        SceneManager.LoadScene(gameLevel);
    }
}
