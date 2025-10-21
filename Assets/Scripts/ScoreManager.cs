using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{

    [SerializeField] TMP_Text Score;
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
        Score.text = $"Score: {score}";
    }
}
