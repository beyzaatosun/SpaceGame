using System;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    Rigidbody2D rb2d;
    Animator animator;
    Vector2 velocity;

    [SerializeField] private float speed = default;
    [SerializeField] private float acceleration = default;
    [SerializeField] private float deceleration  = default;
    [SerializeField] private float jumpPower  = default;
    [SerializeField] private int jumpLimit   = 3;
    [SerializeField] private int jumpCount;

    private Joystick joystick;
    JoystickButton joystickButton;
    private bool jumping;

    
    void Start()
    {
        joystickButton = FindObjectOfType<JoystickButton>();
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        joystick = FindObjectOfType<Joystick>();
    }

    // Update is called once per frame
    void Update()
    {
#if UNITY_EDITOR
        KeyboardControl();  
#else
        JoystickControl();
#endif
       

    }

    void KeyboardControl()
    {
        float moveInput = Input.GetAxisRaw("Horizontal");
        Vector2 scale = transform.localScale;
        if (moveInput > 0)
        {
            velocity.x = Mathf.MoveTowards(velocity.x, moveInput * speed, acceleration * Time.deltaTime);
            animator.SetBool("Walk", true);
            scale.x = 0.3f;
        }
        
        else if (moveInput < 0)
        {
            velocity.x = Mathf.MoveTowards(velocity.x, moveInput * speed, acceleration * Time.deltaTime);
            animator.SetBool("Walk", true);
            scale.x =- 0.3f;

        }
        else
        {
            velocity.x = Mathf.MoveTowards(velocity.x, 0,deceleration  * Time.deltaTime);
            animator.SetBool("Walk", false);

        }
        transform.localScale = scale;
        transform.Translate(velocity * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartJump();
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            StopJump();
        }

    }

    void JoystickControl()
    {
        float moveInput = joystick.Horizontal;
        Vector2 scale = transform.localScale;
        if (moveInput > 0)
        {
            velocity.x = Mathf.MoveTowards(velocity.x, moveInput * speed, acceleration * Time.deltaTime);
            animator.SetBool("Walk", true);
            scale.x = 0.3f;
        }
        
        else if (moveInput < 0)
        {
            velocity.x = Mathf.MoveTowards(velocity.x, moveInput * speed, acceleration * Time.deltaTime);
            animator.SetBool("Walk", true);
            scale.x =- 0.3f;

        }
        else
        {
            velocity.x = Mathf.MoveTowards(velocity.x, 0,deceleration  * Time.deltaTime);
            animator.SetBool("Walk", false);

        }
        transform.localScale = scale;
        transform.Translate(velocity * Time.deltaTime);
        if (joystickButton.pressed == true && jumping ==false)
        {
            jumping = true;
            StartJump();
        }
        
        if (joystickButton.pressed == false && jumping == true)
        {
            jumping = false;

            StopJump();
        }
    }

    void StartJump()
    {
        if (jumpCount < jumpLimit)
        {
            FindObjectOfType<SoundControl>().JumpSound();
            rb2d.AddForce(new Vector2(0,jumpPower), ForceMode2D.Impulse);
            animator.SetBool("Jump", true);
            FindObjectOfType<SliderControl>().SliderValue(jumpLimit, jumpCount);
        }
        
        
    }

    void StopJump()
    {
        animator.SetBool("Jump", false);
        jumpCount++;
        FindObjectOfType<SliderControl>().SliderValue(jumpLimit, jumpCount);

    }

    public void RestJumpCount()
    {
        jumpCount = 0;
        FindObjectOfType<SliderControl>().SliderValue(jumpLimit, jumpCount);

    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Kill")
        {
            FindObjectOfType<GameControl>().FinishGame();
        }
    }

    public void FinishGame()
    {
        Destroy(gameObject);
    }
}
