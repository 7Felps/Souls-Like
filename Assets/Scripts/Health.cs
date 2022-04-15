using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public static Health Instance; 
    public GameObject[] Sprite;
    private int HealthPoints;
    private bool Dead = false;
    
    private void Awake() 
    {
        if (Instance == null) {Instance = this;}
    }

    // Start is called before the first frame update   
    void Start() 
    {
        HealthPoints = Sprite.Length;
    }

    // Update is called once per frame
    void Update()
    {
        if (Dead == true)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    public void TakeDamage(int Damage)
    {
        HealthPoints -= Damage;
        Destroy(Sprite[HealthPoints].gameObject);
        if (HealthPoints < 1) {Dead = true;}
    }
}
