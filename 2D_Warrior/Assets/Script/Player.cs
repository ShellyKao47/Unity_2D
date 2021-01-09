
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
    [Header("開槍音效")]
    public AudioClip BulletAud;
    [Header("血量"),Range(0, 200)]
    public float HP = 100f;
    private AudioSource Aud;
    private Rigidbody2D Rig;
    private Animator Ani;
  
    /// <summary>
    /// 取得玩家水平軸向值
    /// </summary>
    public float  h ;
    #endregion

    private void Update()
    {
        GetHorizontal();
        Move();
    }

    private void Start()
    {
        //剛體欄位=取得元件<剛體>()
        Rig = GetComponent<Rigidbody2D>();
    }
    #region 方法
    /// <summary>
    /// 取得水平軸向
    /// </summary>
    private void GetHorizontal()
    {
        //輸入.取得軸向("水平")
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
