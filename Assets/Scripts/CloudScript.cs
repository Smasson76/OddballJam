using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudScript : MonoBehaviour
{
    public GameObject CloudModel;
    public float cloudSpeed = 1.0f;
    public float CloudCount = 10.0f;
    public List<GameObject> Clouds = new List<GameObject>();
    // Start is called before the first frame update

    void Start()
    {
        for (int i = 0; i < CloudCount; i++)
        {
            Clouds.Add(Instantiate(CloudModel, this.transform));
            Clouds[i].transform.position = new Vector3(200, -90, -90+((float)((2 / CloudCount)*100) * i));
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
