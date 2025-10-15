using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthComponentEnemies : MonoBehaviour
{
    [SerializeField, Range(0f, 100f)] float health = 100f; 
    [SerializeField, Range(0f, 100f)] float shield = 0;
    [SerializeField] int dealDamage = 1; // how much the bullet will deal damage
    private SpriteRenderer spriteRenderer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Check if the thing that enters the collider is a bullet then take 1 damage currently it is hardcoded but will be fixed later
    private void OnTriggerEnter2D(Collider2D other) 
    {
        print("i got hit");

        if (other.gameObject.CompareTag("Bullet 9mm"))
        {
            if (health >= 0f && health <= 100f)
            {
                print($"Health: {health}");
                spriteRenderer.color = Color.red;
                health -= dealDamage;

                StartCoroutine(ResetColorAfterDelay(0.1f));

                if (health <= 0f)
                {
                    Destroy(gameObject);
                }
            }
        }
    }

    private IEnumerator ResetColorAfterDelay(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        spriteRenderer.color = Color.white;
    }
}
