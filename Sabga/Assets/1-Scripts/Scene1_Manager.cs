using DG.Tweening;
using System.Collections;
using UnityEngine;

public class Scene1_Manager : MonoBehaviour
{
    [SerializeField] private GameObject seagull;
    [SerializeField] private AudioSource[] audios;

    public Transform landingPosition;
    public float landingSpeed;
    public float takeoffSpeed;

    private void Start()
    {
        seagull.transform.DOMove(landingPosition.position, landingSpeed).OnComplete(() =>
        {
            StartCoroutine(PlayThunder());
        });
    }

    private IEnumerator PlayThunder()
    {

        yield return new WaitForSeconds(takeoffSpeed);

    }

    private void PlaySeagulSound()
    {
        audios[0].Play();
    }

    private void PlayWingsSound()
    {
        audios[1].Play();
    }
}