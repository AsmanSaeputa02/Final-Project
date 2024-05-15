using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private CharacterController controller;
    [SerializeField] private float speed = 10f;

    private float inputX;
    private float inputY;

    private void Update()
    {
        // Get input from Horizontal and Vertical axes
        inputX = Input.GetAxis("Horizontal");
        inputY = Input.GetAxis("Vertical");

        // Create direction vector based on input and normalize it
        Vector3 direction = new Vector3(inputX, 0f, inputY).normalized;

        // Move the character controller based on direction and speed
        controller.Move(direction * Time.deltaTime * speed);

        // Rotate the character towards the direction of movement
        if (direction.magnitude > 0.1f)
        {
            float angle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            Quaternion toRotation = Quaternion.AngleAxis(angle, Vector3.up);
            transform.rotation = Quaternion.Slerp(transform.rotation, toRotation, Time.deltaTime * 15f);
        }
    }
}
