using UnityEngine;

// <summary>
/// 認識 API 靜態
/// </summary>

public class APIststic : MonoBehaviour
{
    
    private void Start()
    {
        #region 靜態屬性存取
        //類別名稱.靜態屬性
        print("隨機值:"+Random.value);
        print("拍" + Mathf.PI);

        Cursor.visible = false;
        #endregion
        #region 使用靜態方法
    

    print( "介於隨機值" + Random.Range(100,500));
        #endregion

        print("攝影機數量"+Camera.allCamerasCount);
        print("重力大小" + Physics2D.gravity);

        int number = Mathf.Abs(-99);
        print("取完絕對值的整數：" + number);

        // 練習區域：設定靜態屬性
        Physics2D.gravity = new Vector2(0, -20);

        // 練習區域：使用靜態方法
        Application.OpenURL("https://unity.com/");

        print("9.999 去小數點：" + Mathf.Floor(9.999f));

        print("兩點的距離：" + Vector3.Distance(new Vector3(1, 1, 1), new Vector3(22, 22, 22)));


    }


    private void Update()
    {
        print("哈囉");

        print("按下任意鍵" + Input.anyKeyDown);
        print("遊戲時間" + Time.time);
        print("是否按下空白鍵" + Input.GetKeyDown("space"));

    }
}
