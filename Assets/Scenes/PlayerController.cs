using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public int playerNum = 0;
    public string[] left = new string[] { "Horizontal", "Horizontal2" };
    //public string[] verticalAxis = new string[] { "Vertical", "Vertical2" };
    public KeyCode[] hit = new KeyCode[] { KeyCode.Joystick1Button0, KeyCode.Joystick2Button0 };
    public static Dictionary<int, PlayerController> players = new Dictionary<int, PlayerController>();

    void Awake() {
        players[playerNum] = this;
        Debug.Log("Player " + (playerNum+1).ToString());
    }

    void Update() {
        if (Input.GetButtonDown(left[playerNum])) {
            gameObject.transform.position = new Vector3(-11.8f,3.6f,-7.5f);
        }
    }
}
