using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform player;
    public Rigidbody2D camera;
    // Update is called once per frame
    void Update()
    {
        camera.MovePosition(player.position);
    }
}
