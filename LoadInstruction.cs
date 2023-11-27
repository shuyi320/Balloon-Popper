using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadInstruction : MonoBehaviour
{
    [SerializeField] private string gameLevel = "Instruction";
    public void instruction(){
        SceneManager.LoadScene(gameLevel);
    }
}
