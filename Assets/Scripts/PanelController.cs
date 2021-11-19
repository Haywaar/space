using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PanelController : MonoBehaviour
{
    public Text LastScore;

    public Text HighScore;
    
    private void Start()
    {
        float lastScore = PlayerPrefs.GetFloat("LastScore");
        LastScore.text = "Последний результат:" + 
                         lastScore.ToString();
        if (lastScore > PlayerPrefs.GetFloat("HighScore"))
        {
            PlayerPrefs.SetFloat("HighScore", lastScore);
        }

        HighScore.text = "Лучший результат: " + 
                         PlayerPrefs.GetFloat("HighScore").ToString();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }
}