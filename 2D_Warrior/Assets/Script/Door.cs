using UnityEngine;

public class Door : MonoBehaviour
{
    [Header ("鑰匙")]
    public GameObject  Key;

    private Animator ani;
    private AudioSource aud;
    public AudioClip soundopen;
    private void Start()
    {
        ani = GetComponent<Animator>();
        aud = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name=="人物"&&Key==null)
        {
            ani.SetTrigger("開門");
            aud.PlayOneShot(soundopen, Random.Range(1.2f, 1.5f));
        }
    }
}
