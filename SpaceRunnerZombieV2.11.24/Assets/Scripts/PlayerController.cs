using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 10;
    private Vector3 move;

    public float gravity = -10f;
    public float jumpHeight = 7f;
    private Vector3 velocity;

    public Transform groundCheck;
    public LayerMask groundLayer;
    private bool isGrounded;

    InputAction movement;
    InputAction jump;


    public int maxHealth = 100;
    private int currentHealth;

    public Slider healthBar;
    // private Animator animator;
    //private AudioSource footStepAudio;

    void Start()
    {
        currentHealth = maxHealth;
        // Set health bar to full
        healthBar.maxValue = maxHealth;
        healthBar.value = currentHealth;

        // playerAnim = GetComponent<Animator>();

        jump = new InputAction("Jump", binding: "<keyboard>/space");
        jump.AddBinding("<Gamepad>/a"); // For gamepad

        movement = new InputAction("PlayerMovement", binding: "<Gamepad>/leftStick");
        movement.AddCompositeBinding("Dpad")
           .With("Up", "<keyboard>/w")
           .With("Up", "<keyboard>/upArrow")
           .With("Down", "<keyboard>/s")
           .With("Down", "<keyboard>/downArrow")
           .With("Left", "<keyboard>/a")
           .With("Left", "<keyboard>/leftArrow")
           .With("Right", "<keyboard>/d")
           .With("Right", "<keyboard>/rightArrow");

        movement.Enable();
        jump.Enable();
    }

    void Update()
    {
        float x = movement.ReadValue<Vector2>().x;
        float z = movement.ReadValue<Vector2>().y;

     //   animator.SetFloat("Speed", Mathf.Abs(x) + Mathf.Abs(z));

        move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);

        // Ground check
        isGrounded = Physics.CheckSphere(groundCheck.position, 0.3f, groundLayer);

        // Reset velocity when grounded
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = 0f; // Set to 0 to avoid small jumps on the ground
        }

        // Jump logic
        if (isGrounded && Mathf.Approximately(jump.ReadValue<float>(), 1))
        {
            Jump();
        }

        // Apply gravity
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    private void Jump()
    {
        velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
    }

    private void UpdateAnimator(float x, float z)
    {
        float speedMagnitude = new Vector3(x, 0, z).magnitude;
      //  playerAnim.SetFloat("Speed", speedMagnitude);
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0 , maxHealth);

        healthBar.value = currentHealth;

        Debug.Log("Player Health : " + currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }
    private void Die()
    {
        Debug.Log("Player has dead!!!!!!!!!!!!!!!!!!!");
    }
    /*  private void PlayFootStepSound(float x ,float y)
      {
          if (isGrounded && (Mathf.Abs(x) > 0.1f || Mathf.Abs(y) > 0.1f))
          {
            /*  if (!footStepAudio.isPlaying)
              {
                  footStepAudio.Play();
              }
              */
    /*  }
      else
      {
        //  footStepAudio.Stop();
      }
 }*/
}
