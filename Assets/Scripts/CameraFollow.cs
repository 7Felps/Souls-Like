using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class CameraFollow : MonoBehaviour
{
    public Transform Player;

    public SpriteRenderer Crystal;
    public Color Color1;
    public Color Color2;

    private void Start() 
    { 
        if (SceneManager.GetActiveScene().name == "Hub2" || SceneManager.GetActiveScene().name == "Hub3" 
            || SceneManager.GetActiveScene().name == "Travelling")
        {
            PlayerController.Instance.Pause = true;
            StartCoroutine(MoveCamera());
        }
    }

    void FixedUpdate()
    {
        if (Player.position.x > -10 && Player.position.x < 120 && PlayerController.Instance.Pause == false)
        {
            transform.position = new Vector3(Player.position.x, 0, -10);
        }

        if (Player.position.x <= -8 || Player.position.x >= 10)
        {
            Camera.main.orthographicSize = 6;
        }
        else{Camera.main.orthographicSize = 5;}

        Crystal.color = Color.Lerp(Color1, Color2, 0.15f * Time.time);
    }

    IEnumerator MoveCamera()
    {
        yield return new WaitForSeconds(4);
        PlayerController.Instance.Pause = false;
    }
}
