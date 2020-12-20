
using UnityEngine;

public class Car : MonoBehaviour
{
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
}
