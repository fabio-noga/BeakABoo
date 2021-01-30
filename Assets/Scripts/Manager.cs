using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public int score;
    public TextMeshProUGUI text;
    public int timer;

    void Update()
    {
        text.text = ("Score: " + score);
    }
}
