using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    private Health playerHealth;
    private bool block = false;
    public TextMeshProUGUI decided;
    public TextMeshProUGUI replayIn;
    public int timeUntilReplay = 5;
    void Start()
    {
        InvokeRepeating("Shoot", 0, fireRate);
        audsrc = GetComponent<AudioSource>();
        decided.gameObject.SetActive(false);
        replayIn.gameObject.SetActive(false);
        playerHealth = FindObjectOfType<Health>();

    }
    private void Shoot()
    {
        Instantiate(bulletPrefab, bulletSpawn.position, transform.rotation);
        audsrc.pitch = Random.Range(0.8f, 1.1f);
        audsrc.PlayOneShot(bulletSound);
    }
    private void Decider()
    {
        decided.gameObject.SetActive(true);
        replayIn.gameObject.SetActive(true);
        if (isPlayer1)
        {
            decided.text = "Player 1 won!";
        }
        else
        {
            decided.text = "Player 2 won!";
        }
        InvokeRepeating("Replay", 0, 1);

    }
    private void Replay()
    {
        if (timeUntilReplay > 0)
        {
            replayIn.text = "Replaying in: " + timeUntilReplay;
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        timeUntilReplay--;
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
        if (playerHealth.health <= 0 && block == false) 
        {
            Decider();
            block = true;
        }
            
    }
}
