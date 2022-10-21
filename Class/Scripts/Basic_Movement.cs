using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Basic_Movement : MonoBehaviour
{
    public float speed = 0.08f;
    public GameObject player;
    public Transform playerTransfom;
    public Vector3 playerPos;

    public float playerx;
    public float playery;
    public float playerz;

    public int maxHealth = 100;
    public int currentHealth;

    public Health_Bar healthBar;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        playerTransfom.transform.position = new Vector3(playerx, playery, playerz);

        //transform.position += Vector3.forward * speed * Time.fixedDeltaTime;

        playerz += speed;


        if (Input.GetKeyDown(KeyCode.A))
        {
            if (playerx >= -2.0f)
            {
                //playerTransfom.transform.position = new Vector3(1, 0, 0);
                playerx -= 2.5f;
            }
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            if (playerx <= 2.0f)
            {
                //playerTransfom.transform.position = new Vector3(-1, 0, 0);
                playerx += 2.5f;
            }
        }

        if (playerx >= 2.5f)
        {
            playerx = 2.5f;
        }

        if (playerx <= -2.5f)
        {
            playerx = -2.5f;
        }

        if (currentHealth <= 0)
        {
            this.loadlevel("GameOver");
        }

    }

    public void moveLeft()
    {
        if (playerx >= -2.0f)
        {
            //playerTransfom.transform.position = new Vector3(1, 0, 0);
            playerx -= 2.5f;
        }
    }

    public void moveRight()
    {
        if (playerx <= 2.0f)
        {
            //playerTransfom.transform.position = new Vector3(-1, 0, 0);
            playerx += 2.5f;
        }
    }

    public void takeDamage(int damage)
    {
        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);
        Debug.Log("Damge");
    }


    public void loadlevel(string level)
    {
        SceneManager.LoadScene("GameOver");
    }
}
