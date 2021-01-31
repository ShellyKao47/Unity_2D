using UnityEngine;
using UnityEngine.UI; //引用介面
using UnityEngine.Events; //引用事件
using System.Collections; //協同程序需要 

[RequireComponent(typeof(AudioSource), typeof(Rigidbody2D), typeof(CapsuleCollider2D))]
public class Boss : MonoBehaviour
{
    [Header("移動速度"), Range(0, 1000)]
    public float speed = 10;
    [Header("攻擊範圍"), Range(0, 100)]
    public float rangeatk = 2.7f;
    [Header("攻擊力"), Range(0, 1000)]
    public float attack = 10f;
    [Header("攻擊冷卻"), Range(0, 5)]
    public float attackCD = 2.5f;
    [Header("攻擊延遲"), Range(0, 5)]
    public float attackdelay = 0.5f;
    [Header("血量"), Range(0, 5000)]
    public float hp = 2500f;
    [Header("血條文字")]
    public Text texthp;
    [Header("血量圖片")]
    public Image imghp ;
    [Header("攻擊範圍位移")]
    public Vector3 offsetAttack;
    [Header("攻擊範圍大小")]
    public Vector3 sizeAttack;
    [Header("死亡事件")]
    public UnityEvent onDead;

    private Animator Ani;
    private AudioSource Aud;
    private Rigidbody2D Rig;
    private float hpMAX;
    private Player player;
    private float timer;
    private CameraControl2D cam;
    private bool isSecond;
    private ParticleSystem psSecond;


    private void Start()
    {
        Rig = GetComponent<Rigidbody2D>();
        Ani = GetComponent<Animator>();
        Aud = GetComponent<AudioSource>();
        hpMAX = hp;
        player = FindObjectOfType<Player>();
        cam = FindObjectOfType<CameraControl2D>();
        psSecond = GameObject.Find("BossRock").GetComponent<ParticleSystem>();
    }
    private void Update()
    {
        if (Ani.GetBool("死亡開關")) return;
        Move();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(0, 1, 1, 0.5f);
        Gizmos.DrawCube(transform.position + transform.right*offsetAttack.x + transform.up * offsetAttack.y, sizeAttack);

        Gizmos.color = new Color(1, 0, 0, 0.5f);
        Gizmos.DrawSphere(transform.position, rangeatk);
    }

    /// <summary>
    /// 受傷
    /// </summary>
    /// <param name="Damage"></param>
    public void Damage(float damage)
    {
        hp -= damage;                   //遞減
        Ani.SetTrigger("受傷觸發");     //受傷動畫
        texthp.text = hp.ToString();
        imghp.fillAmount = hp / hpMAX;

        if (hp <= hpMAX * 0.8)
        {
            isSecond = true;
            rangeatk = 12;
        }
        if (hp <= 0) Dead();
    }

    /// <summary>
    /// 死亡
    /// </summary>
    /// <param name="Dead"></param>
    private void Dead()
    {
        onDead.Invoke();                                        //觸發 死亡 事件

        hp = 0;
        texthp.text = 0.ToString();
        Ani.SetBool("死亡開關", true);
        GetComponent<CapsuleCollider2D>().enabled = false;
        Rig.Sleep();                                            //剛體.睡著
        Rig.constraints = RigidbodyConstraints2D.FreezeAll;     //剛體.凍結 X,Y,Z
    }

    private void Move()
    {
        //受傷 攻擊 停止移動
        AnimatorStateInfo info = Ani.GetCurrentAnimatorStateInfo(0);
        if (info.IsName("香菇攻擊") || info.IsName("香菇受傷")) return;

        //三元運算子 布林值 ? 結果1 ： 結果2
        float y = transform.position.x >= player.transform.position.x ? 180 :0;
        transform.eulerAngles= new Vector3(0, y, 0);
        
        //距離 . 二維座標 
        float dis = Vector2.Distance(transform.position, player.transform.position);

        if (dis>rangeatk)
        {
            //移動座標 * 一幀時間 * 速度
            Rig.MovePosition(transform.position + transform.right * Time.deltaTime * speed); 
        }
        else
        {
            Attack();
        }

        //動畫 走路 加速度 . 值 > 0
        Ani.SetBool("走路開關", Rig.velocity.magnitude > 0);
    }

    private void Attack()
    {
        Rig.velocity = Vector3.zero;
     

        if (timer<attackCD)                 //如果 計時器 < 攻擊冷卻
        {
            timer += Time.deltaTime;        //累加計時器
        }
        else
        {
            Ani.SetTrigger("攻擊觸發");     
            timer = 0;                      //計時器歸零
            StartCoroutine(DelayDamage());
        }
    }

    private IEnumerator DelayDamage()
    {
        yield return new WaitForSeconds (attackdelay);
        Collider2D hit = Physics2D.OverlapBox(transform.position + transform.right * offsetAttack.x + transform.up * offsetAttack.y, sizeAttack, 0, 1 << 9);
        if (hit) player.Hurt(attack);
        StartCoroutine(cam.Shake());
        if (isSecond) psSecond.Play();           
    }
}
