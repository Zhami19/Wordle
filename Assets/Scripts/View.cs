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

    string part1;
    string part2;
    string part3;
    string part4;
    string part5;


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

                switch (i)
                {
                    case 0:
                        part1 = "<color=green>" + userLetters[i] + "</color>";
                        break;
                    case 1:
                        part2 = "<color=green>" + userLetters[i] + "</color>";
                        break;
                    case 2:
                        part3 = "<color=green>" + userLetters[i] + "</color>";
                        break;
                    case 3:
                        part4 = "<color=green>" + userLetters[i] + "</color>";
                        break;
                    case 4:
                        part5 = "<color=green>" + userLetters[i] + "</color>";
                        break;
                }
            }
            else if (correctAnswer.Contains(userLetters[i].ToString()))
            {
                panel.GetChild(i).GetComponent<Image>().color = Color.yellow;

                switch (i)
                {
                    case 0:
                        part1 = "<color=yellow>" + userLetters[i] + "</color>";
                        break;
                    case 1:
                        part2 = "<color=yellow>" + userLetters[i] + "</color>";
                        break;
                    case 2:
                        part3 = "<color=yellow>" + userLetters[i] + "</color>";
                        break;
                    case 3:
                        part4 = "<color=yellow>" + userLetters[i] + "</color>";
                        break;
                    case 4:
                        part5 = "<color=yellow>" + userLetters[i] + "</color>";
                        break;
                }
            }
            else
            {
                panel.GetChild(i).GetComponent<Image>().color = Color.grey;

                switch (i)
                {
                    case 0:
                        part1 = "<color=grey>" + userLetters[i] + "</color>";
                        break;
                    case 1:
                        part2 = "<color=grey>" + userLetters[i] + "</color>";
                        break;
                    case 2:
                        part3 = "<color=grey>" + userLetters[i] + "</color>";
                        break;
                    case 3:
                        part4 = "<color=grey>" + userLetters[i] + "</color>";
                        break;
                    case 4:
                        part5 = "<color=grey>" + userLetters[i] + "</color>";
                        break;
                }
            }
        }

        string coloredWord = part1 + part2 + part3 + part4 + part5;
        Debug.Log(coloredWord);
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
