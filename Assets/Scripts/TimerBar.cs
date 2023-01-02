using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class TimerBar : MonoBehaviour
{
    public Slider timerSlier;
    public TMP_Text timerText;
    public float gameTime;
    AnswerScript answerscript;
    public float CurrentTime=0;
    private bool stopTimer;
    public bool reducedTime = false;
    float amount = 5;



    void Start()
    {
        stopTimer = false;
        CurrentTime = gameTime;
        timerSlier.maxValue = gameTime;
        timerSlier.value = gameTime;
    }
    public void ReduceTime(float amount)
    {
        if (reducedTime == true)
        {
            CurrentTime -= amount;
        }
    }
    public void Update()
    {
        CurrentTime = CurrentTime - Time.deltaTime;

        int minutes = Mathf.FloorToInt(CurrentTime / 60);
        int seconds = Mathf.FloorToInt(CurrentTime - minutes * 60f);

        string textTime = string.Format("{0:}:{1:00}", minutes, seconds);

        if (CurrentTime <= 0)
        {
            stopTimer = true;
            SceneManager.LoadScene("GameOver");
        }

        if (stopTimer == false)
        {
            timerText.text = textTime;
            timerSlier.value = CurrentTime;
        }
    }
}
