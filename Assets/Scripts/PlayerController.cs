using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.Controls;

public class PlayerController : MonoBehaviour
{
    // Variables
    [SerializeField] KeyCode MoveLeft = KeyCode.LeftArrow;
    [SerializeField] KeyCode MoveRight = KeyCode.RightArrow;
    [SerializeField, Range(1f, 10f)] float speed = 1f;

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
        else if (Input.GetKey(MoveRight))
        {
            print("Pressed The RightArrow");
            transform.position += Vector3.right * speed * Time.deltaTime;
        }
    }
}
