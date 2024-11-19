using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public Transform healthBar;
    public int maxHealth = 100;

    private int health;
    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }
    public void TakeDamage(int damage)
    {
        health -= damage;
        health = Mathf.Max(health, 0); // not less than 0
        health = Mathf.Min(health, maxHealth); // not more than maxhealth
        healthBar.localScale = new Vector3((float)health/maxHealth, 1, 1);
    }
    //public void TakeHealth(int meds)
    //{
    //    health += meds;
    //    health = Mathf.Max(health, 0); // not less than 0
    //    health = Mathf.Min(health, maxHealth); // not more than maxhealth
    //    healthBar.localScale = new Vector3((float)health / maxHealth, 1, 1);
    //}
    // Update is called once per frame
    void Update()
    {
        
    }
}
