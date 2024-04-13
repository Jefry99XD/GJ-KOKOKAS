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

    }
    public void Danio()
    {
        health--;
        if (health <= 0)
        {
            Destroy(parent);
        }
    }
}
