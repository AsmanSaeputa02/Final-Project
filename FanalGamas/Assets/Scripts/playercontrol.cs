using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public float moveSpeed;
    private bool isMoving;
    private Vector2 input;

    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>(); // Corrected method name
    }

    private void Update()
    {
        if (!isMoving)
        {
            input.x = Input.GetAxisRaw("Horizontal");
            input.y = Input.GetAxisRaw("Vertical");
            // Debug.Log("This is input.x: " + input.x); // Removed extra Debug prefix
            // Debug.Log("This is input.y: " + input.y);

            if (input.x != 0) input.y = 0; // Corrected inequality operator

            if (input != Vector2.zero)
            {
                animator.SetFloat("moveX", input.x); // Corrected method name
                animator.SetFloat("moveY", input.y); // Corrected method name

                var targetPos = transform.position;
                targetPos.x += input.x;
                targetPos.y += input.y;

                StartCoroutine(Move(targetPos));
            }
        }

        animator.SetBool("isMoving", isMoving); // Added missing semicolon and fixed indentation
    }

    IEnumerator Move(Vector3 targetPos)
    {
        isMoving = true;
        while ((targetPos - transform.position).sqrMagnitude > Mathf.Epsilon)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
            yield return null;
        }
        transform.position = targetPos;
        isMoving = false;
    }
}
