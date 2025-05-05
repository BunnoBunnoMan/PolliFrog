using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Vector2 movement;
    public Rigidbody2D bodydump; //I go down da body dump, weeeeeeeeeeeeeeeeeeeeeeeeeeeeeooooooooooooooooooooohhhhhh
    public float moveSpeed;
    public float topSpeed;
    public int yumpForce;
    public int yumpGrav;
    private bool moving = false;
    private bool yumpies = false;
    private bool yumping = false;
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        if (Input.GetAxisRaw("Horizontal") != 0) moving = true;
        else moving = false;
        if (Input.GetKeyDown(KeyCode.W)) yumpies = true;
        else if (Input.GetKeyUp(KeyCode.W)) yumpies = false;

    }
    private void FixedUpdate()
    {
        movement = Vector2.ClampMagnitude(movement, 1);
        if (!yumping) bodydump.AddForce(movement * moveSpeed);
        else if (yumping) bodydump.AddForce(movement * (moveSpeed / 5));
        if (yumpies && !yumping) bodydump.AddForceY(yumpForce, ForceMode2D.Impulse);
        /*--------------------Top-Speed-&-Dampening--------------------*/
        if (bodydump.linearVelocityX > topSpeed) bodydump.linearVelocityX = topSpeed;
        else if (bodydump.linearVelocityX < -topSpeed) bodydump.linearVelocityX = -topSpeed;
        if ((bodydump.linearVelocityX > 0 || bodydump.linearVelocityX < -1) && !yumping && !moving) bodydump.linearDamping = topSpeed/2;
        else bodydump.linearDamping = 0;
        /*---------------------Yumping-Regulations---------------------*/
        if (yumping && !yumpies) bodydump.gravityScale = yumpGrav;
        else bodydump.gravityScale = 1;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.tag != "Enemy") yumping = false;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        yumping = true;
    }
}
