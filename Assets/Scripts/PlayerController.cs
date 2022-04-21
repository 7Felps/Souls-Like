using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance; 

    public float X;
    public float Y;
    public float Speed = 5;
    public bool Rolled;
    
    public Rigidbody2D RB;
    public Animator Animator;
    public AudioSource AudioSource;

    private void Awake() 
    {
        if (Instance == null) {Instance = this;}
    }

    private void FixedUpdate() 
    {
        //Movimento
        X = Input.GetAxis("Horizontal");
        Y = Input.GetAxis("Vertical");
        transform.position += new Vector3(X, 0, 0) * Speed * Time.deltaTime;
        Animator.SetFloat("IsWalking", Mathf.Abs(X));
    }

    void Update()
    {
        //Não Pausado
        if (Time.timeScale == 1)
        {
            //Pulo
            if (Input.GetButtonDown("Jump") && Mathf.Abs(RB.velocity.y) < 0.001f)
            {
                RB.AddForce(new Vector2(0, Speed), ForceMode2D.Impulse);
                Animator.SetBool("IsJumping", true);
                AudioSource.PlayOneShot(AudioSource.clip);
            }
            if (Mathf.Abs(RB.velocity.y) < 0.001f) {Animator.SetBool("IsJumping", false);}

            //rolamento
            if (Input.GetButtonDown("Fire3") && Animator.GetBool("IsRolling") == false)
            {
                if (X > 0) {RB.AddForce(new Vector2(Speed, 0), ForceMode2D.Impulse);}
                if (X < 0) {RB.AddForce(new Vector2(-Speed, 0), ForceMode2D.Impulse);}
                Animator.SetBool("IsRolling", true);
                AudioSource.PlayOneShot(AudioSource.clip);
            } 
            if (Rolled == true) {Animator.SetBool("IsRolling", false);}
            if (Animator.GetBool("IsRolling") == true) {Physics2D.IgnoreLayerCollision(7, 6, true);}
            if (Animator.GetBool("IsRolling") == false) {Physics2D.IgnoreLayerCollision(7, 6, false);}

            //atirar
            if (Input.GetButtonDown("Fire1"))
            {
                GameObject Bullet = ObjectPool.Instance.GetPooledObject();
                if (Bullet != null) {Bullet.SetActive(true);}
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D Col) 
    {
        if (Col.gameObject.tag == "Enemy")
        {
            Health.Instance.TakeDamage(1);
            Animator.SetBool("IsTakingHit", true);
        }
        
    }

    private void OnCollisionExit2D(Collision2D other) 
    {
        Animator.SetBool("IsTakingHit", false);
    }
}