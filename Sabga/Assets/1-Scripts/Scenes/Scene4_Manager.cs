using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene4_Manager : MonoBehaviour
{
    [Header("Player Positions")]
    [SerializeField] private Transform playerCurrentPos;
    [SerializeField] private Transform playerStartPos;
    public float descendTime;


    [Header("Text")]
    [SerializeField] private GameObject transitionObj;
    private Material transitonMat;
    public float textTime;
    

    private void Awake()
    {
        playerCurrentPos.position = playerStartPos.position;
    }

    // Start is called before the first frame update
    void Start()
    {
        transitonMat = transitionObj.GetComponent<SpriteRenderer>().sharedMaterial;
        playerCurrentPos.DOMove(Vector3.zero, descendTime).SetEase(Ease.InOutSine).OnComplete(() =>
        {
            StartCoroutine(TextTransition());
            DOTween.KillAll(playerCurrentPos, descendTime);
        });

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator TextTransition()
    {
        yield return new WaitForSeconds(textTime);
        transitonMat.DOFloat(2, "_Edge_Dissolve", textTime*2);
    }
}
