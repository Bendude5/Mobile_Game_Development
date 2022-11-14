using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bridge_Destroyer : MonoBehaviour
{

    public int timer;
    public int timerSpeed;
    public GameObject thisObject;

    // Start is called before the first frame update
    void Start()
    {
        timer = 2500;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= timerSpeed;

        if (timer <= 0)
        {
            Destroy(thisObject);
        }
    }
}
