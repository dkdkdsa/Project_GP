using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFeedbackHandler : ExpansionMonoBehaviour, ILocalInject
{

    [SerializeField] private FeedbackPlayer _knockbackFeedback;

    private IKnockBackable _knockBack;

    public void LocalInject(ComponentList list)
    {

        _knockBack = list.Find<IKnockBackable>();

    }

    private void Awake()
    {

        _knockBack.OnKnockBackEvent += HandleKnockBack;

    }

    private void HandleKnockBack(float arg1, Vector2 vector)
    {

        _knockbackFeedback.PlayFeedback();

    }

}