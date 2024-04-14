using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MovimientoEnemigo : MonoBehaviour
{
    [SerializeField] Transform[] ruta;
    [SerializeField] float velocidadMovimiento = 2;
    [SerializeField] int destino;
    [SerializeField] float health = 3;
    [SerializeField] AudioSource efecs;
    [SerializeField] bool healer = false;
    //[SerializeField] internal GameObject parent;
    private bool dying = false;
    private Animator animator;
    private Vector2 target;


    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        efecs.volume = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (!dying)
        {
            if (healer && health == 1)
            {
                Vector2 step = Vector2.MoveTowards(transform.position, target, velocidadMovimiento * Time.deltaTime);
                transform.position = step;
                if (Vector2.Distance(transform.position, target) < .01f)
                {
                    Danio();
                }
            }
            else
            {
                int next = Random.Range(0, ruta.Length - 1);
                Vector2 step = Vector2.MoveTowards(transform.position, ruta[destino].position, velocidadMovimiento * Time.deltaTime);
                transform.position = step;
                if (Vector2.Distance(transform.position, ruta[destino].position) < .2f)
                {
                    transform.localScale = new Vector3(1, 1, 1);
                    destino = next;
                }
            }
        }

    }

    public void setRuta(Transform[] ruta)
    {
        this.ruta = ruta;
    }

    public void setSpeed(float speed)
    {
        velocidadMovimiento = speed;
    }

    public bool getDying() {  return !dying; }
    public void Danio()
    {
        health--;
        if (health <= 0)
        {
            efecs.Play();
            animator.SetBool("kill", true);
            efecs.Play();
            dying = true;
            gameObject.GetComponent<Collider2D>().enabled = false;
            //transform.GetChild(1).gameObject.SetActive(false);
            StartCoroutine(dieAnimation());
        } else
        {
            animator.SetBool("hurt", true);
            StartCoroutine(takeDamage());
        }
        if (healer && health == 1)
        {
            velocidadMovimiento = 5;
            target = GameObject.FindGameObjectWithTag("Player").transform.position;
        }

    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<HealhM>().healing(1);
            Danio();
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
        ScoreManager.score += 1;

    }
}
