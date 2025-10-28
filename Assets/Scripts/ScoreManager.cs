using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{

    [SerializeField] TMP_Text Score;
    public int totalScore = 0; // This will hold the total score
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AddScore(int score)
    {
        totalScore += score;
        Score.text = $"Score: {totalScore}";

        PlayerPrefs.SetInt("Score", totalScore);
        PlayerPrefs.Save();
    }
}
