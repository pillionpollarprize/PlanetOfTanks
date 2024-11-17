using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public bool isPlayer1 = true;
    [Header("Movement")]
    public float speed = 10;
    [Header("Shooting")]
    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    public float fireRate = 0.5f;
    public AudioClip bulletSound;
    public AudioSource audsrc;

    void Start()
    {
        InvokeRepeating("Shoot", 0, fireRate);
        audsrc = GetComponent<AudioSource>();
    }
    private void Shoot()
    {
        Instantiate(bulletPrefab, bulletSpawn.position, transform.rotation);
        audsrc.pitch = Random.Range(0.8f, 1.1f);
        audsrc.PlayOneShot(bulletSound);
    }
    void Update()
    {
        var input = new Vector3();

        if (isPlayer1)
        {
            input.x = Input.GetAxis("HorizontalKeys");
            input.z = Input.GetAxis("VerticalKeys");
        }
        else
        {
            input.x = Input.GetAxis("HorizontalArrows");
            input.z = Input.GetAxis("VerticalArrows");
        }
        transform.position += input * speed * Time.deltaTime;

        if(input != Vector3.zero)
        {
            transform.forward = input;
        }
    }
}
