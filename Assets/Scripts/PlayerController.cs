using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public GameObject hitbox;
    public GameObject PlayerOBJ;
    public KeyCode blahKey = KeyCode.Space;
    public GameObject dir;

    public Transform[] points;
    int currentPoint = 0;
    public GameObject AWDpoints;
    int frames = 0;
    int attackCooldown;
    bool r, l = false;

    public int playerNum = 0;
    public string[] Movement = new string[] { "Horizontal", "Horizontal2" };
    public string[] Movement2 = new string[] { "Vertical", "Vertical2" };
    //public KeyCode[] hit = new KeyCode[] { KeyCode.Joystick1Button0, KeyCode.Joystick2Button0 };
    public KeyCode[] hit = new KeyCode[] { KeyCode.F, KeyCode.F2 };
    public static Dictionary<int, PlayerController> players = new Dictionary<int, PlayerController>();

    void Awake()
    {
        players[playerNum] = this;
        //currentPoint = points[0];
        AWDpoints.SetActive(false);
    }

    void Update()
    {
        frames += 1;
        attackCooldown += 1;
        float axisX = Input.GetAxis(Movement[playerNum]);
        float axisY = Input.GetAxis(Movement[playerNum]);
        var hitbox = PlayerOBJ.transform.GetChild(0).GetComponent<BoxCollider>();

        //key pressed status reset if left and right arent being pressed
        if (Mathf.Abs(axisX) < 1f)
        {
            r = false;
            l = false;
        }

        if (playerNum == 1)
        {
            if (frames > 4)
                {
            
                    //moving left?
                    if (axisX == -1f && transform.position != points[2].transform.position && l == false)
                    {
                        l = true;
                        currentPoint++;
                        currentPoint %= points.Length;
                        PlayerOBJ.transform.position = points[currentPoint].transform.position;
                        frames = 0;
                    }

                    //moving right?
                    if (axisX == 1f && transform.position != points[0].transform.position && r == false)
                    {
                        r = true;
                        currentPoint += points.Length - 1;
                        currentPoint %= points.Length;
                        PlayerOBJ.transform.position = points[currentPoint].transform.position;
                        frames = 0;
                    }

             }
        }

        else if (playerNum == 0)
        {
            if (frames > 4)
            {
                //moving left?
                if (axisX == 1f && transform.position != points[2].transform.position && l == false)
                {
                    l = true;
                    currentPoint++;
                    currentPoint %= points.Length;
                    PlayerOBJ.transform.position = points[currentPoint].transform.position;
                    frames = 0;
                }

                //moving right?
                if (axisX == -1f && transform.position != points[0].transform.position && r == false)
                {
                    r = true;
                    currentPoint += points.Length - 1;
                    currentPoint %= points.Length;
                    PlayerOBJ.transform.position = points[currentPoint].transform.position;
                    frames = 0;
                }
            }

            if(axisX == -1f)
            {
                Debug.Log("left");
                GameObject P2field = GameObject.Find("Player2Bounds");

            }
        }

        if (playerNum == 0)
        {
            if (Input.GetKeyDown(KeyCode.Joystick1Button2) && attackCooldown > 15)
            {
                attackCooldown = 0;
                Debug.Log("Attaque by p1");
                hitbox.enabled = true;
            }
        }
        if (playerNum == 1)
        {
            if (Input.GetKeyDown(KeyCode.Joystick2Button2) && attackCooldown > 15)
            {
                attackCooldown = 0;
                Debug.Log("Attaque by p2");
                hitbox.enabled = true;
            }
        }
        if(attackCooldown == 15)
        {
            hitbox.enabled = false;
        }

        



    }

    
}

