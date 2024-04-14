using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioStop : MonoBehaviour
{
    

    // Start is called before the first frame update
    void Start()
    {
        GameObject[] musica = GameObject.FindGameObjectsWithTag("musica");
        if (musica.Length > 1)
        {
            Destroy(this.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
