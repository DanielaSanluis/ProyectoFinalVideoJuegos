using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    private static MusicPlayer instancia;

    void Awake()
    {
        if (instancia == null)
        {
            instancia = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void ToggleMusica()
    {
        AudioSource audio = GetComponent<AudioSource>();
        if (audio.isPlaying)
        {
            audio.Pause();
            Debug.Log("M�sica pausada");
        }
        else
        {
            audio.Play();
            Debug.Log("M�sica reanudada");
        }
    }

}

