using UnityEngine;
using UnityEngine.UI;

public class PushButton : MonoBehaviour
{
    // The index of this answer option (set in the Inspector)
    public int answerIndex;

    // Reference to the QuizManager (set in the Inspector)
    public QuizManager quizManager;

    private Button buttonComponent;

    void Start()
    {
        buttonComponent = GetComponent<Button>();
        if (buttonComponent != null)
        {
            // Register the OnButtonClick method to the button's onClick event.
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
        else
        {
            Debug.LogWarning("QuizManager is not assigned on " + gameObject.name);
        }
    }
}
