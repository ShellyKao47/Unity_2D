using UnityEngine;
using UnityEngine.SceneManagement; //控制場景

public class SceneControl : MonoBehaviour
{

    [Header("音效來源")]
    public AudioSource aud;
    [Header("按鈕音效")]
    public AudioClip soundclick;
    
    /// <summary>
    /// 開始遊戲
    /// </summary>
    public void StartGame()
    {
        //音效來源
        aud.PlayOneShot(soundclick,2);
        //延遲呼叫
        Invoke("DelayStartGame", 1.5f);
    }

    /// <summary>
    /// 延遲開始遊戲
    /// </summary>
    private void DelayStartGame()
    {
        //場景管理器.載入場景("場景名稱")
        SceneManager.LoadScene("遊戲場景");
    }

    /// <summary>
    /// 返回選單
    /// </summary>
    public void BackToMenu()
    {
        aud.PlayOneShot(soundclick,2);
        Invoke("DelayBackToMenu", 1.5f);
    }
    /// <summary>
    /// 離開遊戲
    /// </summary>
    public void QuitGame()
    {
        aud.PlayOneShot(soundclick,2);
        Invoke("DelayQuitGame", 1.5f);
    }
    
    /// <summary>
    /// 延遲返回選單
    /// </summary>
    private void DelayBackToMenu()
    {
        SceneManager.LoadScene("選單");
    }

    private void DelayQuitGame()
    {
        Application.Quit();
    }
}
