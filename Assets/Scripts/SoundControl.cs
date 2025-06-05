using UnityEngine;

public class SoundControl : MonoBehaviour
{
    public AudioClip jump;
    public AudioClip gold;
    public AudioClip finishGame;
    
    AudioSource audioSource;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void JumpSound()
    {
        audioSource.clip = jump;
        audioSource.Play();
    }

    public void GoldSound()
    {
        audioSource.clip = gold;
        audioSource.Play();
    }

    public void FinishGameSound()
    {
        audioSource.clip = finishGame;
        audioSource.Play();
    }
}
