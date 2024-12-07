using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5;
    public Rigidbody2D myRigidBody;
    Vector2 movement;
    public Animator animator;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Input
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("horizontal", movement.x);
        animator.SetFloat("speed", movement.sqrMagnitude);
    }

    // Updates at a fixed frame rate, i.e. 50fps
    private void FixedUpdate()
    {
        // Movement
        myRigidBody.MovePosition(myRigidBody.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
