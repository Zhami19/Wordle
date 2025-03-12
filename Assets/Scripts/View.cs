using UnityEngine;
using UnityEngine.UI;

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

    public void UpdateView(string userGuess, int attempt)
    {
        char[] letters = userGuess.ToCharArray();
        for (int i = 0; i < 5; i++)
        {

            verticalLayout.transform.GetChild(attempt).GetComponentInChildren<Text>().text = letters[i].ToString();
        }
    }
}
