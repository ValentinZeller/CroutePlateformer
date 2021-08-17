using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int baseHealth = 5;
    private int currentHealth;

    public Animator anim;
    public Rigidbody2D rb;
    public float jumpForce;
    public float playerSpeed;
    public Vector2 jumpHeight;

    private float orientation = 1;

    private bool isOnGround;
    public float positionRadius;
    public LayerMask ground;
    public List<Transform> playerPos;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = baseHealth;
        Collider2D[] colliders = transform.GetComponentsInChildren<Collider2D>();
        for (int i = 0; i < colliders.Length; i++)
        {
            for (int k = i + 1; k < colliders.Length; k++)
            {
                Physics2D.IgnoreCollision(colliders[i], colliders[k]);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Camera.main.transform.position.Set(transform.position.x,transform.position.y, Camera.main.transform.position.z);
        if (Input.GetAxis("Vertical") >= 0 && Input.GetAxisRaw("Horizontal") != 0)
        {
            if(Input.GetAxisRaw("Horizontal") > 0)
            {
                anim.Play("WalkBack");
                rb.AddForce(Vector2.right * playerSpeed * Time.deltaTime);
                orientation = Input.GetAxisRaw("Horizontal");
            } else
            {
                anim.Play("Walk");
                rb.AddForce(Vector2.left * playerSpeed * Time.deltaTime);
                orientation = Input.GetAxisRaw("Horizontal");
            }
        } else
        {
            anim.Play("Idle");
        }

        isOnGround = Physics2D.OverlapCircle(playerPos[0].position,positionRadius,ground) || Physics2D.OverlapCircle(playerPos[1].position, positionRadius, ground);
        if (isOnGround == true && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector2.up * jumpForce );
        }
    }

    public void Hurt(int value, float force)
    {
        currentHealth -= value;
        rb.AddForce(Vector2.left * force * orientation);
    }

}
