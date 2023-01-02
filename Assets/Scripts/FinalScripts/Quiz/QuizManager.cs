using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuizManager : MonoBehaviour
{
    public List<QnA> qna;
    public GameObject [] options; 
    public int currentQuestion;

    public TMP_Text QuestionTxt;

    private void Start()
    {
        generateQuestion();
    }

    public void correct()
    {
        qna.RemoveAt(currentQuestion);
        generateQuestion();
    }

    void SetAnswers()
    {
        for (int i = 0; i < options.Length; i++)
        {
            options[i].GetComponent<AnswerScript>().isCorrect = false;
            options[i].transform.GetChild(0).GetComponent<TMP_Text>().text = qna[currentQuestion].Answers[i];


            if (qna[currentQuestion].CorrectAnswer == i +1)
            {
                options[i].GetComponent<AnswerScript>().isCorrect = true;
            }
        }
    }

    void generateQuestion()
    {
        /*currentQuestion = Random.Range(0, qna.Count);

        QuestionTxt.text = qna[currentQuestion].Question;
        SetAnswers();*/

        if (qna.Count > 0)
        {
            switch (currentQuestion)
            {
                case 0:
                    QuestionTxt.text = qna[currentQuestion].Question;
                    SetAnswers();
                    break;

                case 1:
                    QuestionTxt.text = qna[currentQuestion].Question;
                    SetAnswers();
                    break;

                case 2:
                    QuestionTxt.text = qna[currentQuestion].Question;
                    SetAnswers();
                    break;

                case 3:
                    QuestionTxt.text = qna[currentQuestion].Question;
                    SetAnswers();
                    break;
            }
        }

        else
        {
            Debug.Log("Out of Questions");
        }
    }
}

