using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StartingScreen : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI objectiveText;

    [SerializeField]
    private TextMeshProUGUI countDownText;


    private void Start()
    {
        StartCoroutine(CountDown(5));
    }

    private IEnumerator CountDown(int starting)
    {
        for (; starting > 0; starting--)
        {
            countDownText.text = starting.ToString();

            yield return new WaitForSeconds(1f);
        }


    }

    public void SetObjectiveText(string objective)
    {
        objectiveText.text = "Objective:\n" + objective;
    }
}