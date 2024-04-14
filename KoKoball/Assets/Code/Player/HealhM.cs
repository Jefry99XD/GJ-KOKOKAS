using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealhM : MonoBehaviour
{
    [SerializeField]
    private int health;
    [SerializeField]
    public int healthMax;
    [SerializeField] 
    private Player_health healthSlider;
    // Start is called before the first frame update
    void Start()
    {
        healthMax = 10;
        health = healthMax;
        healthSlider.IHealthSilder(health);
    }

    // Update is called once per frame
    void Update()
    {
        healthSlider.health(health);
      
    }

    public void damage(int damageV)
    {
        health -= damageV;
        healthSlider.health(health);
    
    }

    public void healing(int healingV) {
        health += healingV; healthSlider.health(health);
        healthSlider.health(health);

    }
}
