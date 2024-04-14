using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_health : MonoBehaviour
{
    [SerializeField]
    private  Slider slider;
    private int max;

    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
        max = (int)slider.maxValue;
    }


    public void healthMax(int maxV) { 
        slider.maxValue = maxV;
        max = maxV;
    }

    public  void health(int valueH) {
        slider.value = valueH;
    }

    public int IHealthSilder()
    {
        max = (int)slider.maxValue;
        healthMax(max);
        health(max);
        return max;
    }
}
