using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickUp : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        var health = collision.gameObject.GetComponent<Health>();
        if (health != null)
        {
            //negative damage = healing
            health.TakeDamage(-40);
            Destroy(gameObject);
        } 
    }
}
