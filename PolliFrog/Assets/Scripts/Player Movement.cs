using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public BoxCollider2D collider;
    public int topSpeed;
    public int moveSpeed;
    private Vector2 movement;
    private bool yump = false;
    private bool yumping = false;
    private Vector2 xMove;
    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        if (Input.GetKeyDown(KeyCode.W))
        {
            yump = true;
        }
        else if (Input.GetKeyUp(KeyCode.W)) yump = false;
        
    }
    private void FixedUpdate()
    {
        movement = Vector2.ClampMagnitude(movement, 1);
        rb.AddForce(movement * moveSpeed);
        //Debug.Log(movement * moveSpeed);
        Debug.Log(rb.linearVelocityX);
        if (yump && yumping == false) rb.AddForceY(5, ForceMode2D.Impulse);
        if (rb.linearVelocityX > topSpeed) rb.linearVelocityX = topSpeed;
        else if (rb.linearVelocityX < -topSpeed) rb.linearVelocityX = -topSpeed;
    }

    public void OnCollisionEnter2D(Collision2D coll)
    {
        yumping = false;
    }
    public void OnCollisionExit2D(Collision2D collision)
    {
        yumping = true;
    }


}
