using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitboxScript : MonoBehaviour
{
    public GameObject Player;
    public GameObject TimerUI;
    public GameObject HitEffect;

    BallAction ball;
    PlayerController plrScript;
    Transform BallTransform;
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

            ball = c.GetComponent<BallAction>();
            BallTransform = ball.gameObject.transform;

            GameObject explosion = Instantiate(HitEffect, BallTransform.position, Quaternion.identity);
            explosion.transform.parent = BallTransform;
            GameObject.Destroy(explosion, 1);

            ball.speedMulti += 2f;
            ball.Locked = true;
            Directions.SetActive(true);
            TimerUI.transform.position = BallTransform.position;
            StartCoroutine(OffHit());
        }
    }
    //After hit over
    IEnumerator OffHit()
    {
        Debug.Log("hai");
        float WaitTime = .5f + (ball.speedMulti * 0.01f);
        TimerUI.GetComponent<TimerUIScript>().TimeStat = WaitTime;
        TimerUI.SetActive(true);
        yield return new WaitForSeconds(WaitTime);
        TimerUI.GetComponent<TimerUIScript>().timerOver = false;
        ball.target = plrScript.dir;
        Directions.SetActive(false);
        debounce = false;
        ball.Locked = false;
        plrScript.attacking = false;
    }
}
