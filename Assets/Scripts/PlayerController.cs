using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Variables
    [SerializeField, Range(0f, 100f)] float health = 100f;
    [SerializeField, Range(0f, 100f)] float shield = 0;
    [SerializeField] KeyCode MoveLeft = KeyCode.LeftArrow;
    [SerializeField] KeyCode MoveRight = KeyCode.RightArrow;
    [SerializeField] KeyCode Shoot = KeyCode.Space;
    [SerializeField, Range(1f, 10f)] float speed = 1f;
    [SerializeField] GameObject bullet;
    [SerializeField] GameObject bulletSpawner;
    [SerializeField, Range(0f, 10f)] float ShootDelay = 1f;
    [SerializeField] int dealDamage = 1; // how much the bullet will deal damage

    private bool canShoot = true;
    private SpriteRenderer spriteRenderer;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(MoveLeft))
        {
            print("Pressed The LeftArrow");
            transform.position += Vector3.left * speed * Time.deltaTime;
        }

        if (Input.GetKey(MoveRight))
        {
            print("Pressed The RightArrow");
            transform.position += Vector3.right * speed * Time.deltaTime;
        }

        if (Input.GetKey(Shoot) && canShoot)
        {
            ShootBullet();
        }

    }

    void ShootBullet()
    {
        StartCoroutine(ShootAfterDelay(ShootDelay));
    }

    IEnumerator ShootAfterDelay(float delay)
    {
        canShoot = false;
        GameObject newBullet = Instantiate(bullet, bulletSpawner.transform.position, Quaternion.identity);
        newBullet.tag = "PlayerBullet";
        BulletMovement bulletMovement = newBullet.GetComponent<BulletMovement>();
        if (bulletMovement != null)
        {
            bulletMovement.SetShooterTag(gameObject.tag);
        }
        else
        {
            print("The Bullet Movement Script Doesnt Exist");
        }
        Destroy(newBullet, 1.08f);
        yield return new WaitForSeconds(delay);
      

        canShoot = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        print("i got hit");

        if (other.gameObject.CompareTag("EnemyBullet"))
        {
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
                        Destroy(gameObject);
                        print("Game Over");
                        QuitGame();
                    }
                }
            }
        }
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit the game");
    }

    private IEnumerator ResetColorAfterDelay(float seconds, Color color)
    {
        yield return new WaitForSeconds(seconds);
        spriteRenderer.color = color;
    }
}
    