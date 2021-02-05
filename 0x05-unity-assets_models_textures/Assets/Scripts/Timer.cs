using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text timerText;
    private float timer;
    private bool isOver;

    ///<summary>
    /// Update is called once per frame
    ///</summary>
    void Update()
    {
        if (!isOver)
            timer += Time.deltaTime;
        TimeToString();
    }

    ///<summary>
    /// Prints the time in a text GUI
    ///</summary>
    private void TimeToString()
    {
        int min = (int)(timer / 60);
        int seg = (int)(timer % 60);
        int cen = (int)(timer * 100) % 100;
        string formatTime = string.Format("{0:0}:{1:00}.{2:00}", min, seg, cen);
        timerText.text = formatTime;
    }

    ///<summary>
    /// Stops the time when the game ends
    ///</summary>
    public void StopTimer()
    {
        isOver = true;
        timerText.color = Color.green;
        timerText.fontSize = 60;
    }
}
