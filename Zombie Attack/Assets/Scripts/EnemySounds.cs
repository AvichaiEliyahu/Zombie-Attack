using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SOUND_TYPE{ ENGAGE, ATTACK, HIT, DEATH}
public class EnemySounds : MonoBehaviour
{
    [SerializeField] AudioClip[] engageSounds;
    [SerializeField] AudioClip[] attackSounds;
    [SerializeField] AudioClip[] hitSounds;
    [SerializeField] AudioClip[] deathSounds;

    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlaySounds(SOUND_TYPE type)
    {
        if (audioSource.isPlaying)
            return;
        switch (type)
        {
            case SOUND_TYPE.ENGAGE:
                PlayEngageSound();
                break;
            case SOUND_TYPE.ATTACK:
                PlayAttackSound();
                break;
            case SOUND_TYPE.HIT:
                PlayHitSound();
                break;
            case SOUND_TYPE.DEATH:
                PlayDeathSound();
                break;
            default:
                return;
        }
    }

    private void PlayAttackSound()
    {
        int randomSound = UnityEngine.Random.Range(0, attackSounds.Length);
        audioSource.clip = attackSounds[randomSound];
        audioSource.Play();
    }

    private void PlayEngageSound()
    {
        int chanceToPlay = UnityEngine.Random.Range(0, 200);
        if (chanceToPlay == 1)
        {
            int randomSound = UnityEngine.Random.Range(0, engageSounds.Length);
            audioSource.clip = engageSounds[randomSound];
            audioSource.Play();
        }
    }

    private void PlayHitSound()
    {
        int randomSound = UnityEngine.Random.Range(0, hitSounds.Length);
        audioSource.clip = hitSounds[randomSound];
        audioSource.Play();
    }

    private void PlayDeathSound()
    {
        int randomSound = UnityEngine.Random.Range(0, deathSounds.Length);
        audioSource.clip = deathSounds[randomSound];
        audioSource.Play();
    }

}
