using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdMovement : MonoBehaviour
{
    private Rigidbody2D bird;
    private float dirX;
    private float speed = 3f;
    private bool isFacingRight = true;
    private float movement;
    private int NumKilled = 0;
    // Start is called before the first frame update
    void Start()
    {
        bird = GetComponent<Rigidbody2D>();
        dirX = 3f;
        move(Random.Range(2f, dirX)*speed);
    }

    // Update is called once per frame
    void Update()
    {
        keepInScreen();
    }

    void move(float x){
        bird.velocity = new Vector2(x, Random.Range(-2f, 2f));
    }

    void keepInScreen(){
        Vector2 border = Camera.main.WorldToScreenPoint(transform.position);
        if(border.x <= 0 || border.x >= Screen.width){
            dirX = -dirX;
            move(dirX);
            Flip();
        }
        if(border.y <= 0 || border.y >= Screen.height){
            bird.velocity = new Vector2(transform.position.x,  -transform.position.y);
        }
    }

    void Flip()
    {
        transform.Rotate(0, 180, 0);
        isFacingRight = !isFacingRight;
    }

    //count how many birds were killed
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Pin"))
        {
            NumKilled += 1;
            Destroy(gameObject);
        }
    }

    public int GetNumKilled(){
        return NumKilled;
    }

}
