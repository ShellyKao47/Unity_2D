using UnityEngine;
using UnityEngine.Audio; //音源管理

public class SoundManager : MonoBehaviour
{
    [Header("音源管理")]
    public AudioMixer mixer;

    /// <summary>
    /// 背景音樂 音量
    /// </summary>
    public void VBGM (float v)
    {
        mixer.SetFloat("VBGM",v);
    }

    /// <summary>
    /// 音效 音量
    /// </summary>
    public void VSFX(float v)
    {
        mixer.SetFloat("VSFX",v);
    }
}
