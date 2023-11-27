using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonSpawner : MonoBehaviour
{
    private float radius = 4f;
    public GameObject balloonPrefab;
    // Start is called before the first frame update
    void Start()
    {
        for(int i=0; i<15; i++){
            Vector3 randomPosition = Random.insideUnitSphere * radius;
            Instantiate(balloonPrefab, randomPosition, Quaternion.identity);
        }
    }

   
}
