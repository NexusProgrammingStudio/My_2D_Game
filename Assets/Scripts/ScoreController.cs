using UnityEngine;
using TMPro;

public class ScoreController : MonoBehaviour
{
    // Start is called before the first frame update
    private TextMeshProUGUI scoreText;
    private int score = 0;
    private void Awake()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
        scoreText.text = "Score: " + score;
    }

    public void IncrementScore(int increment)
    {
        score += increment;
        RefreshUI();
    }

    private void RefreshUI()
    {
        scoreText.text = "Score: " + score;
    }
    
}
