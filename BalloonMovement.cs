using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BalloonMovement : MonoBehaviour
{
    private Rigidbody2D balloon;
    private float dirX = 2f, dirY = 2f;
    private float speed = 2;
    private new AudioSource audio;
    private float maxSize = 0.07f;
    private static int NumPopped = 0;
    [SerializeField] int level;
    
    // Start is called before the first frame update
    void Start()
    {
        //Move the balloon in random direction
        balloon = GetComponent<Rigidbody2D>();
        audio = GetComponent<AudioSource>();
        level = SceneManager.GetActiveScene().buildIndex ;
        speed *= level; //balloon speed up as the level increasse
        move(Random.Range(-dirX, dirX), Random.Range(-dirY, dirY));

        InvokeRepeating("GrowBalloon", 2.0f, Time.deltaTime);
        
    }

    void Update(){
        keepInScreen();

        //destroy all balloons if they're big enough, and reload the current scence
        if(transform.localScale.x >= maxSize){
            destroyBalloon();
            int level = SceneManager.GetActiveScene().buildIndex ;
            SceneManager.LoadScene(level);
        }

    }
    //send balloon back in the opposite direction if past the edges of screen
    void keepInScreen(){
        Vector2 balloonObject = Camera.main.WorldToScreenPoint(transform.position);
        if(balloonObject.x <= 0 || balloonObject.x >= Screen.width){
            dirX = -dirX;
            move(dirX, dirY);
        }
        if(balloonObject.y <= 0 || balloonObject.y >= Screen.height){
            dirY = -dirY;
            move(dirX, dirY);
        }
    }

    void move(float x, float y){
        balloon.velocity = new Vector2(x*speed, y*speed);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Pin"))
        {
            // add 2 if balloon is smallar, otherwise, add 1
            NumPopped += transform.localScale.x >= 0.035 ? 1 : 2;
            destroyBalloon();
        }
    }

    void GrowBalloon(){
        transform.localScale += new Vector3(0.00002f, 0.00002f, 0.00002f);
    }

    void destroyBalloon(){
        AudioSource.PlayClipAtPoint(audio.clip, transform.position);
        Destroy(gameObject);
    }

    public int GetNumPopped(){
        return NumPopped;
    }
}
   