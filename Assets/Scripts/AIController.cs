using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour {

    public Transform[] points;
    int currentPoint = 0;
    public GameObject dir;
    GameObject AIField;

    void Awake() {
        dir = GameObject.FindGameObjectWithTag("Ball");
    }

    void Start() {
        AIField = GameObject.Find("Player2Bounds");
    }

    public enum State {
        Idle,
        MoveLeft,
        MoveRight,
    }

    public State state = State.Idle;

    void Update() {
        switch (state) {
            case State.Idle:
                IdleUpdate();
                break;
            case State.MoveLeft:
                MoveLeft();
                break;
            case State.MoveRight:
                MoveRight();
                break;
            default:
                break;
        }
    }

    void IdleUpdate() {
        //Just an idle state
    }

    void MoveLeft() {
        //Move Player left
    }

    void MoveRight() {
        //Move Player right 
    }
}


