using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    Animator animator;
    private SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");
        if(Input.GetMouseButtonDown(0)) {
            animator.SetTrigger("Fire");
        }
        if(Input.GetMouseButtonDown(1)) {
            animator.SetTrigger("Swing");
        }
        bool isMoving = moveX != 0 || moveY != 0;
        animator.SetBool("Walking", isMoving);
        if (moveX < 0)
        {
            spriteRenderer.flipX = true; // Flip the sprite to the left
        }
        else if (moveX > 0)
        {
            spriteRenderer.flipX = false; // Flip the sprite to the right
        }
    }
}
