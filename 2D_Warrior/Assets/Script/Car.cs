
using UnityEngine;

public class Car : MonoBehaviour
{
    #region 練習欄位
    [Header("高度"),Range(1,10)]
    [Tooltip("公尺")]
    public int height = 10;
    [Header("重量"),Range(2.5f,10.5f)]
    public float weight = 5.5f;
    [Header("品牌")]
    public string brand = "BMW";
    [Header("是否有天窗")]
    public bool hastopwindow = true ;

    public Color red = Color.red;
    public Color Color;
    public Vector2 Vector2;
    public GameObject obj;
    public Transform tra;
    #endregion
    //藍色:事件
    #region 練習方法
    private void Test()
    {
        print("哈囉~");
    }

    private int Five()
    {
        return 10;
    }

    private float Onepointfive()
    {
        return 1.5f;
    }

    private string Name()
    {
        return "Shelly";
    }


    /// <summary>
    /// 開車方法
    /// </summary>
    /// <param name="direction"></param>
    private void Drive(string direction,string sound,int speed)
    {
        print("開車方向:" + direction);
        print("開車音效:"+sound);
        print("開車速度:" + speed);
    }


    private void OpenBrush(string sound,int count=2,int speed= 50)
    {
        print("雨刷聲音:" + sound);
        print("開雨刷");
        print("雨刷速度:"+speed);
        print("雨刷數量" + count);
    }
    #endregion

    private void Start()
    {
        //呼叫欄位
        print("品牌:" + brand);
        print("高度:" + height);
        //設定欄位
        hastopwindow = false;
        weight = 10;
        //呼叫事件

        Test();
        //直接呼叫
        print("整數" + Five() );
        print("浮點數" + Onepointfive());
        //定義後呼叫
        string MyName = Name();
        print (MyName);


        Drive("前面","咻咻咻",100);
        Drive("後面", "噗噗噗", 30);
        Drive("左邊", "噗噗噗", 50);
        Drive("右邊", "噗噗噗", 50);

        //指定參數 參數:值
        OpenBrush("刷刷",speed:500);
    }
}
