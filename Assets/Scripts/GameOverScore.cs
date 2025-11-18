using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameOverScore : MonoBehaviour
{
    public ScoreManager ScoreManager;
    [SerializeField] TMP_Text FinalScoreText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ScoreManager = FindFirstObjectByType<ScoreManager>();

        int score = PlayerPrefs.GetInt("Score", 0);
        FinalScoreText.text = $"Score: {score}";
        StartCoroutine(MainMenu(5));
    }

    // Update is called once per frame
    
    void Update()
    {
    }
    
    IEnumerator MainMenu(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        SceneManager.LoadScene("MainMenu");
    }
}
