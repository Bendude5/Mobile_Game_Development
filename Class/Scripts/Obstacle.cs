using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public GameObject thisObject;
    public int damage;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(thisObject, 20);
    }

    public void OnTriggerEnter(Collider collision)
    {
        //This code is for when a collision is made
        switch (collision.tag)
        {
            //This checks to see if the collision made was with player attack
            case "Player":
                GameObject.FindGameObjectWithTag("Player").GetComponent<Basic_Movement>().takeDamage(damage);
                break;
        }
    }

}
