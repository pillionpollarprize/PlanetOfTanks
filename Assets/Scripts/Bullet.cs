using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject explosionPrefab;
    public float speed = 20f;
    public float lifetime = 2f;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("SelfDestruct", lifetime);
    }

    // Update is called once per frame
    void Update()
    {

        transform.position += transform.forward * speed * Time.deltaTime;
    }
    private void OnCollisionEnter(Collision collision)
    {
        //todo: explosion effect
        //todo: damage enemy
        var health = collision.gameObject.GetComponent<Health>();
        if (health != null)
        {
            health.TakeDamage(10);
        }

        SelfDestruct();
    }
    void SelfDestruct()
    {
        Instantiate(explosionPrefab, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
