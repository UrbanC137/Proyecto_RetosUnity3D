using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI puntoTotalText;
    private int totalScore = 0;

    public void AddPoints(int points)
    {
        totalScore += points;
        UpdateScoreUI();
    }

    private void UpdateScoreUI()
    {
        puntoTotalText.text = "Total: " + totalScore.ToString();
    }
}