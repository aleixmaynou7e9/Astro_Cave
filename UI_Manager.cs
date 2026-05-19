using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_Manager : MonoBehaviour
{
   
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StartGame()
    {
        SceneManager.LoadScene("GameScene");
    }
    public void Die()
    {
        SceneManager.LoadScene("LoseScene");
    }
    public void Win()
    {
        SceneManager.LoadScene("WinScene");
    }
    public void Intro()
    {
        SceneManager.LoadScene("Intro");
    }
}
