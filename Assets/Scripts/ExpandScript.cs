using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpandScript : MonoBehaviour
{
    int frames = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        frames += 1;
        transform.localScale += new Vector3(0.4f, 0.4f, 0.4f);
        Color c = gameObject.GetComponent<Renderer>().material.color;
        if(c.a >= 0f)
        {
            c.a -= 0.03f;
            gameObject.GetComponent<Renderer>().material.color = c;
        }
        if (frames > 20)
        {
            Destroy(transform.gameObject);
        }


    }
}
