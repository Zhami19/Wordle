using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using Unity.VisualScripting;

public class View : MonoBehaviour
{
    [SerializeField] GameObject verticalLayout;
    [SerializeField] GameObject submitButton;
    [SerializeField] GameObject playAgainButton;
    [SerializeField] TMP_Text correctAnswerText;
    [SerializeField] TMP_Text WLText;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateView(string userGuess, int attempt, string correctAnswer)
    {
        char[] userLetters = userGuess.ToCharArray();
        char[] correctAnswerLetters = correctAnswer.ToCharArray();
        Transform panel = verticalLayout.transform.GetChild(attempt);

        for (int i = 0; i < 5; i++)
        {
            //Debug.Log("UpdateView is called; it is attempt " + attempt + " and letter " + userLetters[i].ToString());
            panel.GetChild(i).GetComponentInChildren<TMP_Text>().text = userLetters[i].ToString();

            if (String.Equals(panel.GetChild(i).GetComponentInChildren<TMP_Text>().text, correctAnswerLetters[i].ToString()))
            {
                panel.GetChild(i).GetComponent<Image>().color = Color.green;
            }
            else if (correctAnswer.Contains(userLetters[i].ToString()))
            {
                panel.GetChild(i).GetComponent<Image>().color = Color.yellow;
            }
            else
            {
                panel.GetChild(i).GetComponent<Image>().color = Color.grey;
            }
        }
    }

    public void EndOfGame(string correctAnswer)
    {
        submitButton.SetActive(false);
        playAgainButton.SetActive(true);
        correctAnswerText.text = "The word is " + correctAnswer;
    }

    public void WinLoseText(Controller.endOfGameState state)
    {

        correctAnswerText.enabled = true;
        WLText.enabled = true;
        Debug.Log("Texts have been enabled");

        switch (state)
        {
            case Controller.endOfGameState.win:
                WLText.text = "You win!";
                break;
            case Controller.endOfGameState.lose:
                WLText.text = "You lose.";
                break;
        }
    }

}
