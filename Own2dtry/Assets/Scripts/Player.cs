using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    Rigidbody2D rb;
    public float speed;
    float moveinput;
    public float jumpforce;

    public bool facingright = true;
    
    public bool isGrounded;
    public Transform ground;
    public float checkradius;
    public LayerMask groundlayer;

    private int extrajump;
    public int extrajumpvalue;
    private void Start()
    {
        extrajump = extrajumpvalue;
        rb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(ground.position,checkradius,groundlayer);

        moveinput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveinput * speed, rb.velocity.y) * Time.fixedDeltaTime;

        if (facingright == true && moveinput > 0)
        {
            Flip();
        }
        else if(facingright == false && moveinput < 0)
        {
            Flip();
        }
    }
    private void Update()
    {
        if(isGrounded == true)
        {
            extrajump = extrajumpvalue;
        }
        if(Input.GetKeyDown(KeyCode.Space) && extrajump > 0)
        {
            rb.velocity = Vector2.up * jumpforce;
            extrajump--;
        }
        else if(Input.GetKeyDown(KeyCode.Space)&& extrajump == 0 && isGrounded == true)
        {
            rb.velocity = Vector2.up * jumpforce;
        }
    }
    void Flip()
    {
        facingright = !facingright;
        Vector2 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
    }
}
