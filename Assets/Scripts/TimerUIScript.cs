using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerUIScript : MonoBehaviour
{
    public GameObject Ball;
    public float TimeStat;
    public bool timerOver;

    float current;
    Image imagefill;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.transform.position = Ball.transform.position;
        timerOver = false;
        current = 0;
        imagefill = gameObject.transform.Find("Ring").GetComponent<Image>();
        imagefill.fillAmount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(imagefill.fillAmount < 1 && !timerOver)
        {
            current += (1/TimeStat)/60;
            imagefill.fillAmount = current;
        }
        else
        {
            timerOver = true;
            gameObject.transform.Find("Ring").GetComponent<Image>().fillAmount = 0;
            current = 0;
            Destroy(this);
        }
    }
}
