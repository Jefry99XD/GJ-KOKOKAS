using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{

    [SerializeField] float spawnRate = 1f;
    [SerializeField] GameObject[] enemyPref;
    [SerializeField] bool spawn = true;


    // Start is called before the first frame update
    void Start() {
        StartCoroutine(Spawner());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator Spawner() {
        WaitForSeconds wait = new WaitForSeconds(spawnRate);
        while (spawn)
        {
            yield return wait;
            int rand = Random.Range(0, enemyPref.Length);
            GameObject enemy = enemyPref[rand];
            Instantiate(enemy, transform.position, Quaternion.identity);


        }

    }
}
