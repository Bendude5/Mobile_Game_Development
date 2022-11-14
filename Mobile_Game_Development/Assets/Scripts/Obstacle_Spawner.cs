using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle_Spawner : MonoBehaviour
{

    public Transform thisGameObject;
    public GameObject prefab;
    public GameObject prefab2;

    public float x;
    public float y;
    public float z;

    public int enemyType;
    public int spawnNumber;

    // Start is called before the first frame update
    void Start()
    {
        y = thisGameObject.position.y;
        z = thisGameObject.position.z;
        enemyType = Random.Range(1, 11);

        if (enemyType != 3)
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


        else if (enemyType == 3)
        {
            this.spawnLongPrefab();
            x = thisGameObject.position.x;
        }


    }

    // Update is called once per frame
    void Update()
    {

    }

    public void spawnPrefab()
    {
        GameObject bullet = Instantiate(prefab, new Vector3(x, y, z), Quaternion.identity);
    }

    public void spawnLongPrefab()
    {
        GameObject bullet = Instantiate(prefab2, new Vector3(x, y, z), Quaternion.identity);
    }

}
