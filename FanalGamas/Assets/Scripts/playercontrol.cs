using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public float moveSpeed; // Corrected variable name

    public bool isMoving;
    private Vector2 input;

    private void Update()
    {
        if (!isMoving)
        {
            input.x = Input.GetAxisRaw("Horizontal"); // Corrected method name and variable name
            input.y = Input.GetAxisRaw("Vertical"); // Corrected method name

            if (input != Vector2.zero)
            {
                var targetPos = transform.position; // Corrected variable name
                targetPos.x += input.x;
                targetPos.y += input.y;

                StartCoroutine(Move(targetPos));
            }
        }
    }

    IEnumerator Move(Vector3 targetPos)
    {
        isMoving = true;
        while ((targetPos - transform.position).sqrMagnitude > Mathf.Epsilon)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime); // Corrected variable name and added missing multiplication sign
        
            yield return null;
        }
        transform.position = targetPos;
        isMoving = false;
    }
}
