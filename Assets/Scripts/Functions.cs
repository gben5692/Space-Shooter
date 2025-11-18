using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Functions : MonoBehaviour
{
    [SerializeField] TMP_Text ControlT;
    [SerializeField] PlayerController player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("SpaceShooter");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    public void RestartGame()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void ShowControls()
    {
        SceneManager.LoadScene("Controls");
    }

}
