using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] Rigidbody2D rigid;
    [SerializeField] float movement;
    [SerializeField] public const int SPEED = 15;
    [SerializeField] bool isFacingRight = true;
    [SerializeField] const float JUMPFORCE = 600.0f;
    [SerializeField] bool jumpPressed = false;
    [SerializeField] bool isGrounded = true;

    private Vector3 initialPosition;
    public GameObject pinPrefab;
    public float shootingSpeed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        if (rigid == null)
            rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        movement = Input.GetAxis("Horizontal");
        if (Input.GetButtonDown("Jump"))
            jumpPressed = true;

        if(Input.GetButtonDown("Fire1"))
        {
            ShootPin();
        }
    }

    //can be called potentially many times per frame -- best for physics
    void FixedUpdate()
    {
           rigid.velocity = new Vector2 (movement * SPEED, rigid.velocity.y); 
           if (movement < 0 && isFacingRight || movement > 0 && !isFacingRight)
           {
                Flip();
           }
           if (jumpPressed && isGrounded)
            Jump();
    }

    void Flip()
    {
        transform.Rotate(0, 180, 0);
        isFacingRight = !isFacingRight;
    }

    void Jump()
    {
        rigid.velocity = new Vector2 (rigid.velocity.x, 0);
        rigid.AddForce(new Vector2 (0, JUMPFORCE));
        jumpPressed = false;
        isGrounded = false;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag  == "Ground")
        {
            isGrounded = true;
            jumpPressed = false;
        }
    }

    void ShootPin()
    {
        Vector3 playerPosition = transform.position; // Get the player's position
        GameObject pin = Instantiate(pinPrefab, playerPosition, Quaternion.identity);

        // Calculate the shooting direction based on player's facing direction
        Vector3 shootingDirection = isFacingRight ? Vector3.right : Vector3.left;

        // Get the PinMovement script and set the shooting direction
        PinMovement pinMovement = pin.GetComponent<PinMovement>();
        if (pinMovement != null)
        {
            pinMovement.SetShootDirection(shootingDirection);
        }
    }

    public void Respawn()
    {
    transform.position = initialPosition;
    }
    // void OnTriggerEnter2D(Collider2D other)
    // {
    //     if (other.CompareTag("Balloon"))
    //     {
    //     Respawn();
    //     }
    // }



}
