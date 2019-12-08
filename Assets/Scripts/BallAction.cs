using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallAction: MonoBehaviour
{
    public float speedMulti;
    public bool locked;
    public GameObject target;
    public GameObject explosion_mesh;
    Vector3 temp = new Vector3(0, 0, 0);

    

    public bool Locked
    {
        get { return locked; }
        set
        {
            locked = value;
            GameObject explosion = Instantiate(explosion_mesh, transform.position, Quaternion.identity);

        }
    }
    
    [ContextMenu("Test Lock State")]
    void Test ()
    {
        Locked = !Locked;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        target = this.gameObject;
        speedMulti = 10.0f;
        
        
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
        
        if(locked != true)
        {
            float step = speedMulti * Time.deltaTime;
            temp = target.transform.position;
            transform.position = Vector3.MoveTowards(transform.position, temp, step);

        }

    }

    public void Reset()
    {
        transform.position = new Vector3(0, 0, 0);
        target = gameObject;
        speedMulti = 5.0f;
    }
}
