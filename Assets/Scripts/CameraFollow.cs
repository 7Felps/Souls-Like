using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class CameraFollow : MonoBehaviour
{
    public Transform Player;

    public SpriteRenderer Crystal;
    public SpriteRenderer Crystal2;
    public Color Color1;
    public Color Color2;

    public bool Wait = false;

    void Update()
    {
        if (Player.position.x > -10 && Player.position.x < 120 && Wait == true)
        {
            transform.position = new Vector3(Player.position.x, 0, -10);
        }

        if (Player.position.x <= -8 || Player.position.x >= 10)
        {
            Camera.main.orthographicSize = 6;
        }
        else{Camera.main.orthographicSize = 5;}

        if (SceneManager.GetActiveScene().name == "Hub2")
        {
            Crystal.color = Color.Lerp(Color1, Color2, Mathf.PingPong(Time.time, 3f) / 3f);
            StartCoroutine(MoveCamera());
        }
        if (SceneManager.GetActiveScene().name == "Hub3")
        {
            Crystal2.color = Color.Lerp(Color1, Color2, Mathf.PingPong(Time.time, 3f) / 3f);
            StartCoroutine(MoveCamera());
        }
    }

    IEnumerator MoveCamera()
    {

        yield return new WaitForSeconds(3);
        Wait = true;
    }
}
