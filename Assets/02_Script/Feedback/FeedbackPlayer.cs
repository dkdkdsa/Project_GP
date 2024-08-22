using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class FeedbackPlayer : ExpansionMonoBehaviour, ILocalInject
{
    public bool IsNetwork = false;
    public bool IsSuccessed { get; set; } = true;

    private List<Feedback> _feedbackToPlay = null;
    public List<Feedback> FeedbackToPlay => _feedbackToPlay;

    private NetworkFeedbackController _feedbackController = null;

    public void LocalInject(ComponentList list)
    {
        _feedbackController = list.Find<NetworkFeedbackController>();
    }

    private void Awake()
    {
        SetUpEffect();
    }

    public void SetUpEffect()
    {
        _feedbackToPlay = new List<Feedback>();
        GetComponents(_feedbackToPlay);
    }

    public void PlayFeedback()
    {
        FinishFeedback();
        foreach (Feedback f in _feedbackToPlay)
        {
            //하나라도 False면 false를 리턴
            IsSuccessed = f.StartFeedback();

            if (IsNetwork)
            {
                _feedbackController.SetFeedback(f);
            }
        }
    }

    public void FinishFeedback()
    {
        foreach (Feedback f in _feedbackToPlay)
        {
            f.FinishFeedback();
        }
    }

}
