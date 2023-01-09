using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Basic_Movement : MonoBehaviour
{
    public float speed = 0.08f;
    public GameObject player;
    public Transform playerTransfom;
    public Vector3 playerPos;

    //Movement slider
    public Slider slider;

    public Animator anim;

    //Advert object
    public GameObject adObject;
    //Camera shake
    public CameraShake cameraShake;

    //Locations
    public float playerx;
    public float playery;
    public float playerz;
    public float jumpSpeed = 0;
    public bool canJump;

    public GameObject gameOver;
    public GameObject retryButton;

    public int maxHealth = 100;
    public int currentHealth;

    public Health_Bar healthBar;
    public bool canPlayerDie;
    public bool canRestart;
    public bool canPlayAd;

    //SHAKE
    float accelerometerUpdateInterval = 1.0f / 60.0f;
    float lowPassKernelWidthInSeconds = 1.0f;
    float shakeDetectionThreshold = 2.0f;
    float lowPassFilterFactor;
    Vector3 lowPassValue;

    // Start is called before the first frame update
    void Start()
    {
        //Sets starting values
        anim.SetInteger("Anim_Number", 1);
        Time.timeScale = 1;
        canRestart = true;
        gameOver.SetActive(false);

        //Health
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);

        jumpSpeed = 0.0f;
        canJump = true;

        //SHAKE
        lowPassFilterFactor = accelerometerUpdateInterval / lowPassKernelWidthInSeconds;
        shakeDetectionThreshold *= shakeDetectionThreshold;
        lowPassValue = Input.acceleration;
    }

    void Update()
    {
        healthBar.SetHealth(currentHealth);

        if (canPlayAd == true)
        {
            //Plays ad when it can
            adObject.GetComponent<AdsManager>().playAd();
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Moves player forward
        playerTransfom.transform.position = new Vector3(playerx, playery, playerz);

        playerz += speed;


        if (Input.GetKeyDown(KeyCode.A))
        {
            if (playerx >= -2.0f)
            {
                Debug.Log("A");
                playerx -= 2.5f;
            }
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            if (playerx <= 2.0f)
            {
                Debug.Log("D");
                playerx += 2.5f;
            }
        }

        //Stops player going off screen
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
                anim.SetInteger("Anim_Number", 2);
            }
        }



        //SHAKE
        Vector3 acceleration = Input.acceleration;
        lowPassValue = Vector3.Lerp(lowPassValue, acceleration, lowPassFilterFactor);
        Vector3 deltaAcceleration = acceleration - lowPassValue;

        if (deltaAcceleration.sqrMagnitude >= shakeDetectionThreshold)
        {
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

        playerx = slider.value;

    }


    public void moveLeft()
    {
        if (playerx >= -2.0f)
        {
            playerx -= 2.5f;
        }
    }

    public void moveRight()
    {
        if (playerx <= 2.0f)
        {
            playerx += 2.5f;
        }
    }

    //Jump
    public void jump()
    {
        jumpSpeed = 0.3f;
    }

    //Take damage, called from obstacles
    public void takeDamage(int damage)
    {
        currentHealth -= damage;
        StartCoroutine(cameraShake.Shake(0.15f, 0.4f));
        healthBar.SetHealth(currentHealth);
        Debug.Log("Damge");
    }

    //Game over
    public void GameOver()
    {
        gameOver.SetActive(true);
        if (canRestart == false)
        {
            retryButton.SetActive(false);
        }

        if (canRestart == true)
        {
            retryButton.SetActive(true);
        }
        Time.timeScale = 0;
    }

    //If the player selects reward advert to respawn
    public void CarryOn()
    {
        adObject.GetComponent<AdsManager>().playRewardedAd();
        //this.loadlevel("GameOver");
    }

    public void ExitGame()
    {
        this.loadlevel("GameOver");
    }


    public void loadlevel(string level)
    {
        SceneManager.LoadScene("GameOver");
    }
}
