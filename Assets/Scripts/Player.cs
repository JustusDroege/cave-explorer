using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector3 moveDelta;
    public float moveSpeed = 2f;

    public float rotationSpeed = 14400f;

    private void Start() 
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update() 
    {
        Move();
    }
    
    private void Move()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y =  Input.GetAxisRaw("Vertical");

        // Create MoveDelta
        moveDelta = new Vector3(x, y ,0);

        // Move in a direction
        rb.velocity = new Vector2(moveDelta.x, moveDelta.y) * moveSpeed;

        // Swap sprite direction, wether go right or left
        if (moveDelta != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(Vector3.forward, moveDelta);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }

        

    }
}
