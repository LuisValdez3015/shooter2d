using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ESpawner : MonoBehaviour
{
    public GameObject[] Enemigos;
    
    float randx;
    Vector2 wheretoSpawn;
    public float Spawnrate;
    int random;
    float nestSpawn = 0.0f;
    
    float leftLimit;
    
    float rigthLimit;
    // Start is called before the first frame update
    void Start()
    {
        Vector2 xlimit = Camera.main.ViewportToWorldPoint(Vector2.zero);
        
        leftLimit = xlimit.x;

        Vector2 topRight = Camera.main.ViewportToWorldPoint(Vector2.one);
        
        rigthLimit = topRight.x;
    }

    void Update()
    {
        if (Time.time > nestSpawn)
        {
            nestSpawn = Time.time + Spawnrate;
            randx = Random.Range(rigthLimit, leftLimit);
            wheretoSpawn = new Vector2(randx, transform.position.y);
            random = Random.Range(0, Enemigos.Length);
            Instantiate(Enemigos[random], wheretoSpawn, Quaternion.identity);

        }
    }
}
