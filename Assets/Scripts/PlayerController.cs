using System.Collections;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.Controls;

public class PlayerController : MonoBehaviour
{
    // Variables
    [SerializeField] KeyCode MoveLeft = KeyCode.LeftArrow;
    [SerializeField] KeyCode MoveRight = KeyCode.RightArrow;
    [SerializeField] KeyCode Shoot = KeyCode.Space;
    [SerializeField, Range(1f, 10f)] float speed = 1f;
    [SerializeField] GameObject bullet;
    [SerializeField] GameObject bulletSpawner;
    [SerializeField, Range(0f, 10f)] float ShootDelay = 1f;

    private bool canShoot = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
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

        yield return new WaitForSeconds(delay);

        GameObject newBullet = Instantiate(bullet, bulletSpawner.transform.position, Quaternion.identity);
        newBullet.SetActive(true);
        Destroy(newBullet, 1.08f);

        canShoot = true;
    }


}
    