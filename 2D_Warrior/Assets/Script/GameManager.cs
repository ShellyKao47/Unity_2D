using UnityEngine;

public class GameManager : MonoBehaviour
{
    private Player player;

    private void Awake()
    {
        player = FindObjectOfType<Player>();
    }
    /// <summary>
    /// 設定時暫停
    /// </summary>
    public void PauseGame()
    {
        Time.timeScale = 0;
        player.enabled = false;
    }

    /// <summary>
    /// 重新開始
    /// </summary>
    public void RestartGame()
    {
        Time.timeScale = 1;
        player.enabled = true;
    }
}
