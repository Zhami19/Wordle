using System.Linq;
using UnityEngine;
using System.Collections.Generic;

public class Model : MonoBehaviour
{
    [SerializeField] TextAsset allowedWordsText;
    [SerializeField] TextAsset possibleWordsText;

    [SerializeField] GameObject controller;

    int[,] grid = new int[6, 5];

    private int currentAttempt = 0;
    private string correctAnswer;

    string[] allowedWords;
    string[] possibleWords;
    List<string> usedWords = new List<string>();
    public int CurrentAttempt
    {
        get { return currentAttempt; }
    }

    public string CorrectAnswer
    {
        get { return correctAnswer; }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Setup(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Setup()
    {
        //List<string> usedWords = new List<string>();

        allowedWords = allowedWordsText.ToString().Split('\n');
        possibleWords = possibleWordsText.ToString().Split("\n");
        usedWords.Clear();

        correctAnswer = possibleWords[Random.Range(0, possibleWords.Length)];
        Debug.Log(correctAnswer);
    }

    public bool isValidGuess(string userGuess)
    {
        foreach (string guess in usedWords)
        {
            if (guess.Contains(userGuess))
            {
                Debug.Log("Already guessed this word");
                return false;
            }
        }

        usedWords.Add(userGuess);

        if (userGuess.Length == 5)
        {
            foreach (string word in allowedWords)
            {
                if (word.Contains(userGuess))
                {
                    return true;
                }
            }
        }

        return false;
    }
}
