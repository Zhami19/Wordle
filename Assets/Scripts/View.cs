using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class View : MonoBehaviour
{
    [SerializeField] GameObject verticalLayout;

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
            Debug.Log("UpdateView is called; it is attempt " + attempt + " and letter " + userLetters[i].ToString());
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
}
