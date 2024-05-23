using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private CharacterController controller;
    [SerializeField] private float walkSpeed = 5f;
    [SerializeField] private float runSpeed = 10f;
    [SerializeField] private float gravity = -9.81f;
    [SerializeField] private float groundDistance = 0.4f;
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private Animator anim;

    [SerializeField] private float maxEnergy = 100f;
    [SerializeField] private float energyCostPerSecond = 10f;
    [SerializeField] private float energyRecoveryRate = 5f;
    [SerializeField] private Slider staminaBar;
    private float currentEnergy;

    private float inputX;
    private float inputY;
    private Vector3 velocity;
    private bool isGrounded;
    private Transform groundCheck;

    private Vector2 boundaryMin;
    private Vector2 boundaryMax;

    private void Awake()
    {
        groundCheck = new GameObject("GroundCheck").transform;
        groundCheck.SetParent(transform);
        groundCheck.localPosition = Vector3.down * 0.5f;

        GameObject plane = GameObject.Find("Plane");
        if (plane != null)
        {
            Collider planeCollider = plane.GetComponent<Collider>();
            if (planeCollider != null)
            {
                Vector3 planeMin = planeCollider.bounds.min;
                Vector3 planeMax = planeCollider.bounds.max;

                boundaryMin = new Vector2(planeMin.x, planeMin.z);
                boundaryMax = new Vector2(planeMax.x, planeMax.z);
            }
        }
        else
        {
            Debug.LogError("Plane not found in the scene. Please ensure there is a GameObject named 'Plane' with a Collider.");
        }
    }

    void Start()
    {
        currentEnergy = maxEnergy;
        if (staminaBar != null)
        {
            staminaBar.maxValue = maxEnergy;
            staminaBar.value = currentEnergy;
        }
        else
        {
            Debug.LogError("Stamina Bar is not assigned in the Inspector.");
        }
    }

    private void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        inputX = Input.GetAxis("Horizontal");
        inputY = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(inputX, 0f, inputY).normalized;

        bool runInput = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);
        bool canRun = runInput && currentEnergy > 0 && direction.magnitude > 0.1f;

        if (canRun)
        {
            currentEnergy -= energyCostPerSecond * Time.deltaTime;
            if (currentEnergy < 0)
            {
                currentEnergy = 0;
            }
        }
        else
        {
            currentEnergy += energyRecoveryRate * Time.deltaTime;
            if (currentEnergy > maxEnergy)
            {
                currentEnergy = maxEnergy;
            }
        }

        staminaBar.value = currentEnergy;

        float currentSpeed = canRun ? runSpeed : walkSpeed;

        if (direction.magnitude >= 0.1f)
        {
            Vector3 move = direction * currentSpeed * Time.deltaTime;

            velocity.y += gravity * Time.deltaTime;
            move.y = velocity.y * Time.deltaTime;

            Vector3 newPosition = transform.position + move;

            newPosition.x = Mathf.Clamp(newPosition.x, boundaryMin.x, boundaryMax.x);
            newPosition.z = Mathf.Clamp(newPosition.z, boundaryMin.y, boundaryMax.y);

            controller.Move(newPosition - transform.position);
        }

        bool isMoving = direction.magnitude > 0.1f;

<<<<<<< HEAD
        // ตั้งค่าพารามิเตอร์ของ Animatoroluหกหหห้้
=======
        // ตั้งค่าพารามิเตอร์ของ Animatoroluหกห
>>>>>>> 4696b61db6ee38fa2703c16eaac28bb3f3b90c63
        anim.SetBool("Walk", isMoving && !canRun);
        anim.SetBool("Run", isMoving && canRun);
        anim.SetBool("Moving", isMoving);

        if (isMoving)
        {
            float angle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            Quaternion toRotation = Quaternion.AngleAxis(angle, Vector3.up);
            transform.rotation = Quaternion.Slerp(transform.rotation, toRotation, Time.deltaTime * 15f);
        }
        else
        {
            // รีเซ็ตความเร็วในกรณีที่ไม่เคลื่อนที่ssasasdasdasdasdas
            velocity = Vector3.zero;
        }
    }
}
