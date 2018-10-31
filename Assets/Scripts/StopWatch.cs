using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StopWatch : MonoBehaviour {

    //それぞれの時間
    public Text Min;
    public Text Sec;
    public Text Decimal;

    public float timeCount = 0;

    public float DecCount;
    public int MinCount;
    public int SecCount;

	// Use this for initialization
	void Start () {

        Min = GameObject.Find("Min").GetComponent<Text>();
        Sec = GameObject.Find("Sec").GetComponent<Text>();
        Decimal = GameObject.Find("Decimal").GetComponent<Text>();

	}


    //タイムのリセット
    public void ResetTime()
    {
        timeCount = 0;
        DecCount = 0;
        MinCount = 0;
        SecCount = 0;
    }
	
	// Update is called once per frame
	void Update () {

        if (GameManager.instance.PlayerHP > 0)
        {
            timeCount += 1.0f * Time.deltaTime;
            DecCount = timeCount * 100;
        }

        if(timeCount >= 0.98)
        {
            timeCount = 0;
            SecCount++;
        }
        else if(SecCount >= 60)
        {
            SecCount = 0;
            MinCount++;
        }

        if(MinCount < 10)
        {
            Min.text = string.Format("0{0}", MinCount.ToString());
        }
        else
        {
            Min.text = string.Format("{0}", MinCount.ToString());
        }

        if(SecCount < 10)
        {
            Sec.text = string.Format("0{0}", SecCount.ToString());
        }
        else
        {
            Sec.text = string.Format("{0}", SecCount.ToString());
        }

        if(DecCount >= 0 && DecCount < 9.9)
        {
            Decimal.text = string.Format("0{0}", DecCount.ToString("f0"));
        }
        else if(DecCount < 99.9)
        {
            Decimal.text = string.Format("{0}", DecCount.ToString("f0"));
        }
	}
}
