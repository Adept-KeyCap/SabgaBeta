using DG.Tweening;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Scene1_Manager : MonoBehaviour
{
    public UnityEvent sceneCleared;

    [SerializeField] private GameObject seagull;
    [SerializeField] private AudioSource[] audios;

    public Transform landingPosition;
    public float landingSpeed;
    public float takeoffSpeed;

    private void Start()
    {
        seagull.transform.DOMove(landingPosition.position, landingSpeed).SetEase(Ease.InCubic).OnComplete(() =>
        {
            StartCoroutine(PlayThunder());
            DOTween.Kill(seagull.transform);
        });
    }

    private IEnumerator PlayThunder()
    {

        yield return new WaitForSeconds(takeoffSpeed);
        seagull.transform.DOMove(new Vector3(-100, 100, 100), landingSpeed).SetEase(Ease.InCubic).OnComplete(() =>
        {
            sceneCleared.Invoke();
            PlayThunderSound();
            DOTween.Kill(seagull.transform);
        });
    }

    private void PlayThunderSound()
    {
        audios[0].Play();
    }

}