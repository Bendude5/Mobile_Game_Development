using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public GameObject thisObject;
    public GameObject childObject;
    public bool badObject;
    Animator anim;
    public int damage;

    // Start is called before the first frame update
    void Start()
    {
        anim = childObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(thisObject, 80);
    }

    public void OnTriggerEnter(Collider collision)
    {
        //This code is for when a collision is made
        switch (collision.tag)
        {
            //This checks to see if the collision made was with player attack
            case "Player":
                if (badObject == true)
                {
                    anim.SetInteger("Anim_Number", 2);
                    GameObject.FindGameObjectWithTag("Player").GetComponent<Basic_Movement>().takeDamage(damage);
                }

                if (badObject == false)
                {
                    anim.SetInteger("Anim_Number", 2);
                    GameObject.Find("Score").GetComponent<Score>().AddScore(10);
                }
                break;
        }
    }

}
