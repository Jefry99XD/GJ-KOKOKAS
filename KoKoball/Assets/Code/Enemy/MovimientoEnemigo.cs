using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoEnemigo : MonoBehaviour
{
    [SerializeField] Transform[] ruta;
    [SerializeField] float velocidadMovimiento;
    [SerializeField] int destino;
    [SerializeField] float health, maxhealth = 3;
    [SerializeField] internal GameObject parent;
    private bool dying = false;
    private Animator animator;

    void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!dying)
        {
            int next = Random.Range(0, ruta.Length - 1);
            transform.position = Vector2.MoveTowards(transform.position, ruta[destino].position, velocidadMovimiento * Time.deltaTime);
            if (Vector2.Distance(transform.position, ruta[destino].position) < .2f)
            {
                transform.localScale = new Vector3(1, 1, 1);
                destino = next;
            }
        }

    }
    public void Danio()
    {
        health--;
        if (health <= 0)
        {
            animator.SetBool("kill", true);
            dying = true;
            gameObject.GetComponent<Collider2D>().enabled = false;
            transform.GetChild(1).gameObject.SetActive(false);
            StartCoroutine(dieAnimation());
        } else
        {
            animator.SetBool("hurt", true);
            StartCoroutine(takeDamage());
        }
    }

    IEnumerator takeDamage()
    {
        yield return new WaitForSeconds(1.1f);
        animator.SetBool("hurt", false);
    }
    IEnumerator dieAnimation()
    {
        yield return new WaitForSeconds(1.4f);
        animator.SetBool("kill", false);
        Destroy(gameObject.GetComponent<MovimientoEnemigo>());
        Destroy(gameObject);
        //Destroy(parent);
    }
}
