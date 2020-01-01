using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudScript : MonoBehaviour
{
    public GameObject CloudModel;
    public float cloudSpeed = 1.0f;

    static int maxCloudCount = 5;
    GameObject[] Clouds = new GameObject[maxCloudCount];
    // Start is called before the first frame update

    void Start()
    {
        for (int i = 0; i < maxCloudCount; i++)
        {
            Clouds[i] = Instantiate(CloudModel, this.transform);
            Clouds[i].transform.position = new Vector3(200, -90, 90-(18*(maxCloudCount-i)*2));
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
