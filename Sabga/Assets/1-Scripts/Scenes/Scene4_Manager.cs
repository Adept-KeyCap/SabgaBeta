using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Scene4_Manager : MonoBehaviour
{
    [Header("Player Positions")]
    [SerializeField] private Transform playerCurrentPos;
    [SerializeField] private Transform playerStartPos;
    [SerializeField] private Transform playerTargetPos;
    public float descendTime;


    [Header("Text")]
    [SerializeField] private GameObject transitionObj;
    private Material transitonMat;
    public float textTime;


    public UnityEvent OnDepthTransitionEnd;

    private void Awake()
    {
        playerCurrentPos.position = playerStartPos.position;
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(TextTransition());
        transitonMat = transitionObj.GetComponent<SpriteRenderer>().sharedMaterial;
        transitonMat.SetFloat("_Edge_Dissolve", 0);

        playerCurrentPos.DOMove(playerTargetPos.position, descendTime).SetEase(Ease.InOutSine).OnComplete(() =>
        {
            DOTween.Kill(playerCurrentPos);
        });

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator TextTransition()
    {
        yield return new WaitForSeconds(textTime);
        transitonMat.DOFloat(2, "_Edge_Dissolve", textTime*2).SetEase(Ease.InOutSine).OnComplete(() =>
        {
            transitonMat.DOFloat(0, "_Edge_Dissolve", textTime * 2).SetEase(Ease.InOutSine).OnComplete(() =>
            {
                OnDepthTransitionEnd.Invoke();
                DOTween.KillAll(transitonMat);
            });           
                
        });
    }
}
