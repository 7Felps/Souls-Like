using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public static Health Instance; 
    
    public Slider Slider;
    public float HealthPoints = 3;

    public bool Dead = false;
    public Animator Transition;
    
    private void Awake() 
    {
        if (Instance == null) {Instance = this;}
    }

    private void Start() 
    {
        Slider.maxValue = HealthPoints;
    }

    void Update()
    {
        Slider.value = HealthPoints;

        if (Dead == true)
        {
            StartCoroutine(LoadLevel());
        }
    }

    public void TakeDamage(int Damage)
    {
        HealthPoints -= Damage;
        if (HealthPoints < 1) {Dead = true;}
    }

    IEnumerator LoadLevel()
    {
        Transition.SetBool("Start", true);
    
        yield return new WaitForSeconds(1);

        SceneManager.LoadScene(0);

        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            SceneManager.LoadScene(1);
        }
    }
}
