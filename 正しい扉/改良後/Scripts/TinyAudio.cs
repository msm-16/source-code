using UnityEngine;

public class TinyAudio : MonoBehaviour
{
    public static TinyAudio Instance;
    /// <summary>
    /// seListに設定する効果音の種類を以下に定義します。
    /// </summary>
    public enum SE
    {
        Get,
        Open,
        Miss,
        Clear,
        Gameover,
    }
    [Tooltip("効果音のAudio Clipを、SEの列挙子と同じ順番で設定してください。"), SerializeField]
    AudioClip[] seList;

    public enum BGM
    {
        Title,
        Game,
    }
    [Tooltip("効果音のAudio Clipを、BGMの列挙子と同じ順番で設定してください。"), SerializeField]
    AudioClip[] bgmList;

    AudioSource audioSource;
    private void Awake()
    {
        Instance = this;
        audioSource = GetComponent<AudioSource>();
    }
    /// <summary>
    /// SEで指定した効果音を再生します。
    /// </summary>
    /// <param name="se">鳴らしたい効果音</param>
    public static void PlaySE(SE se)
    {
        Instance.audioSource.PlayOneShot(Instance.seList[(int)se]);
    }

    public static void StopBGM()
    {
        Instance.audioSource.Stop();
    }

    public static void PlayBGM(BGM bgm)
    {
        StopBGM();
        Instance.audioSource.clip = Instance.bgmList[(int)bgm];
        Instance.audioSource.Play();
    }
}
