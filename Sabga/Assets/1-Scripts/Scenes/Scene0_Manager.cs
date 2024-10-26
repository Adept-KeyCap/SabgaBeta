using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene0_Manager : MonoBehaviour
{
    [Tooltip("0_Campana\n1_Niños Hablando\n2_Brisa\n3_Dialogo Profe")]
    [SerializeField] private List<AudioSource> audios = new List<AudioSource>();

    public float time2play_AmbientAudio;
    public float time2play_TeacherDialog;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private IEnumerator playChatterAudio()
    {


        yield return new WaitForSeconds(time2play_AmbientAudio);
        audios[1].Play();
        audios[2].Play();
    }

    private IEnumerator PlayTeacherAudio()
    {
        yield return new WaitForSeconds(time2play_TeacherDialog);
    }
}
