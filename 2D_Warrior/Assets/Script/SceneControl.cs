using UnityEngine;
using UnityEngine.SceneManagement; //控制場景

public class SceneControl : MonoBehaviour
{

    public AudioSource aud;
    public AudioClip soundclick;
    
    /// <summary>
    /// 開始遊戲
    /// </summary>
    public void StartGame()
    {
        //音效來源
        aud.PlayOneShot(soundclick);

    }
    private void DelayStartGame()
    {
        SceneManager.LoadScene("遊戲場景");
    }

    /// <summary>
    /// 返回選單
    /// </summary>
    public void BackToMenu()
    {
        SceneManager.LoadScene("選單");
    }
    /// <summary>
    /// 離開遊戲
    /// </summary>
    public void QuitGame()
    {
        Application.Quit();
    }
}
