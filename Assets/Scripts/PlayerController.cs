using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public string blahAxis = "Horizonal";
    public string blahButton = "Fire1";
    public KeyCode blahKey = KeyCode.Space;

    public Transform[] points;
    int currentPoint = 0;
    public GameObject AWDpoints;
    int frames = 0;

    public int playerNum = 0;
    public string[] Movement = new string[] { "Horizontal", "Horizontal2" };
    //public KeyCode[] hit = new KeyCode[] { KeyCode.Joystick1Button0, KeyCode.Joystick2Button0 };
    public KeyCode[] hit = new KeyCode[] { KeyCode.F, KeyCode.F2 };
    public static Dictionary<int, PlayerController> players = new Dictionary<int, PlayerController>();

    void Awake() {
        players[playerNum] = this;
        //currentPoint = points[0];
        Debug.Log("Player " + (playerNum+1).ToString());
        AWDpoints.SetActive(false);
    }

    void Update() {
        frames+=1;
        if (frames > 15) {
            float axis = Input.GetAxis(Movement[playerNum]);
            if (axis > 0.5f) {
                currentPoint++;
                currentPoint %= points.Length;
                transform.position = points[currentPoint].transform.position;
                frames = 0;
            }
            else if (axis < -0.5f)
            {
                currentPoint += points.Length - 1;
                currentPoint %= points.Length;
                transform.position = points[currentPoint].transform.position;
                frames = 0;
            }
        }

        if (Input.GetKey(hit[playerNum])) {
            AWDpoints.SetActive(true);
        }
    
        if (Input.GetKeyDown(KeyCode.A)) {
            //Code goes here
            AWDpoints.SetActive(false);
        }
        else if (Input.GetKeyDown(KeyCode.W)) {
            //Code goes here
            AWDpoints.SetActive(false);
        }
        else if (Input.GetKeyDown(KeyCode.D)) {
            //Code goes here
            AWDpoints.SetActive(false);
        }
    }
}
