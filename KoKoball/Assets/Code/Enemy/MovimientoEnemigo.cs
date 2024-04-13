using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoEnemigo : MonoBehaviour
{
    [SerializeField] Transform[] ruta;
    [SerializeField] float velocidadMovimiento;
    [SerializeField] int destino;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int next = Random.Range(0, ruta.Length-1);
        transform.position = Vector2.MoveTowards(transform.position, ruta[destino].position, velocidadMovimiento * Time.deltaTime);
        if (Vector2.Distance(transform.position, ruta[destino].position) < .2f)
        {
            transform.localScale = new Vector3(1, 1, 1);
            destino = next;
        }


        //if (destino == 0)
        //{
        //    transform.position = Vector2.MoveTowards(transform.position, ruta[0].position, velocidadMovimiento * Time.deltaTime);
        //    if(Vector2.Distance(transform.position, ruta[0].position) < .2f)
        //    {
        //        transform.localScale = new Vector3(1, 1, 1);
        //        destino = 1;
        //    }
        //}
        //if (destino == 1)
        //{
        //    transform.position = Vector2.MoveTowards(transform.position, ruta[1].position, velocidadMovimiento * Time.deltaTime);
        //    if (Vector2.Distance(transform.position, ruta[1].position) < .2f)
        //    {
        //        transform.localScale = new Vector3(-1, 1, 1);
        //        destino = 0;
        //    }
        //}
    }
}
