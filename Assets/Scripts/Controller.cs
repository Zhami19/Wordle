using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Controller : MonoBehaviour
{
    public TMP_InputField userGuess;

    [SerializeField] Model model;
    [SerializeField] View view;
    public enum endOfGameState
    {
        win,
        lose
    }

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
        if (currentAttempt == 6)
        {
            LoseGame();
        }
    }

    public void SubmitGuess()
    {
        bool valid = model.GetComponent<Model>().isValidGuess(userGuess.text.ToString());

        if (valid)
        {
            //Handle/update view
            Debug.Log("Valid Word");
            Debug.Log("The user's guess is " + userGuess.text);
            Debug.Log("The correct answer is " + correctAnswer);
            Debug.Log("Are they equal? " + string.Compare(userGuess.text.Trim(), correctAnswer.Trim()));

            if (string.Compare(userGuess.text.Trim(), correctAnswer.Trim()) == 0)
            {
                Debug.Log("You win");
                view.GetComponent<View>().UpdateView(userGuess.text, currentAttempt, correctAnswer);
                WinGame();
            }
            else
            {
                Debug.Log("Word does not match");
                view.GetComponent<View>().UpdateView(userGuess.text.ToString(), currentAttempt, correctAnswer);
                currentAttempt++;
            }
        }
        else
        {
            Debug.Log("Invalid guess");
        }
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene(0);
    }

    void WinGame()
    {
        view.EndOfGame(correctAnswer);
        view.WinLoseText(endOfGameState.win);

        Debug.Log("You win 2");
    }

    void LoseGame()
    {
        view.EndOfGame(correctAnswer);
        view.WinLoseText(endOfGameState.lose);   
        Debug.Log("You lose");
    }
}
