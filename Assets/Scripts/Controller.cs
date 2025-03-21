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
            currentAttempt = -1;
        }
    }

    public void SubmitGuess()
    {
        bool valid = model.GetComponent<Model>().isValidGuess(userGuess.text.ToString());

        if (valid)
        {
            if (string.Compare(userGuess.text.Trim(), correctAnswer.Trim()) == 0)
            {
                view.GetComponent<View>().UpdateView(userGuess.text, currentAttempt, correctAnswer);
                WinGame();
            }
            else
            {
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
        Debug.Log("The word is " + correctAnswer);
        view.EndOfGame(correctAnswer);
        view.WinLoseText(endOfGameState.win);
        Debug.Log("You win!");
    }

    void LoseGame()
    {
        Debug.Log("The word is " + correctAnswer);
        view.EndOfGame(correctAnswer);
        view.WinLoseText(endOfGameState.lose);   
        Debug.Log("You lose");
    }
}
