using DG.Tweening;
using UnityEngine;

public class Scene1_Manager : MonoBehaviour
{
    [SerializeField] private GameObject seagull;
    [SerializeField] private AudioSource[] audios;

    private Sequence seagulSequence;
    public Transform landingPosition;

    private void Start()
    {

    }

    private void PlaySeagulSound()
    {
        audios[0].Play();
    }


    private void PlayInteractionClue()
    {
        audios[1].Play();
    }

    private void PlayWingsSound()
    {
        audios[2].Play();
    }
}