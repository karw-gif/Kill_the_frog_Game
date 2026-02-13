using UnityEngine;
using System.Collections;
using TMPro;

public class GameOverScreen : MonoBehaviour
{
    public TextMeshProUGUI scorePointsText;
    public TextMeshProUGUI missedPointsText;

    public void Setup(int score, int missed)
    {
        gameObject.SetActive(true);
        scorePointsText.text = score.ToString() + " Points";
        missedPointsText.text = missed.ToString() + " missed";
    }
}

