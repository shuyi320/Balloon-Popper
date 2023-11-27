using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{
    private int score = 0;
    [SerializeField] Text scoreText;
    [SerializeField] private BalloonMovement balloon;
    [SerializeField] private BirdMovement bird;
    [SerializeField] int level;
    [SerializeField] int scoreThresholdForThisLevel;
    public const int SCORE_THRESHOLD = 10;
    
    // Start is called before the first frame update
    void Start()
    {
        balloon = BalloonMovement.FindObjectOfType<BalloonMovement>();
        bird = BirdMovement.FindObjectOfType<BirdMovement>();

        level = SceneManager.GetActiveScene().buildIndex ;
        Debug.Log(level);
        scoreThresholdForThisLevel = SCORE_THRESHOLD * level;

    }

    // Update is called once per frame
    void Update()
    {
        score = balloon.GetNumPopped() - bird.GetNumKilled();
        DisplayScore();
        if(score >= scoreThresholdForThisLevel)
        {
            SceneManager.LoadScene(level + 1);
        }
    }

    public void DisplayScore()
    {

        scoreText.text = "Score: " + score;
        
    }

    public int GetScore(){
        return score;
    }
}
