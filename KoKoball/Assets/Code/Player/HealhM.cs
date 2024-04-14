using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealhM : MonoBehaviour
{
   // [SerializeField]
    private int health;
   // [SerializeField]
    private int healthMax;
    [SerializeField]
    public Player_health healthSlider;
    // Start is called before the first frame update
    void Start()
    {
        //healthMax = 10;
        //health = healthMax;

        healthMax = healthSlider.IHealthSilder();
        health = healthMax;
    }

    // Update is called once per frame
    void Update()
    {
        healthSlider.health(health);
      
    }

    public void damage(int damageV)
    {
        health -= damageV;
        if (health <= 0) {
            print("HAs perdido");
        }

    
    }

    public void healing(int healingV) {
        health += healingV; healthSlider.health(health);
       

    }
}
