using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell : MonoBehaviour
{
    public float speed;

    private Transform player;

    private Transform Enemy;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        Enemy = GameObject.FindGameObjectWithTag("Enemy").transform;
        Physics2D.IgnoreCollision(this.GetComponent<Collider2D>(), Enemy.GetComponent<Collider2D>());
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Respawn")
        {
            DeleteProjectile();
        }
    }

    void DeleteProjectile()
    {
        Destroy(this.gameObject);
    }
}
