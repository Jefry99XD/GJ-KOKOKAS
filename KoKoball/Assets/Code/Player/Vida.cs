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


    public void healthMax(int max) { 
        slider.maxValue = max;
    }

    public  void health(int valueH) {
        slider.value = valueH;
    }

    public  void IHealthSilder(int value)
    {
        healthMax(value);
        health(value);
    }
}
