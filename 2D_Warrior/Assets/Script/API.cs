using UnityEngine;

public class API : MonoBehaviour
{
    public Transform TraA;
    public Transform Tester;
    public SpriteRenderer spr;
    public Camera cam;
    public GameObject gam;

    private void Start()
    {
        print("座標：" + TraA.position);

       // Tester.position = new Vector3(2, 0, 0);

        cam.backgroundColor = new Color(0.3f, 0.5f, 0.5f);
        //練習
        spr.flipX = true;
        gam.layer = 5;
        print("顏色：" + spr.color);
        print("圖層：" + gam.layer);

    }
    private void Update()
    {
        Tester.Rotate(0, 0.5f, 0);
        Tester.Translate(2, 0, 0, Space.World);
    }
}
