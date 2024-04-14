using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealhM : MonoBehaviour
{
    public HUD hud;
    private int vidas = 5;
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
            SceneManager.LoadScene(2);
        }
        vidas--;
        hud.quitarVida(vidas);

    
    }

    public void healing(int healingV) {
        if (health < healthMax)
        {
            health += healingV; healthSlider.health(health);
        }
        vidas ++;
        hud.agregarVida(vidas);
       

    }
}
