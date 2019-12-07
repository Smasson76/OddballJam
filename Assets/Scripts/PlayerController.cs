using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public GameObject PlayerOBJ;
    public KeyCode blahKey = KeyCode.Space;

    public Transform[] points;
    int currentPoint = 0;
    public GameObject AWDpoints;
    int frames = 0;
    bool r, l = false;

    public int playerNum = 0;
    public string[] Movement = new string[] { "Horizontal", "Horizontal2" };
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
        float axis = Input.GetAxis(Movement[playerNum]);
       
        //key pressed status reset if left and right arent being pressed
        if (Mathf.Abs(axis) < 1f)
        {
            r = false;
            l = false;
        }

        if (playerNum == 1)
        {
            if (frames > 4)
                {
            
                    //moving left?
                    if (axis == -1f && transform.position != points[2].transform.position && l == false)
                    {
                        l = true;
                        currentPoint++;
                        currentPoint %= points.Length;
                        PlayerOBJ.transform.position = points[currentPoint].transform.position;
                        frames = 0;
                    }

                    //moving right?
                    if (axis == 1f && transform.position != points[0].transform.position && r == false)
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
                if (axis == 1f && transform.position != points[2].transform.position && l == false)
                {
                    l = true;
                    currentPoint++;
                    currentPoint %= points.Length;
                    PlayerOBJ.transform.position = points[currentPoint].transform.position;
                    frames = 0;
                }

                //moving right?
                if (axis == -1f && transform.position != points[0].transform.position && r == false)
                {
                    r = true;
                    currentPoint += points.Length - 1;
                    currentPoint %= points.Length;
                    PlayerOBJ.transform.position = points[currentPoint].transform.position;
                    frames = 0;
                }
            }
        }

        if (playerNum == 0)
        {
            if (Input.GetKeyDown(KeyCode.Joystick1Button2))
            {
                Debug.Log("Attaque by p1");
                AWDpoints.SetActive(true);
            }
        }
        if (playerNum == 1)
        {
            if (Input.GetKeyDown(KeyCode.Joystick2Button2))
            {
                Debug.Log("Attaque by p2");
                AWDpoints.SetActive(true);
            }
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            //Code goes here
            AWDpoints.SetActive(false);
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            //Code goes here
            AWDpoints.SetActive(false);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            //Code goes here
            AWDpoints.SetActive(false);
        }
    }
}

