using System.Linq;
using UnityEngine;

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
        allowedWords = allowedWordsText.ToString().Split('\n');
        possibleWords = possibleWordsText.ToString().Split("\n");

        correctAnswer = possibleWords[Random.Range(0, possibleWords.Length)];
    }

    public bool isValidGuess(string userGuess)
    {
        foreach (string word in allowedWords)
        {
            if (word.Contains(userGuess))
            {
                Debug.Log("valid word");
                return true;
            }
        }
        Debug.Log("invalid word");
        return false;
    }
}
