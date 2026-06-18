using UnityEngine;

public class BackgroundSoundManager : MonoBehaviour
{
    public AudioSource backgroundMusic; // Укажи ссылку на AudioSource в инспекторе
    public float delay = 3f; // Задержка в секундах перед началом музыки

    void Start()
    {
        // Запускаем корутину, которая подождет 3 секунды и запустит музыку
        StartCoroutine(PlayMusicWithDelay());
    }

    private System.Collections.IEnumerator PlayMusicWithDelay()
    {
        yield return new WaitForSeconds(delay);
        if (backgroundMusic != null)
        {
            backgroundMusic.Play();
        }
        else
        {
            Debug.LogWarning("BackgroundSoundManager: Не назначен AudioSource для backgroundMusic!");
        }
    }
}