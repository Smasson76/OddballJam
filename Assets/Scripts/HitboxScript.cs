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
        plrScript = Player.GetComponent<PlayerController>();
        if (plrScript.playerNum == 0) {
            Directions = GameObject.FindGameObjectWithTag("Directions").transform.Find("Player1 Points").gameObject;
        }
        if (plrScript.playerNum == 1)
        {
            Directions = GameObject.FindGameObjectWithTag("Directions").transform.Find("Player2 Points").gameObject;
        }

    }

    // Update is called once per frame
    void Update()
    {
        frames += 1;
        
    }

    //when plr hitbox collides with object with tag "Ball"
    void OnTriggerEnter(Collider c)
    {
        if (c.gameObject.tag == "Ball" && debounce == false)
        {
            frames = 0;
            debounce = true;
           
            plrScript.attacking = true;
            Debug.Log("Successfully hit ball");
            ball = c.GetComponent<BallAction>();
            ball.speedMulti += 2f;
            ball.Locked = true;
            Directions.active = !Directions.active;
            StartCoroutine(OffHit());
            
        }
    }

    //After hit over
    IEnumerator OffHit()
    {
        float WaitTime = .5f + (ball.speedMulti * 0.01f);
        yield return new WaitForSeconds(WaitTime);
        ball.target = plrScript.dir;
        Directions.active = !Directions.active;
        debounce = false;
        ball.Locked = false;
        plrScript.attacking = false;
    }
}
