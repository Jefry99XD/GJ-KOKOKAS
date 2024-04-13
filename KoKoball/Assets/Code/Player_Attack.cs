using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Attack : MonoBehaviour
{
    [SerializeField] GameObject attackHitBox;
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            attackHitBox.SetActive(true);
            animator.SetBool("attacking", true);
        }
    }

    public void disableAttack()
    {
        attackHitBox.SetActive(false);
        animator.SetBool("attacking", false);
    }
}
