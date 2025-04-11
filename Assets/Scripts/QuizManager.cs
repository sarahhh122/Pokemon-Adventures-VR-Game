using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class QuizManager : MonoBehaviour
{
    [System.Serializable]
    public class Question
    {
        public string questionText;       // QUESTION
        public string[] options;          //MCQ OPTIONS
        public int correctAnswerIndex;    //MY CORRECT ANSWER
    }

    public Question[] questions;          
    
    public TMP_Text questionTextUI;       
    public TMP_Text feedbackTextUI;      
    public Transform optionsContainer;    
    public GameObject optionButtonPrefab; 

    private int currentQuestionIndex = 0;
    private int score = 0;
    private bool questionAnswered = false;  


    void Start()
    {
        ShowQuestion();
    }

    void ShowQuestion()
    {
        questionAnswered = false;
        ClearOptions();
        if (currentQuestionIndex < questions.Length)
        {
            Question currentQuestion = questions[currentQuestionIndex];
            questionTextUI.text = currentQuestion.questionText;
            feedbackTextUI.text = ""; 

            for (int i = 0; i < currentQuestion.options.Length; i++)
            {
                GameObject newButton = Instantiate(optionButtonPrefab, optionsContainer);
                
                TMP_Text textButton = newButton.GetComponentInChildren<TMP_Text>();
                if (textButton != null)
                {
                    textButton.text = currentQuestion.options[i];
                }

                RectTransform rt = newButton.GetComponent<RectTransform>();
                if (rt != null)
                {
                    Vector2 offset = Vector2.zero;
                    switch (i)
                    {
                        case 0: offset = new Vector2(26, 37); break;
                        case 1: offset = new Vector2(-17, 37); break;
                        case 2: offset = new Vector2(-14, 17); break;
                        case 3: offset = new Vector2(29, 17); break;
                    }
                    rt.anchoredPosition = offset;
                }

                Button buttonComponent = newButton.GetComponent<Button>();
                if (buttonComponent != null)
                {
                    int optionIndex = i; 
                    buttonComponent.onClick.AddListener(() => OnOptionSelected(optionIndex));
                }
            }
        }
        else
        {
            EndQuiz();
        }
    }

    void OnOptionSelected(int selectedIndex)
    {
        if (questionAnswered)
            return;
        questionAnswered = true;
    
        Question currentQuestion = questions[currentQuestionIndex];
        
        if (currentQuestionIndex >= questions.Length)
            return;
        if (selectedIndex == currentQuestion.correctAnswerIndex)
        {
            feedbackTextUI.text = "Correct Answer :)";
            score++;
        }
        else
        {
            feedbackTextUI.text = "Incorrect :(";
        }

        currentQuestionIndex++;
        Invoke("ShowQuestion", 2f);
    }



     void ClearOptions()
    {
        foreach (Transform child in optionsContainer)
            Destroy(child.gameObject);
    }

    void EndQuiz()
    {
        if(score == questions.Length){
             questionTextUI.text = "Congratulations :)) Quiz Completed! Score: " + score + " / " + questions.Length;
             feedbackTextUI.text = "";
             ClearOptions();
        }
        else{
        questionTextUI.text = "Quiz Completed! Score: " + score + " / " + questions.Length;
        feedbackTextUI.text = "";
        ClearOptions();
        }
    }
}
