using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnswerScript : MonoBehaviour
{
    public bool isCorrect = false;
    public QuizManager _quizManager;
    public GameObject riddlePopUp;
    public TimerBar timerbar;

    public GameObject _door;


    private void Start()
    {

    }

    public void Answer()
    {
        if (isCorrect == true)
        {            

            Debug.Log("Correct Answer");
            _quizManager.correct();

            riddlePopUp.SetActive(false);
            _door.transform.Rotate(0, 0, -90); // how to make it like an animation, like how to add the rotating speed?
        }

        else if (isCorrect == false)
        {
            Debug.Log("Wrong Answer. Try Again");
            timerbar.CurrentTime -= 5f;
        }
    }
}
