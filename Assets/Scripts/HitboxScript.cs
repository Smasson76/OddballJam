using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitboxScript : MonoBehaviour
{
    public GameObject Player;

    BallAction ball;
    PlayerController plrScript;
    bool debounce = false;

    int frames = 0;
    // Start is called before the first frame update
    void Start()
    {
        
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
            Debug.Log("Successfully hit ball");
            ball = c.GetComponent<BallAction>();
            ball.speedMulti += 0.5f;
            plrScript = Player.GetComponent<PlayerController>();
            ball.Locked = true;
            // StartCoroutine(HitWhatever(ball.speedMulti + 5f));
            ball.target = plrScript.dir;
            Debug.Log("Waited and reset");
            debounce = false;
            ball.Locked = false;
        }
    }

    IEnumerator HitWhatever(float x)
    {
        yield return new WaitForSeconds(x);
    }
}
