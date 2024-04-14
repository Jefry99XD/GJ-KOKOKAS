using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_health : MonoBehaviour
{
    private  Slider slider;
// Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
    }


    public void healthMax(int maxV) { 
        slider.maxValue = maxV;
    }

    public  void health(int valueH) {
        slider.value = valueH;
    }

    public  void IHealthSilder(int v)
    {
        healthMax(v);
        health(v);
    }
}
