using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform Player;

    void Update()
    {
        if (Player.position.x > -10 && Player.position.x < 100)
        {
            transform.position = new Vector3(Player.position.x, 0, -10);
        }

        if (Player.position.x <= -8 || Player.position.x >= 10)
        {
            Camera.main.orthographicSize = 6;
        }
        else{Camera.main.orthographicSize = 5;}
    }
}
