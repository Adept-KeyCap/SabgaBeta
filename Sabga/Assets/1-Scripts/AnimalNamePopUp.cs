using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalNamePopUp : MonoBehaviour
{
    public GameObject popUpPanel;
    public float transitionDuration;

    public void DeactivatePanel()
    {
        StartCoroutine(DeactivateInSeconds(transitionDuration));
    }

    private IEnumerator DeactivateInSeconds(float sec)
    {
       
        yield return new WaitForSeconds(sec);
        popUpPanel.SetActive(false);
    }
}
