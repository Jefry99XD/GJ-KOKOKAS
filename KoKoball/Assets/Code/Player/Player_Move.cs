using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float speed = 11f;
    private Rigidbody2D body;

    [SerializeField] GameObject attackHitBox;
    private Animator animator;
    private bool lookingLeft = true;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        Vector2 positionPlayer = transform.position;

        positionPlayer = positionPlayer + new Vector2(horizontal, 0f) * speed * Time.deltaTime;
        transform.position = positionPlayer;

        if (horizontal > 0 && lookingLeft) { girar();}
        else if (horizontal < 0 && !lookingLeft) { girar();}

        animator.SetFloat("Movement", Mathf.Abs(horizontal));

        if (Input.GetKeyDown(KeyCode.Space))
        {   
            attackHitBox.SetActive(true);
            animator.SetBool("attacking", true);
        }
    }

    private void girar()
    {
        lookingLeft = !lookingLeft;
        Vector3 escala = transform.localScale;
        escala.x *= -1;
        transform.localScale = escala;
    }

    public void disableAttack()
    {
        attackHitBox.SetActive(false);
        animator.SetBool("attacking", false);
    }
}
