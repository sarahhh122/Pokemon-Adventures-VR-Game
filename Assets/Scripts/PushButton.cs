using UnityEngine;
using UnityEngine.UI;

public class PushButton : MonoBehaviour
{
    public int answerIndex;

    public QuizManager quizManager;

    private Button buttonComponent;

    void Start()
    {
        buttonComponent = GetComponent<Button>();
        if (buttonComponent != null)
        {
            buttonComponent.onClick.AddListener(OnButtonClick);
        }
    }

    // Called when the button is clicked.
    void OnButtonClick()
    {
        if (quizManager != null)
        {
           // quizManager.CheckAnswer(answerIndex);
        }
        
    }
}
