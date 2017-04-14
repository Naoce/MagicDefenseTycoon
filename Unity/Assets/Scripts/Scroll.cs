using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll : MonoBehaviour
{
    public GameObject gm;
    public bool isHUD;

    public void AnimationIsFinished()
    {
        if (isHUD == true)
        {
            GetComponent<Animator>().SetBool("StartAnim", false);
            gm.GetComponent<Buttons>().EndAnimationPanelHUDMenu();
        }
        else
        {
            GetComponent<Animator>().SetBool("StartAnim", false);
            gm.GetComponent<Buttons>().EndAnimationPanelOptions();
        }
    }
}
