using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private GameObject prefabBetweenRoundsScreen;

    private GameObject betweenRoundsScreen;

    private void Start()
    {
        OpenBetweenRoundsScreen(3, 4);
    }

    public void OpenBetweenRoundsScreen(int firstPlayerScore, int secondPlayerScore)
    {
       betweenRoundsScreen = Instantiate(prefabBetweenRoundsScreen, transform);
        SetBetweenRoundsScores(firstPlayerScore, secondPlayerScore);
    }

    private void SetBetweenRoundsScores(int firstPlayerScore, int secondPlayerScore)
    {
        var firstPlayerScoreText = betweenRoundsScreen.transform.Find("FirstPlayerScore");
        if(firstPlayerScoreText != null)
        {
            firstPlayerScoreText.GetComponent<TextMeshProUGUI>().text = firstPlayerScore.ToString();
        }

        var secondPlayerScoreText = betweenRoundsScreen.transform.Find("SecondPlayerScore");
        if (secondPlayerScoreText != null)
        {
            secondPlayerScoreText.GetComponent<TextMeshProUGUI>().text = secondPlayerScore.ToString();
        }


    }


}
