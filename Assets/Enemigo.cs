using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    public float EnemigoSpeed;
    public float EnemigoDamage;
    private Rigidbody2D Erb;
    public float Ehp = 100f;
    public float timeBetweenShoots = 0.5f;
    public GameObject bulletPrefab;
    public Transform EBulletOrigin;
    private float ECurrenthp;
    private float Etimeoflastshoot = 1f;
    public GameObject particlePrefab;
    // Start is called before the first frame update
    void Start()
    {
        ECurrenthp = Ehp;
        Erb = GetComponent<Rigidbody2D>();
        Erb.velocity = Vector2.down * EnemigoSpeed;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Player player = collision.gameObject.GetComponent<Player>();
        if (player != null)
        {
            player.Damage(EnemigoDamage);
            Destroy(this.gameObject);
        }


    }
    // Update is called once per frame
    void Update()
    {
        if (Time.time > Etimeoflastshoot + timeBetweenShoots)
            EShoot();
    }
    private void EShoot()
    {
        Instantiate(bulletPrefab, EBulletOrigin.position, EBulletOrigin.rotation);
        Etimeoflastshoot = Time.time;
    }
    public void Damage(float amount)
    {
        ECurrenthp -= amount;
        
        if (ECurrenthp <= 0f)
        {
            Destroy(this.gameObject);

        }
    }
    public void DestroyEnemy()
    {
        GameObject particles = Instantiate(particlePrefab, transform.position, transform.rotation);
        Destroy(particles, 2f);
        Destroy(this.gameObject);
    }
}
