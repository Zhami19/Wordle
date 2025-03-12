using UnityEngine;
using UnityEngine.UI;
using TMPro;

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

        //verticalLayout.transform.GetChild(0).GetChild(0).GetComponentInChildren<TMP_Text>().text = letters[0].ToString();
        for (int i = 0; i < 5; i++)
        {
            Debug.Log("UpdateView is called; it is attempt " + attempt + " and letter " + letters[i].ToString());
            verticalLayout.transform.GetChild(attempt).GetChild(i).GetComponentInChildren<TMP_Text>().text = letters[i].ToString();
        }
    }
}
