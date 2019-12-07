using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public string blahAxis = "Horizonal";
    public string blahButton = "Fire1";
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
        Debug.Log("Player " + (playerNum + 1).ToString());
        AWDpoints.SetActive(false);
    }

    void Update()
    {
        frames += 1;
        float axis = Input.GetAxis(Movement[playerNum]);
        if (frames > 4)
        {

            

            //moving left?
            if (axis < 0f && transform.position != points[2].transform.position && l == false)
            {
                l = true;
                currentPoint++;
                currentPoint %= points.Length;
                transform.position = points[currentPoint].transform.position;
                frames = 0;
            }

            //moving right?
            else if (axis > -0f && transform.position != points[0].transform.position && r == false)
            {
                r = true;
                currentPoint += points.Length - 1;
                currentPoint %= points.Length;
                transform.position = points[currentPoint].transform.position;
                frames = 0;
            }


        }

        //key pressed status reset if left and right arent being pressed
        if (axis == 0)
        {
            r = false;
            l = false;
        }


        if (Input.GetKey(hit[playerNum]))
        {
            AWDpoints.SetActive(true);
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
    

