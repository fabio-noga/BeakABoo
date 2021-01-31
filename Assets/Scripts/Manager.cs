using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public int score;
    public TextMeshProUGUI text;
    public TextMeshProUGUI texttimer;
    public float timer;

    void Update()
    {
        timer -= Time.deltaTime;
        text.text = (score.ToString());
        texttimer.text = ((int) timer).ToString();

        if (timer <= 0)
        {
            //End
        }
    }
}
