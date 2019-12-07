using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public Transform[] points;
    int currentPoint = 0;

    public int playerNum = 0;
    public string[] Movement = new string[] { "Horizontal", "Horizontal2" };
    //public string[] verticalAxis = new string[] { "Vertical", "Vertical2" };
    public KeyCode[] hit = new KeyCode[] { KeyCode.Joystick1Button0, KeyCode.Joystick2Button0 };
    public static Dictionary<int, PlayerController> players = new Dictionary<int, PlayerController>();

    void Awake() {
        players[playerNum] = this;
        //currentPoint = points[0];
        Debug.Log("Player " + (playerNum+1).ToString());
    }

    void Update() {
        if (Input.GetButtonDown(Movement[playerNum])) {
            currentPoint++;
            currentPoint %= points.Length;
            transform.position = points[currentPoint].transform.position;
        }
    }
}
