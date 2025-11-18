using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class EnemiesController : MonoBehaviour
{
    [SerializeField, Range(0f, 100f)] float health = 100f; 
    [SerializeField, Range(0f, 100f)] float shield = 0;
    [SerializeField] GameObject bullet;
    [SerializeField] GameObject[] bulletSpawner;
    [SerializeField, Range(0f, 10f)] float ShootDelay = 1f;
    [SerializeField] int dealDamage = 1; // how much the bullet will deal damage
    [SerializeField] int ScoreOnKill = 1;
    [SerializeField] AudioClip enemyShootingSound;
    private SpriteRenderer spriteRenderer;
    private ScoreManager scoreManager;
    public AudioSource audioSource;
    
    public PlayerController playerController;

    private bool canShoot = true;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        scoreManager = FindFirstObjectByType<ScoreManager>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        shootBullet();
    }

    // Check if the thing that enters the collider is a bullet then take damage
    private void OnTriggerEnter2D(Collider2D other) 
    {
        print("i got hit");

        if (other.gameObject.CompareTag("PlayerBullet"))
        {
            Destroy(other.gameObject);

            if (shield > 0)
            {
                spriteRenderer.color = Color.blue;
                print($"shield: {shield}");
                shield -= dealDamage;
                StartCoroutine(ResetColorAfterDelay(0.1f, Color.white));
            }
            if (shield <= 0)
            {
                if (health >= 0f && health <= 100f)
                {
                    spriteRenderer.color = Color.red;
                    health -= dealDamage;
                    print($"Health: {health}");

                    StartCoroutine(ResetColorAfterDelay(0.1f, Color.white));

                    if (health <= 0f)
                    {
                        scoreManager.AddScore(ScoreOnKill);

                        Destroy(gameObject);
                    }
                }
            }
        }
    }

    void shootBullet()
    {
        if (canShoot)
        {
            StartCoroutine(shootAfterSec(ShootDelay));
        }
    }

    private IEnumerator shootAfterSec(float seconds)
    {
        canShoot = false;

        yield return new WaitForSeconds(seconds);

        foreach (GameObject bulletSpawner in bulletSpawner)
        {
            GameObject newBullet = Instantiate(bullet, bulletSpawner.transform.position, Quaternion.identity);
            BulletMovement bulletMovement = newBullet.GetComponent<BulletMovement>();
            newBullet.tag = "EnemyBullet";

            audioSource.clip = enemyShootingSound;
            audioSource.Play();

            if (bulletMovement != null)
            {
                bulletMovement.SetShooterTag(gameObject.tag);
            }
            else
            {
                print("The Bullet Movement Script Doesnt Exist");
            }

            Destroy(newBullet, 1.08f);
        }

        canShoot = true;     
    }

    private IEnumerator ResetColorAfterDelay(float seconds, Color color)
    {
        yield return new WaitForSeconds(seconds);
        spriteRenderer.color = color;
    }

}
