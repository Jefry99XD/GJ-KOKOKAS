using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    bool friendly = false;
    [SerializeField] float kickForce = 10f;
    private GameObject soccerBall;
    private bool holding = false;
    private float timer = 0f;

    // Update is called once per frame
    void Update()
    {
        if (holding)
        {
            timer += Time.deltaTime;
            if (timer >= 1)
            {
                holding = false;
                timer = 0f;
                if (Random.Range(0, 2) == 1) {
                    GameObject[] objetosConTag = GameObject.FindGameObjectsWithTag("enemy");
                    int aleatorio = Random.Range(0, objetosConTag.Length);

                    while (objetosConTag[aleatorio] == gameObject)
                    {
                        aleatorio = Random.Range(0, objetosConTag.Length);
                    }

                    shoot(objetosConTag[aleatorio]);
                }
                else { shoot(GameObject.FindGameObjectWithTag("Player")); }
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("bola"))
        {
            soccerBall = collision.gameObject;
            soccerBall.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            soccerBall.GetComponent<Rigidbody2D>().simulated = false;
            soccerBall.transform.SetParent(transform, false);
            soccerBall.transform.position = transform.position;
            holding = true;
        }
    }

    private void shoot(GameObject obj) {
        soccerBall.GetComponent<Rigidbody2D>().simulated = true;
        soccerBall.transform.SetParent(null);
        soccerBall.transform.position = new Vector2 (transform.position.x, transform.position.y-2);

        Vector2 direccion = (obj.transform.position - soccerBall.transform.position).normalized;

        soccerBall.GetComponent<Rigidbody2D>().velocity = direccion * kickForce;
    }
}
