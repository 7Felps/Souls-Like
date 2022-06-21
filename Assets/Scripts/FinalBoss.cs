using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalBoss : MonoBehaviour
{
    public bool Move = false;
    public float Timer;
    public float Action;
    public Vector3 Target;

    public GameObject Arrow;
    public GameObject Spell;
    public Transform Bow;
    public Transform Staff;

    public SpriteRenderer Caronte1;
    public SpriteRenderer Caronte2;
    public SpriteRenderer Caronte3;
    public SpriteRenderer Crystal1;
    public SpriteRenderer Crystal2;
    public SpriteRenderer Crystal3;
    public Color Color1;
    public Color Color2;

    void Start()
    {
        Action = -1;
        StartCoroutine(DelayRoutine());
    }

    private void Update() 
    {
        Timer = Mathf.PingPong(Time.time, 3);
        Camera.main.backgroundColor = Color.Lerp(Color1, Color2, Timer);
        Caronte1.color = Color.Lerp(Color1, Color2, Timer);
        Caronte2.color = Color.Lerp(Color1, Color2, Timer);
        Caronte3.color = Color.Lerp(Color1, Color2, Timer);

        if (Move == true)
        {
            if (Action == 0) {Crystal1.color = Color.Lerp(Color1, Color2, Timer);}
            if (Action == 1) {Crystal2.color = Color.Lerp(Color1, Color2, Timer);}
            if (Action == 2) {Crystal3.color = Color.Lerp(Color1, Color2, Timer);}

            if(Timer <= 0.001f)
            {
                Target = new Vector3(Random.Range(-8, 8), 3, 0);
                transform.position = Target;

                Action = Random.Range(0, 3);
                if (Action == 0) 
                {
                    transform.position += new Vector3(0, -6.9f, 0);
                }
                if (Action == 1) 
                {
                    for (int i = 0; i < 1; i++)
                    {    
                        Instantiate(Arrow, Bow.position, Quaternion.identity);
                    }
                }
                if (Action == 2) 
                {
                    for (int i = 0; i < 1; i++)
                    {  
                        Instantiate(Spell, Staff.position, Quaternion.identity);
                    }
                }
            }
        }
    }

    IEnumerator DelayRoutine()
    {
        yield return new WaitForSeconds(2f);
        Move = true;
    }

    private void OnCollisionEnter2D(Collision2D Col)
    {
        if (Col.gameObject.tag == "Special")
        {
            Health.Instance.DoDamage(10);
        }
    }
}
