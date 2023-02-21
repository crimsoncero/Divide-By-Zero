using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{

    public TextMeshProUGUI ScoreText;

    public AudioSource UIOpenSFX;
    public AudioSource UIButtonPressSFX;
    
    // Start is called before the first frame update
    void Start()
    {
        ScoreText.text = "0";
    }

    // Update is called once per frame
    void Update()
    {
        ScoreText.text = $"{GameManager.Instance.Score}";
    }


    public void RestartGame()
    {
        UIButtonPressSFX.Play();
        SceneManager.LoadScene(1);
    }
    public void ReturnToMainMenu()
    {
        UIButtonPressSFX.Play();
        SceneManager.LoadScene(0);
    }

    public void PauseGame()
    {
        UIButtonPressSFX.Play();
        GameManager.Instance.GamePause(true);
    }

    public void ResumeGame()
    {
        UIButtonPressSFX.Play();
        GameManager.Instance.GamePause(false);
    }
}
