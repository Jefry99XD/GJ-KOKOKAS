using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float speed = 11f;
    private Rigidbody2D body;


    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        Vector2 positionPlayer = transform.position;

        positionPlayer = positionPlayer + new Vector2(horizontal, 0f) * speed * Time.deltaTime;
        transform.position = positionPlayer;

    }
}
