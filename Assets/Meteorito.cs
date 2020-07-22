using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteorito : MonoBehaviour
{
    public float speed = 5f;
    public float damageAmount = 10f;
    private Rigidbody2D rb;

    public GameObject particlePrefab;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.down * speed;


    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Player player = collision.gameObject.GetComponent<Player>();
            if (player != null)
            {
                player.Damage(damageAmount);
                Destroy(this.gameObject);
            }
        }
        
       
       
    }
   public void DestroyMeteorite()
    {
        GameObject particles = Instantiate(particlePrefab, transform.position, transform.rotation);
        Destroy(particles, 2f);
        Destroy(this.gameObject);
    }
   
}

