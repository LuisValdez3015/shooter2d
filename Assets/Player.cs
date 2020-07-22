using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float hp = 100f;
    public float timeBetweenShoots = 0.5f;
    public GameObject bulletPrefab;
    public Transform BulletOrigin;
    private float Currenthp;
    private float timeoflastshoot = 1f;
    public Text DamageText;
    public GameObject particlePrefab;
    public AudioClip shootAudioClip;
    public AudioClip DestroyPlayerAudioClip;
    // Start is called before the first frame update
    private void Start()
    {
        Currenthp = hp;
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Time.time > timeoflastshoot + timeBetweenShoots)
                Shoot();
        }
    }
    public void Damage(float amount)
    {
        Currenthp -= amount;
        DamageText.text = "HP: " + Currenthp;
        if (Currenthp <= 0f)
        {
            AudioSource.PlayClipAtPoint(DestroyPlayerAudioClip, transform.position, 0.75f);
            FindObjectOfType<GameManager>().GameOver();
            Destroy(this.gameObject);
            Destroyplayer();
        }
    }
    private void Shoot()
    {
        AudioSource.PlayClipAtPoint(shootAudioClip, transform.position, 0.75f);
        Instantiate(bulletPrefab, BulletOrigin.position, BulletOrigin.rotation);
        timeoflastshoot = Time.time;
    }
    public void Destroyplayer()
    {
        GameObject particles = Instantiate(particlePrefab, transform.position, transform.rotation);
        Destroy(particles, 2f);
        Destroy(this.gameObject);
    }
}
