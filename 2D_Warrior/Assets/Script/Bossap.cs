using UnityEngine;

public class Bossap : MonoBehaviour
{
    [Header("魔王血條")]
    public GameObject bl;
    [Header("魔王")]
    public GameObject bossap;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name=="人物")
        {
            bl.SetActive(true);
            bossap.SetActive(true);
        }
    }
}
