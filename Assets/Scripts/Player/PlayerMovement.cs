using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    private float gravity = -9.81f;
    [SerializeField] float jumpHeight = 2f;

    private CharacterController controller;
    private Vector3 velocity;
    private bool isGrounded;
    public float rollLength = 1f;
    public float rollFreq = 1f;
    private float lockX = 0;
    private float lockZ = 0;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>(); 
    }

    // Update is called once per frame
    void Update()
    {
        rollLength += Time.deltaTime;
        rollFreq += Time.deltaTime;
        isGrounded = controller.isGrounded;

        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        if (Input.GetKeyDown(KeyCode.LeftShift) && rollFreq > 1f)
        {
            lockX = moveX;
            lockZ = moveZ;
            rollLength = 0;
            rollFreq = 0;
        }

        if (isGrounded && rollLength < 0.3f)
        {
            moveX = lockX * 3;
            moveZ = lockZ * 3;
        }

        Vector3 move = transform.right * moveX + transform.forward * moveZ;

        controller.Move(move * speed * Time.deltaTime);

        if (isGrounded && velocity.y < 0) {
            velocity.y = -2f; // Slight force to keep character grounded.
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded) {
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        }

        // Apply gravity to velocity
        velocity.y += gravity * Time.deltaTime;

        // Move character with gravity applied
        controller.Move(velocity * Time.deltaTime);
    }
}
