using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 0.08f;
    public GameObject player;
    public Transform playerTransfom;
    public Vector3 playerPos;
    public GameObject adObject;

    public float playerx;
    public float playery;
    public float playerz;

    // Start is called before the first frame update
    void Start()
    {
        adObject.GetComponent<AdsManager>().playAd();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //playerTransfom.transform.position = new Vector3(playerx, playery, playerz);

        transform.position += Vector3.forward * speed * Time.fixedDeltaTime;

        //playerz += speed;


        //if (Input.GetKeyDown(KeyCode.A))
        //{
        //    //playerTransfom.transform.position = new Vector3(1, 0, 0);
        //    playerx -= 2.5f;
        //}

        //if (Input.GetKeyDown(KeyCode.D))
        //{
        //    //playerTransfom.transform.position = new Vector3(-1, 0, 0);
        //    playerx += 2.5f;
        //}

        //if (playerx >= 2.5f)
        //{
        //    playerx = 2.5f;
        //}

        //if (playerx <= -2.5f)
        //{
        //    playerx = -2.5f;
        //}

    }

    //public void moveLeft()
    //{
    //    playerx -= 2.5f;
    //}

    //public void moveRight()
    //{
    //    playerx += 2.5f;
    //}
}
