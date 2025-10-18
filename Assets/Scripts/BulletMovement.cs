using UnityEngine;

public class BulletMovement : MonoBehaviour
{

    [SerializeField, Range(1, 10)] float shootSpeed;
    [SerializeField] GameObject Bullet;

    private string shooterTag;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (shooterTag == "Enemy")
        {
            transform.position += new Vector3(0, -1, 0) * shootSpeed * Time.deltaTime;
            enabled = true;
        }
        if (shooterTag == "Player")
        {
            transform.position += new Vector3(0, 1, 0) * shootSpeed * Time.deltaTime;
            enabled = true;
        }
    }

    public void SetShooterTag(string tag)
    {
        shooterTag = tag;
    }

}
