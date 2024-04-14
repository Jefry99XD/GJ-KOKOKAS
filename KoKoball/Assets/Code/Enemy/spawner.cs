using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class spawner : MonoBehaviour
{
    [SerializeField] float spawnRate = 1f;
    [SerializeField] GameObject[] enemyPref;
    [SerializeField] bool spawn = true;
    [SerializeField] GameObject soccerPrefab;
    [SerializeField] Transform[] ruta;
    [SerializeField] float kickForce;
    [SerializeField] AudioSource soccerSound;
    private List<GameObject> enemies = new List<GameObject>();
    bool readyToSpawn = false;


    // Start is called before the first frame update
    void Start() {
        for (int i = 0; i < enemyPref.Length; i++) {
            enemyPref[i].GetComponent<MovimientoEnemigo>().setRuta(ruta);
            enemyPref[i].GetComponent<MovimientoEnemigo>().setSpeed(2);
        }
        soccerPrefab.GetComponent<Soccer_Ball>().setter(kickForce, soccerSound);
        StartCoroutine(Spawner());
    }

    private void Update()
    {
        if (GameObject.FindWithTag("bola") == null)
        {
            int rand = Random.Range(0, ruta.Length);
            Instantiate(soccerPrefab, ruta[rand].position, Quaternion.identity);
        }
    }

    private IEnumerator Spawner() {
        while (spawn)
        {
            yield return new WaitForSeconds(spawnRate);
            int rand = Random.Range(0, enemyPref.Length);
            GameObject enemy = enemyPref[rand];
            rand = Random.Range(0, ruta.Length);
            Instantiate(enemy, ruta[rand].position, Quaternion.identity);
            readyToSpawn = true;
        }

    }

}
