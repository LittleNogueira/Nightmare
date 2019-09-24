using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody rigidbody;
    private Animator animator;
    public float speed = 5;
    int floorMask;
    float camRayLength = 100f;

    void Start()
    {
        floorMask = LayerMask.GetMask("Floor");
        rigidbody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Animation(horizontal, vertical);
    }

    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Move(horizontal, vertical);
        Turning();
    }

    void Move(float horizontal, float vertical)
    {
        Vector3 movementNormalized = new Vector3(horizontal, 0, vertical);
        movementNormalized = movementNormalized * speed * Time.deltaTime;

        rigidbody.MovePosition(transform.position + movementNormalized);
    }

    void Animation(float horizontal, float vertical)
    {
        bool running = horizontal != 0 || vertical != 0;

        animator.SetBool("Running", running);
    }

    void Turning()
    {
        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit floorHit;

        if (Physics.Raycast(camRay, out floorHit, camRayLength, floorMask))
        {
            Vector3 playerToMouse = floorHit.point - transform.position;

            playerToMouse.y = 0f;

            Quaternion newRotation = Quaternion.LookRotation(playerToMouse);

            rigidbody.MoveRotation(newRotation);
        }
    }
}
