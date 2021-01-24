using UnityEngine.UI;
using UnityEngine;

public class Player : MonoBehaviour
{
    #region 欄位
    [Header("移動速度"),Range(0,100)]
    public float Speed = 10.5f;
    [Header("跳越高度"),Range(0,1000)]
    public int Jump = 100;
    [Header("是否在地板上"),Tooltip("是否在地板上")]
    public bool OnFloor;
    [Header("子彈")]
    public GameObject Bullet;
    [Header("子彈生成")]
    public Transform PointSpawn;
    [Header("子彈速度"), Range(0,5000)]
    public int BulletSpeed = 800;
    [Header("子彈傷害"), Range(0, 500)]
    public float BulletDamage = 50;
    [Header("開槍音效")]
    public AudioClip BulletAud;
    [Header("血量"),Range(0, 200)]
    public float hp = 100f;
    [Header("判定地面位置")]
    public Vector3 offset;
    [Header("判定地面半徑")]
    public float radius = 0.3f;
    [Header("血條文字")]
    public Text texthp;
    [Header("血量圖片")]
    public Image imghp;


    private AudioSource Aud;
    private Rigidbody2D Rig;
    private Animator Ani;
    private float hpMAX;

    /// <summary>
    /// 取得玩家水平軸向值
    /// </summary>
    public float  h ;
    #endregion

    //在 Unity 內繪製圖示
    private void OnDrawGizmos()
    {
        // 圖示 . 顏色 = 顏色
        Gizmos.color = new Color(1, 0, 0, 0.35f);
        //圖示 . 繪製球體(中心點，半徑)
        Gizmos.DrawSphere(transform.position + offset, radius);
    }

    public AudioClip soundkey;

    /// <summary>
    /// 感應物件
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "鑰匙")
        {
            //刪除物件
            Destroy(collision.gameObject);
            Aud.PlayOneShot(soundkey, Random.Range(1.2f, 1.5f));
        }
    }

    private void Update()
    {
        GetHorizontal();
        Move();
        Jumpz();
        Fire();
    }

    private void Start()
    {
        //剛體欄位=取得元件<剛體>()
        Rig = GetComponent<Rigidbody2D>();
        Ani = GetComponent<Animator>();
        Aud = GetComponent<AudioSource>();
        hpMAX = hp;
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
        //剛體.加速度=二維(水平*速度，原本加速度的Y)
        Rig.velocity =new Vector2 (h*Speed, Rig.velocity.y);
        //如果 玩家 按下 D 或者 右鍵 就執行{內容}
        if (Input.GetKeyDown(KeyCode.D)|| Input.GetKeyDown(KeyCode.RightArrow)) 
        {
            //transform 此腳本同一層的Transform元件
            //Rotation 角度在程式是localEulerAngles
            transform.localEulerAngles = Vector3.zero;
        }

        if (Input.GetKeyDown(KeyCode.A)|| Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.localEulerAngles =new Vector3(0,180,0);
        }
        //設定跑步動畫 水平不等於0
        Ani.SetBool("跑步開關", h != 0);
    }

    /// <summary>
    /// 跳躍
    /// </summary>
    private void Jumpz()
    {
        //OnFloor 等於 OnFloor==true
        //按下W 或 上 執行跳躍 並且 在地面上
        // onfloor || 兩邊都要
        if (OnFloor && Input.GetKeyDown(KeyCode.W)|| OnFloor && Input.GetKeyDown(KeyCode.UpArrow)) 
        {
            //AddForce = 增加推力
            Rig.AddForce(new Vector2(0, Jump));
            Ani.SetTrigger("跳躍開關");
        }
        //碰撞物件 = 2D 物理.覆蓋圖形(中心點，半徑，圖層)
        // 1<<圖層
        Collider2D hit = Physics2D.OverlapCircle(transform.position + offset, radius, 1 << 8);

        if (hit)
        {
            OnFloor = true;
        }
        else
        {
            OnFloor = false;
        }

        //動畫控制器.設定浮點數
        Ani.SetFloat("跳躍",Rig.velocity.y);
        Ani.SetBool("是否在地面上", OnFloor);
        
    }

    /// <summary>
    /// 開槍
    /// </summary>
    private void Fire()
    {
        //Mouse0 滑鼠左鍵
        if (Input.GetKeyDown(KeyCode.Mouse0)) 
        {
            //子彈音效
            Aud.PlayOneShot(BulletAud, Random.Range(1.2f, 1.5f));
            //生成(物件，生成位置，生成角度)
            GameObject temp = Instantiate(Bullet,PointSpawn.position,PointSpawn.rotation);
            //暫存子彈 . 取得元件 <剛體> 
            temp.GetComponent<Rigidbody2D>().AddForce(PointSpawn.right * BulletSpeed + PointSpawn.up * 100);
            //暫存子彈 . 添加元件 <子彈> () . 攻擊 = 子彈傷害
            temp.AddComponent<Bullet>().attack = BulletDamage;
        }
    }

    /// <summary>
    /// 受傷
    /// </summary>
    public void Hurt(float GetDamage)
    {
        hp -= GetDamage;                   //遞減
        texthp.text = hp.ToString();
        imghp.fillAmount = hp / hpMAX;
        if (hp <= 0) Dead();
    }

    /// <summary>
    /// 死亡
    /// </summary>
    private void Dead()
    {
        hp = 0;
        texthp.text = 0.ToString();
        Ani.SetBool("死亡開關", true);
        enabled = false;
    }
    #endregion
}
