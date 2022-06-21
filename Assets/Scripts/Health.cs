using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public static Health Instance; 
    
    public Slider HealthBar;
    public float HealthPoints = 3;

    public Slider StaminaBar;
    public float StaminaPoints = 3;

    public Slider SpecialBar;
    public float SpecialPoints = 0;

    public Slider EnemyHealthBar;
    public float EnemyHP = 30;

    public bool Dead = false;
    
    public Animator Transition;
    
    private void Awake() 
    {
        if (Instance == null) {Instance = this;}
    }

    private void Start() 
    {
        HealthBar.maxValue = HealthPoints;
        StaminaBar.maxValue = StaminaPoints;
        EnemyHealthBar.maxValue = EnemyHP;
    }

    void Update()
    {
        HealthBar.value = HealthPoints;
        StaminaBar.value = StaminaPoints;
        SpecialBar.value = SpecialPoints;
        EnemyHealthBar.value = EnemyHP;

        if (StaminaBar.value < StaminaBar.maxValue && PlayerController.Instance.Pause == false)   
        {
            StaminaPoints += 0.008f;
        }

        if (Dead == true)
        {
            if (SceneManager.GetActiveScene().buildIndex != 0)
            {
                PlayerPrefs.SetInt("SavedScene", SceneManager.GetActiveScene().buildIndex);
            }
            StartCoroutine(LoadLevel());
        }
    }

    public void TakeDamage(float Damage)
    {
        HealthPoints -= Damage;
        if (HealthPoints <= 0) 
        {
            Dead = true;
        }
    }

    public void UseStamina(float Stamina)
    {
        if (StaminaPoints >= 0)
        {
            StaminaPoints -= Stamina;
        }
    }

    public void UseSpecial(float Points)
    {
        if (SpecialPoints >= 0)
        {
            SpecialPoints -= Points;
        }
    }

    public void GetSpecialPoints(float Points)
    {
        if (SpecialPoints < SpecialBar.maxValue)
        {
            SpecialPoints += Points;
        }
    }

    public void DoDamage(float Damage)
    {
        EnemyHP -= Damage;
        if (EnemyHP <= 0) 
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    IEnumerator LoadLevel()
    {
        Transition.SetBool("Start", true);
    
        yield return new WaitForSeconds(1);

        SceneManager.LoadScene(0);

        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            SceneManager.LoadScene(PlayerPrefs.GetInt("SavedScene"));
        }

        if (SceneManager.GetActiveScene().name == "Travelling")
        {
            SceneManager.LoadScene("FinalBoss");
        }
    }
}
