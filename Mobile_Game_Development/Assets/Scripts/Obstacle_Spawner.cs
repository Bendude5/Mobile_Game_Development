using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle_Spawner : MonoBehaviour
{

    public Transform thisGameObject;
    public GameObject scoreObject;
    public GameObject damageObject;
    public GameObject damagePillar;

    public float x;
    public float y;
    public float z;

    public int enemyType;
    public int spawnNumber;

    // Start is called before the first frame update
    void Start()
    {
        //Randomly generates a number, that number decides what object to spawn next with a random x position
        y = thisGameObject.position.y;
        z = thisGameObject.position.z;
        enemyType = Random.Range(1, 12);

        //Spawns guard prefab
        if (enemyType <= 5)
        {
            spawnNumber = Random.Range(1, 4);

            if (spawnNumber == 1)
            {
                x = thisGameObject.position.x;
            }

            if (spawnNumber == 2)
            {
                x = thisGameObject.position.x + 2.5f;
            }

            if (spawnNumber == 3)
            {
                x = thisGameObject.position.x - 2.5f;
            }

            this.spawnPrefab();
        }


        //Spawns pillar prefab
        else if (enemyType >= 7)
        {
            spawnNumber = Random.Range(1, 4);

            if (spawnNumber == 1)
            {
                x = thisGameObject.position.x;
            }

            if (spawnNumber == 2)
            {
                x = thisGameObject.position.x + 2.5f;
            }

            if (spawnNumber == 3)
            {
                x = thisGameObject.position.x - 2.5f;
            }

            this.spawnPillar();
        }


        //Spawns monster prefab
        else if (enemyType == 6)
        {
            this.spawnLongPrefab();
            x = thisGameObject.position.x;
        }


    }

    // Update is called once per frame
    void Update()
    {

    }

    //Spawn guard prefab
    public void spawnPrefab()
    {
        GameObject bullet = Instantiate(scoreObject, new Vector3(x, y, z), Quaternion.identity);
    }

    //Spawn monster prefab
    public void spawnLongPrefab()
    {
        GameObject bullet = Instantiate(damageObject, new Vector3(x, y, z), Quaternion.identity);
    }

    //Spawn pillar prefab
    public void spawnPillar()
    {
        GameObject bullet = Instantiate(damagePillar, new Vector3(x, y, z), Quaternion.identity);
    }

}
