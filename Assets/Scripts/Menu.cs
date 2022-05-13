using UnityEngine;
using UnityEngine.Audio;

public class Menu : MonoBehaviour
{
    public GameObject PauseMenu;
    public AudioMixer AudioMixer;
    
    void Update() 
    {
        if (Input.GetButtonDown("Start")) 
        {
            Time.timeScale = 0;
            PauseMenu.SetActive(true);
            PlayerController.Instance.Pause = true;
        }
    }

    public void Resume() 
    {
        Time.timeScale = 1;
        PauseMenu.SetActive(false);
        PlayerController.Instance.Pause = false;
    }

    public void SetVolume(float volume) 
    {
        AudioMixer.SetFloat("Volume", volume);
    }

    public void Quit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}