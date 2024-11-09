using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class Scene5_Manager : MonoBehaviour
{
    private AnimalsOrbit animalOrbit;
    private int usedAnials;

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

    //Solo para la preentrega, Borra después de eso
    public GameObject interactionBtn;
    public GameObject btnContinue;


    private void Awake()
    {
        playerCurrentPos.position = playerStartPos.position;
    }

    // Start is called before the first frame update
    void Start()
    {
        //animalOrbit = GetComponent<AnimalsOrbit>();

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

        yield return new WaitForSeconds(textTime*5);

    }

    public void ActivateInteractionBtnAnimal()
    {
        StartCoroutine(ActivateBtnCorutine());
    }

    private IEnumerator ActivateBtnCorutine()
    {
        yield return new WaitForSeconds(7);


        interactionBtn.SetActive(true);
    }

}
