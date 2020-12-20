
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("移動速度"),Range(0f,1000f)]
    public float Speed = 10.5f;
    [Header("跳越高度"),Range(0,3000)]
    public int Jump = 100;
    [Header("是否在地板上"),Tooltip("是否在地板上")]
    public bool OnFloor = false;
    [Range(0,5000)]
    public int BulletSpeed = 800;
    public AudioClip BulletAudio;
    public int HP = 100;
    public AudioSource AudioSource;
    public Rigidbody2D Rigidbody2D;
    public Animator Animator;
}
