using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnM : MonoBehaviour
{
    public GameObject[] Meteoros;
    
    float randx;
    Vector2 wheretoSpawn;
    public float Spawnrate;
    int random;
    float nestSpawn = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
       
    }
    
    void Update()
    {
        if (Time.time > nestSpawn)
        {
            nestSpawn = Time.time + Spawnrate;
            randx = Random.Range(-6.11f, 6.17f);
            wheretoSpawn = new Vector2(randx, transform.position.y);
            random = Random.Range(0, Meteoros.Length);
            Instantiate(Meteoros[random], wheretoSpawn, Quaternion.identity);
            
        }
    }
    
}
