using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bridge_Spawner : MonoBehaviour
{

    public GameObject parentObject;

    public Transform thisGameObject;

    public GameObject prefab;

    public float x;
    public float y;
    public float z;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        x = thisGameObject.position.x;
        y = thisGameObject.position.y;
        z = thisGameObject.position.z + 432.5f;
    }

    public void OnTriggerEnter(Collider collision)
    {
        //This code is for when a collision is made
        switch (collision.tag)
        {
            //This checks to see if the collision made was with player attack
            case "Player":
                Debug.Log("New Bridge");
                //GameObject bridge = Instantiate(prefab, new Vector3(x, y, z), Quaternion.identity);
                Instantiate(prefab, new Vector3(x, y, z), Quaternion.identity);
                Destroy(prefab, 20);
                break;
        }
    }
}
