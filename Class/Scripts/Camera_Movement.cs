using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Movement : MonoBehaviour
{

    public Transform playerTransfom;
    public Transform thisTransfom;
    public Vector3 playerPos;

    public float thisx;
    public float thisy;
    public float thisz;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        thisTransfom.transform.position = new Vector3(thisx, thisy, thisz);

        thisz = playerTransfom.transform.position.z;
    }
}
