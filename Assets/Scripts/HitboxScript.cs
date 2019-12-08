using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitboxScript : MonoBehaviour
{
    public GameObject Player;

    BallAction ball;
    PlayerController plrScript;
    bool debounce = false;
    GameObject Directions;

    int frames = 0;
    // Start is called before the first frame update
    void Start()
    {
        Directions = GameObject.FindGameObjectWithTag("Directions");
    }

    // Update is called once per frame
    void Update()
    {
        frames += 1;
        
    }

    void OnTriggerEnter(Collider c)
    {
        if (c.gameObject.tag == "Ball" && debounce == false)
        {
            frames = 0;
            debounce = true;
            plrScript = Player.GetComponent<PlayerController>();
            plrScript.attacking = true;
            Debug.Log("Successfully hit ball");
            ball = c.GetComponent<BallAction>();
            ball.speedMulti += 2f;
            ball.Locked = true;
            
            StartCoroutine(HitWhatever());
            
        }
    }

    IEnumerator HitWhatever()
    {
        yield return new WaitForSeconds(.5f);
        ball.target = plrScript.dir;
        Debug.Log("Waited and reset");
        debounce = false;
        ball.Locked = false;
        plrScript.attacking = false;
    }
}
