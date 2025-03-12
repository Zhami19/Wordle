using TMPro;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public TMP_InputField userGuess;

    [SerializeField] Model model;
    [SerializeField] View view;

    string correctAnswer;
    int currentAttempt;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        correctAnswer = model.GetComponent<Model>().CorrectAnswer;
        currentAttempt = model.GetComponent<Model>().CurrentAttempt;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SubmitGuess()
    {
        Debug.Log(userGuess.text.ToString());
        bool valid = model.GetComponent<Model>().isValidGuess(userGuess.text.ToString());

        if (valid)
        {
            //Handle/update view
            if (string.Equals(userGuess.text.ToString(), correctAnswer))
            {
                WinGame();
            }
            else
            {
                if (currentAttempt == 6)
                {
                    LoseGame();
                }
                else
                {
                    view.GetComponent<View>().UpdateView(userGuess.text.ToString(), currentAttempt, correctAnswer);
                    currentAttempt++;
                }
            }
        }
        else
        {
            //Let player know it is not valid
        }
    }

    void WinGame()
    {
        //Load Win Scene
    }

    void LoseGame()
    {
        //Load Lose Scene
    }
}
