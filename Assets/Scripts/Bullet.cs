using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float Speed = 10;

    private Vector2 Direction;
    private bool CanGetDirection;

    public Rigidbody2D RB;

    private void Start()
    {
        if (PlayerController.Instance.X >= 0)
        {
            transform.position = PlayerController.Instance.gameObject.transform.position + new Vector3(1,0,0);
            Direction = Vector2.right;
        }
        if (PlayerController.Instance.X < 0)
        {
            transform.position = PlayerController.Instance.gameObject.transform.position + new Vector3(-1,0,0);
            Direction = Vector2.left;
        }   
    }

    private void FixedUpdate() 
    {
        if (CanGetDirection == true)
        {
            Start();
            CanGetDirection = false;
        }

        RB.velocity = Direction * Speed;
    }

    private void OnCollisionEnter2D(Collision2D Col) 
    {
        if (Col.gameObject.tag == "Respawn" || Col.gameObject.tag == "Enemy")
        {
            gameObject.SetActive(false);
            CanGetDirection = true;
        }
    }
}
