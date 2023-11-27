using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinMovement : MonoBehaviour
{
    public float speed = 5f; // Adjust the speed as needed
    private Vector3 shootDirection; // The direction to move the pin


    void Start()
    {

    }

    void Update()
    {
        // Move the pin in the specified direction
        transform.Translate(shootDirection * speed * Time.deltaTime);
    }

    // Call this method to set the pin's shoot direction
    public void SetShootDirection(Vector3 direction)
    {
        shootDirection = direction.normalized; // Normalize the direction vector
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Bird") || other.CompareTag("Balloon")){
            Destroy(gameObject);
        }
    }

}