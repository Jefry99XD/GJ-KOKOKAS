using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUD : MonoBehaviour
{
    public GameObject[] vidas;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void quitarVida(int i) {
        vidas[i].SetActive(false);
    }

    public void agregarVida(int i)
    {
        vidas[i].SetActive(true);
    }
}
