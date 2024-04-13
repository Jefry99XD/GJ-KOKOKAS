using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealhM : MonoBehaviour
{
    [SerializeField]
    private int health;
    [SerializeField]
    private int healthMax;
    [SerializeField] private Player_health healthSlider;
    // Start is called before the first frame update
    void Start()
    {
        health = healthMax;
        healthSlider.IHealthSilder(health);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void damage(int damageV)
    {
        health -= damageV;
        healthSlider.health(health);
    
    }

    void healing(int healingV) {
        health += healingV;
        healthSlider.health(health);
    }
}
