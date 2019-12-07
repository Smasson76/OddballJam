using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallAction: MonoBehaviour
{
    public float speedMulti;
    public bool locked;
    public GameObject target;
    int x = 0;
    Vector3 temp = new Vector3(0, 0, 0);

    // Start is called before the first frame update
    void Start()
    {
        speedMulti = 5.0f;
        locked = true;
        
    }

    // Update is called once per frame
    void Update()
    {
        
        
        if(locked != true && x == 0)
        {
            x = 1;
            float step = speedMulti * Time.deltaTime;
            temp = target.transform.position;
            transform.position = Vector3.MoveTowards(transform.position, temp, step);

        }
        if (locked != true && x != 0)
        {
            float step = speedMulti * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, temp, step);
        }

    }
}
