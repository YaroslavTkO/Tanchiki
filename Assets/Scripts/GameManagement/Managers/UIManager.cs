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
    [SerializeField]
    private GameObject pauseScreenPrefab;
    [SerializeField]
    private GameObject pauseButtonPrefab;
    [SerializeField]
    private GameObject startingScreenPrefab;


    private GameObject betweenRoundsScreen;
    private GameObject endGameScreen;
    private GameObject pauseScreen;
    private GameObject pauseButton;

    private void Awake()
    {
        InstantiatePauseButton();
    }

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
        AudioManager.Instance.PlaySound("EndGame");
        endGameScreen = Instantiate(endGameScreenPrefab, transform);
        SetEndGameScoreText(firstPlayerScore, secondPlayerScore);
    }

    private void SetEndGameScoreText(int firstPlayerScore, int secondPlayerScore)
    {
        var textObject = endGameScreen.transform.Find("ResultsText");
        if(textObject != null)
        {
            textObject.GetComponent<TextMeshProUGUI>().text = firstPlayerScore > secondPlayerScore ? "Won | Lost" : "Lost | Won";
        }


    }

    public void OpenPauseScreen()
    {
        pauseScreen = Instantiate(pauseScreenPrefab, transform);
        var continueButton = pauseScreen.transform.Find("Continue");
        if(continueButton != null)
        {
            continueButton.GetComponent<Button>().onClick.AddListener(ClosePauseScreen);
        }
        
        Time.timeScale = 0;

    }

    private void ClosePauseScreen()
    {
        Time.timeScale = 1;
        Destroy(pauseScreen);
    }

    private void InstantiatePauseButton()
    {
        pauseButton = Instantiate(pauseButtonPrefab, transform);
        pauseButton.GetComponent<Button>().onClick.AddListener(OpenPauseScreen);
    }

    public void OpenStartingScreen(string objectiveText)
    {
        var startingScreen = Instantiate(startingScreenPrefab, transform);
        startingScreen.GetComponent<StartingScreen>().SetObjectiveText(objectiveText);
    }


}
