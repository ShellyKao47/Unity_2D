
using UnityEngine;

public class Player : MonoBehaviour
{
    #region 欄位
    [Header("移動速度"),Range(0,1000)]
    public float Speed = 10.5f;
    [Header("跳越高度"),Range(0,3000)]
    public int Jump = 100;
    [Header("是否在地板上"),Tooltip("是否在地板上")]
    public bool OnFloor;
    [Header("子彈")]
    public GameObject Bullet;
    [Header("子彈生成")]
    public Transform PointSpawn;
    [Header("子彈速度"), Range(0,5000)]
    public int BulletSpeed = 800;
    [Header("開槍音效"), Tooltip("開槍音效")]
    public AudioClip BulletAud;
    [Header("血量"),Range(0, 200)]
    public float HP = 100f;
    private AudioSource Aud;
    private Rigidbody2D Rig;
    private Animator Ani;
    #endregion

    public float  h ;

    private void Update()
    {
        GetHorizontal();
        Move();
    }

    private void Start()
    {
        Rig = GetComponent<Rigidbody2D>();
    }
    #region 方法
    private void GetHorizontal()
    {
        h = Input.GetAxis("Horizontal");
    }

    /// <summary>
    /// 移動
    /// </summary>
    private void Move()
    {
        Rig.velocity =new Vector2 (h*Speed, Rig.velocity.y);
    }

    /// <summary>
    /// 跳躍
    /// </summary>
    private void Jumpz()
    {

    }

    /// <summary>
    /// 開槍
    /// </summary>
    private void Fire()
    {

    }

    /// <summary>
    /// 受傷
    /// </summary>
    private void Hurt(float GetDamage)
    {

    }

    /// <summary>
    /// 死亡
    /// </summary>
    private void Dead()
    {

    }
    #endregion
}
