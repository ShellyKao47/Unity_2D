using UnityEngine;

public class TeleportMenager : MonoBehaviour
{
    [Header("傳送到的點")]
    public Transform TeleportPoint;
    private Transform Player;
    private bool PlayerIn;

    private void Teleport()
    {
        if (PlayerIn&&Input.GetKeyDown(KeyCode.W)|| PlayerIn && Input.GetKeyDown(KeyCode.UpArrow))
        {
            Player.position = TeleportPoint.position+Vector3.up*0.5f;
        }
    }

    private void Awake()
    {
        Player = GameObject.Find("人物").transform;
    }

    private void Update()
    {
        Teleport();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "人物") PlayerIn = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name == "人物") PlayerIn = false;
    }
}
