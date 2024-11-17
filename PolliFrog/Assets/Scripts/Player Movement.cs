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
        if (yump && yumping == false) rb.AddForceY(20 * moveSpeed);
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
