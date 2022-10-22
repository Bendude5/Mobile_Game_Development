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
    public float jumpSpeed = 0;
    public bool canJump;

    public int maxHealth = 100;
    public int currentHealth;

    public Health_Bar healthBar;
    public bool canPlayerDie;

    //SHAKE
    float accelerometerUpdateInterval = 1.0f / 60.0f;
    // The greater the value of LowPassKernelWidthInSeconds, the slower the
    // filtered value will converge towards current input sample (and vice versa).
    float lowPassKernelWidthInSeconds = 1.0f;
    // This next parameter is initialized to 2.0 per Apple's recommendation,
    // or at least according to Brady! ;)
    float shakeDetectionThreshold = 2.0f;
    float lowPassFilterFactor;
    Vector3 lowPassValue;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);

        jumpSpeed = 0.0f;
        canJump = true;

        //SHAKE
        lowPassFilterFactor = accelerometerUpdateInterval / lowPassKernelWidthInSeconds;
        shakeDetectionThreshold *= shakeDetectionThreshold;
        lowPassValue = Input.acceleration;
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
                Debug.Log("A");
                //playerTransfom.transform.position = new Vector3(1, 0, 0);
                playerx -= 2.5f;
            }
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            if (playerx <= 2.0f)
            {
                Debug.Log("D");
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
            if (canPlayerDie == true)
            {
                this.loadlevel("GameOver");
            }
        }



        //SHAKE
        Vector3 acceleration = Input.acceleration;
        lowPassValue = Vector3.Lerp(lowPassValue, acceleration, lowPassFilterFactor);
        Vector3 deltaAcceleration = acceleration - lowPassValue;

        if (deltaAcceleration.sqrMagnitude >= shakeDetectionThreshold)
        {
            // Perform your "shaking actions" here. If necessary, add suitable
            // guards in the if check above to avoid redundant handling during
            // the same shake (e.g. a minimum refractory period).
            if (canJump == true)
            {
                this.jump();
                canJump = false;
            }
            Debug.Log("Shake event detected at time ");
        }




        //JUMP
        playery += jumpSpeed;
        if (playery >= 16.215f)
        {
            jumpSpeed = -0.3f;
        }

        if (playery <= 11.215f)
        {
            canJump = true;
            jumpSpeed = 0.0f;
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

    public void jump()
    {
        jumpSpeed = 0.3f;
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
