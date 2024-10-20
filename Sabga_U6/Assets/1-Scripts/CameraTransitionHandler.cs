using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class CameraTransitionHandler : MonoBehaviour
{
    [SerializeField] private Image transitionPanel;
    [SerializeField] private Color solidColor;
    [SerializeField] private float transitionDuration;

    public UnityEvent transparent2Color_End;
    public UnityEvent color2Transparent_End;

    // Start is called before the first frame update
    void Start()
    {
        Color2Transparent();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Transparent2Color()
    {
        transitionPanel.DOColor(solidColor, transitionDuration).SetEase(Ease.InQuad).OnComplete(() =>
        {
            transparent2Color_End.Invoke();
            DOTween.Kill(transitionPanel);
        });
    }

    public void Color2Transparent()
    {
        transitionPanel.DOColor(Color.clear, transitionDuration).SetEase(Ease.InQuad).OnComplete(() =>
        {
            color2Transparent_End.Invoke();
            DOTween.Kill(transitionPanel);
        });
    }
}
