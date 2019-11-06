using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager>
{
    public GameObject RoundStartUI;
    public GameObject RoundOverUI;
    public Text roundWinnerText;

    public Text countdownText;
    public void UpdateCountdownUI(float count)
    {
        if (RoundStartUI != null)
        {
            RoundStartUI.SetActive(true);
            countdownText.text = count.ToString("F0") + "s";
        }
    }

    public void StopCountdownUI()
    {
        if (RoundStartUI != null)
        {
            RoundStartUI.SetActive(false);
            countdownText.text = 0.ToString();
        }
    }

    public void OpenRoundWinnerUI(string roundWinner)
    {
        if (RoundOverUI != null)
        {
            RoundOverUI.SetActive(true);
            roundWinnerText.text = roundWinner + " is the winner!";
        }
    }

    public void CloseRoundWinnerUI()
    {
        if (RoundOverUI != null)
        {
            RoundOverUI.SetActive(false);
            roundWinnerText.text = "";
        }
    }
}
