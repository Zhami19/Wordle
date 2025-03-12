using TMPro;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public TMP_InputField userGuess;

    [SerializeField] Model model;
    [SerializeField] View view;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SubmitGuess()
    {
        Debug.Log(userGuess.text.ToString());
        bool valid = model.GetComponent<Model>().isValidGuess(userGuess.text.ToString());
        string correctAnswer = model.GetComponent<Model>().CorrectAnswer;
        int currentAttempt = model.GetComponent<Model>().CurrentAttempt;

        if (valid)
        {
            //Handle/update view
            if (string.Equals(userGuess.text.ToString(), correctAnswer))
            {
                WinGame();
            }
            else
            {
                if (currentAttempt == 5)
                {
                    LoseGame();
                }
                else
                {
                    currentAttempt++;
                    view.GetComponent<View>().UpdateView(userGuess.text.ToString(), currentAttempt);
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
