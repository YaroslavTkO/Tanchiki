using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private GameObject betweenRoundsScreenPrefab;
    [SerializeField]
    private GameObject endGameScreenPrefab;

    private GameObject betweenRoundsScreen;
    private GameObject endGameScreen;

    public void OpenBetweenRoundsScreen(int firstPlayerScore, int secondPlayerScore)
    {
        betweenRoundsScreen = Instantiate(betweenRoundsScreenPrefab, transform);
        SetBetweenRoundsScoreTexts(firstPlayerScore, secondPlayerScore);
    }

    private void SetBetweenRoundsScoreTexts(int firstPlayerScore, int secondPlayerScore)
    {
        var firstPlayerScoreText = betweenRoundsScreen.transform.Find("FirstPlayerScore");
        if (firstPlayerScoreText != null)
        {
            firstPlayerScoreText.GetComponent<TextMeshProUGUI>().text = firstPlayerScore.ToString();
        }
        var secondPlayerScoreText = betweenRoundsScreen.transform.Find("SecondPlayerScore");
        if (secondPlayerScoreText != null)
        {
            secondPlayerScoreText.GetComponent<TextMeshProUGUI>().text = secondPlayerScore.ToString();
        }


    }
    
    public void OpenEndGameScreen(int firstPlayerScore, int secondPlayerScore)
    {
        endGameScreen = Instantiate(endGameScreenPrefab, transform);
        SetEndGameScoreText(firstPlayerScore, secondPlayerScore);
    }

    private void SetEndGameScoreText(int firstPlayerScore, int secondPlayerScore)
    {
        var textObject = endGameScreen.transform.Find("ResultsText");
        if(textObject != null)
        {
            textObject.GetComponent<TextMeshProUGUI>().text = firstPlayerScore.ToString() + " : " + secondPlayerScore.ToString();
        }


    }


}
