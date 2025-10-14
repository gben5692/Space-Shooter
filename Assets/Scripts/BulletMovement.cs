using UnityEngine;

public class BulletMovement : MonoBehaviour
{

    [SerializeField, Range(1, 10)] float shootSpeed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0, 1, 0) * shootSpeed * Time.deltaTime;
        enabled = true;
    }
}
