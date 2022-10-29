using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;
    
    private bool timerStart = false;
    private float timer;
    private float min;
    private float sec;

    private void Start()
    {
        timer = GameManager.gameManager.GetTimerMaxtime();
        GameManager.gameManager.OnTimerState += TimerState;
        text.text = string.Format("01:00");
    }

    private void Update()
    {
        if (timerStart)
        {
            timer -= Time.deltaTime;

            if (timer <= 0)
            {
                text.text = string.Format("00:00");
                GameManager.gameManager.GameFail();
            }

            min = Mathf.Floor(timer / 60);
            sec = Mathf.RoundToInt(timer % 60);

            text.text = string.Format("{0:00}:{1:00}", min, sec);

        }
    }

    public void TimerState(bool state)
    {
        timerStart = state;
    }
}
