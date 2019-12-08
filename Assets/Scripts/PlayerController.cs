using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public GameObject hitbox;
    public GameObject PlayerOBJ;
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
    
    public static Dictionary<int, PlayerController> players = new Dictionary<int, PlayerController>();

    private GameObject playerField;
    private string playerKey;
    void Awake()
    {
        players[playerNum] = this;
        //currentPoint = points[0];
        AWDpoints.SetActive(false);
        dir = GameObject.FindGameObjectWithTag("Ball");
    }

    private void Start()
    {
        if (playerNum == 0)
        {
            playerKey = "FireP1";
            playerField = GameObject.Find("Player2Bounds");
        }
        else
        {
            playerKey = "FireP2";
            playerField = GameObject.Find("Player1Bounds");
        }
    }

    void Update()
    {
        frames += 1;
        attackCooldown += 1;
        float axisX = Input.GetAxisRaw(Movement[playerNum]);
        float axisY = Input.GetAxisRaw(Movement2[playerNum]);
        var hitbox = PlayerOBJ.transform.GetChild(0).GetComponent<BoxCollider>();

        //key pressed status reset if left and right arent being pressed
        if (Mathf.Abs(axisX) < .5f)
        {
            r = false;
            l = false;
        }

        if (frames > 4)
        {
            //moving left?
            if (axisX <= -.5f && (transform.position - points[2].transform.position).sqrMagnitude > 0.01f && !l)
            {
                l = true;
                currentPoint++;
                currentPoint %= points.Length;
                PlayerOBJ.transform.position = points[currentPoint].transform.position;
                frames = 0;
            }

            //moving right?
            else if (axisX >= .5f && (transform.position - points[0].transform.position).sqrMagnitude > 0.01f && !r)
            {
                r = true;
                currentPoint += points.Length - 1;
                currentPoint %= points.Length;
                PlayerOBJ.transform.position = points[currentPoint].transform.position;
                frames = 0;
            }
        }

        if (axisX < -.5f)
        {            
            dir = playerField.transform.Find("Bound3").gameObject;
        }
        if (axisX > .5f)
        {                
            dir = playerField.transform.Find("Bound1").gameObject;
        }
        if (axisY < -.5f || axisY > .5f)
        {
            dir = playerField.transform.Find("Bound2").gameObject;
        }

        if (Input.GetButtonDown(playerKey) && attackCooldown > 15)
        {
            attackCooldown = 0;
               
            hitbox.enabled = true;
        }

        if(attackCooldown == 15)
        {
            hitbox.enabled = false;
        }
    }
}

