using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] float remaningTime;

    void Update()
    {
        if (remaningTime > 0)
        {
            remaningTime -= Time.deltaTime;
            //timerText.text.ToString();
        }
        else if (remaningTime <= 0)
        {
            remaningTime = 0;
        }
        int minutes = Mathf.FloorToInt(remaningTime / 60);
        int seconds = Mathf.FloorToInt(remaningTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
