using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameAudioManager : MonoBehaviour
{
    [SerializeField] AudioSource SFX;

    public AudioClip fireball;
    public AudioClip enemy_grunt;
    public AudioClip enemy_death;
    public AudioClip player_grunt;
    public AudioClip player_death;
    public AudioClip player_attack;
    public AudioClip player_heal;

    public void PlaySFX(AudioClip clip)
    {
        SFX.PlayOneShot(clip);
    }
}
