using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float Speed = 5;
    private Rigidbody2D RB;
    private Vector3 Target;

    private void Start() 
    {
        Target = new Vector3(Random.Range(-8.4f, 8.4f), -4.4f, 0);
    }

    void Update()
    {
        if (transform.position == Target)
        {
            Target = new Vector3(Random.Range(-8.4f, 8.4f), -4.4f, 0);
        }

        transform.position = Vector3.MoveTowards(transform.position, Target, Speed * Time.deltaTime);
    }
}
