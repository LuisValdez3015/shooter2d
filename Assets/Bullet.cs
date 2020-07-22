using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public float damageAmount = 10f;
    private Rigidbody2D rb;
    public GameObject particlePrefab;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.up * speed;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("meteorite"))
        {
            Meteorito meteorite = collision.gameObject.GetComponent<Meteorito>();

            if (meteorite != null)
            {
                FindObjectOfType<Score>().AddPoints(10);
                Destroy(collision.gameObject);
                Destroy(this.gameObject);
                meteorite.DestroyMeteorite();
                Destroybullet();
            }
        }

        if (collision.gameObject.CompareTag("Enemigo"))
        {
            Enemigo enemigo = collision.gameObject.GetComponent<Enemigo>();

            if (enemigo != null)
            {
                FindObjectOfType<Score>().AddPoints(10);
                Destroy(collision.gameObject);
                Destroy(this.gameObject);
                enemigo.DestroyEnemy();
                Destroybullet();
            }
        }
    }
    public void Destroybullet()
    {
        GameObject particles = Instantiate(particlePrefab, transform.position, transform.rotation);
        Destroy(particles, 2f);
        Destroy(this.gameObject);
    }
}
