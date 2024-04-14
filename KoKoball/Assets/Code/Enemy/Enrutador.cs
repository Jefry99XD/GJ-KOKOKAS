using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enrutador : MonoBehaviour
{
    [SerializeField] Transform[] ruta;
    [SerializeField] float velocidadMovimiento;
    [SerializeField] int destino;
    [SerializeField] GameObject[] enemies;

    private void Update()
    {
        for (int i = 0; i < enemies.Length; i++)
        {
            enrutar(enemies[i].transform);
        }
    }

    public void enrutar(Transform enemigo)
    {
        int next = Random.Range(0, ruta.Length - 1);
        enemigo.position = Vector2.MoveTowards(enemigo.position, ruta[destino].position, velocidadMovimiento * Time.deltaTime);
        if (Vector2.Distance(enemigo.position, ruta[destino].position) < .2f)
        {
            enemigo.localScale = new Vector3(1, 1, 1);
            destino = next;
        }
    }
}
