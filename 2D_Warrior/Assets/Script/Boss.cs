using UnityEngine;


[RequireComponent(typeof(AudioSource), typeof(Rigidbody2D), typeof(CapsuleCollider2D))]
public class Boss : MonoBehaviour
{
    [Header("移動速度"), Range(0, 1000)]
    public float speed = 10;
    [Header("攻擊範圍"), Range(0, 100)]
    public float rangeatk = 50;
    [Header("攻擊力"), Range(0, 1000)]
    public float attack = 250;
    [Header("血量"), Range(0, 5000)]
    public float hp = 2500;

    private Animator Ani;
    private AudioSource Aud;
    private Rigidbody2D Rig;

    private void Start()
    {
        Rig = GetComponent<Rigidbody2D>();
        Ani = GetComponent<Animator>();
        Aud = GetComponent<AudioSource>();
    }

    /// <summary>
    /// 受傷
    /// </summary>
    /// <param name="damage"></param>
    public void Damage(float damage)
    {
        hp -= damage;                   //遞減
        Ani.SetTrigger("受傷觸發");     //受傷動畫
    }
}
