using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EBullet : MonoBehaviour
{
    public float speed = 20f;
    public float damageAmount = 10f;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.down * speed;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Player player = collision.gameObject.GetComponent<Player>();
        if (player != null)
        {
            player.Damage(damageAmount);
            Destroy(this.gameObject);
        }
        if (collision.gameObject.CompareTag("meteorite"))
        {
            Meteorito meteorite = collision.gameObject.GetComponent<Meteorito>();

            if (meteorite != null)
            {
                FindObjectOfType<Score>().AddPoints(10);
                Destroy(collision.gameObject);
                Destroy(this.gameObject);
            }
        }

    }

}


