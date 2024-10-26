using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Scene0_Manager : MonoBehaviour
{
    [Tooltip("0_Campana\n1_Niños Hablando\n2_Brisa\n3_Dialogo Profe")]
    [SerializeField] private List<AudioSource> audios = new List<AudioSource>();

    public float time2play_AmbientAudio;
    public float time2play_TeacherDialog;

    [Range(0.05f, 1f)]
    public float downscale_VolumeFactor;

    public UnityEvent dialogFinished;

    void Start()
    {
        StartCoroutine(PlayChatterAudio());
    }

    private IEnumerator PlayChatterAudio()
    {

        yield return new WaitForSeconds(time2play_AmbientAudio);
        audios[1].Play();
        audios[2].Play();

        yield return new WaitForSeconds(time2play_TeacherDialog);
        StartCoroutine(PlayTeacherAudio());
    }

    private IEnumerator PlayTeacherAudio()
    {
        audios[1].DOFade(audios[1].volume * downscale_VolumeFactor, time2play_TeacherDialog);
        audios[2].DOFade(audios[2].volume * downscale_VolumeFactor, time2play_TeacherDialog);

        yield return new WaitForSeconds(time2play_TeacherDialog);
        
        audios[3].Play();

        yield return new WaitForSeconds(audios[3].clip.length + 2);

        dialogFinished.Invoke();
    }
}
