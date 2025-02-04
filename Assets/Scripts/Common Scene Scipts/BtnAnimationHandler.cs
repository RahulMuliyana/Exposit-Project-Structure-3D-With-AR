using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class BtnAnimationHandler : MonoBehaviour
{

    private Button AnimatedBtn;
    private Animator BtnAnimator;
    bool BtnPressed = false;
    public string OpenBtnAnimation;
    public string CloseBtnAnimation;
    public UnityEvent ButtonPressed;
    public UnityEvent ButtonPressedAgain;
    public UnityEvent SeceretEvent;


    private void Start()
    {
        AnimatedBtn = GetComponent<Button>();
        BtnAnimator = GetComponent<Animator>();
        AnimatedBtn.onClick.AddListener(() => CheckCondition());

    }
    private void CheckCondition()
    {
        if (!BtnPressed)
        {
            OnPressedBtn();
        }
        else
        {
            OnPressedAgainBtn();
        }
    }
    private void OnPressedBtn()
    {
        ButtonPressed.Invoke();
        BtnAnimator.Play(OpenBtnAnimation);
        BtnPressed = true;
    }
    private void OnPressedAgainBtn()
    {
        ButtonPressedAgain.Invoke();
        BtnAnimator.Play(CloseBtnAnimation);
        BtnPressed = false;
    
    }
    public void SecretEvents()
    {
        SeceretEvent.Invoke();
    }
}
