using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class FeedbackPlayer : ExpansionMonoBehaviour, IFeedbackPlayer
{
    public bool IsSuccessed { get; set; } = true;

    private List<Feedback> _feedbackToPlay = null;
    public List<Feedback> FeedbackToPlay => _feedbackToPlay;

    public event Action OnStartFeedbackEvent;
    public event Action OnFinishFeedbackEvent;
    private void Awake()
    {
        SetUpEffect();
    }

    public void SetUpEffect()
    {
        _feedbackToPlay = new List<Feedback>();
        GetComponents(_feedbackToPlay);
    }

    /// <summary>
    /// 가지고 있는 피드백을 전부 실행 및 결과를 받아옴
    /// </summary>
    public void PlayFeedback()
    {
        OnStartFeedbackEvent?.Invoke();

        DoPlayFeedback();
    }


    /// <summary>
    /// 가지고 있는 피드백을 전부 종료
    /// </summary>
    public void FinishFeedback()
    {
        OnFinishFeedbackEvent?.Invoke();

        DoFinishFeedback();
    }

    public void DoPlayFeedback()
    {
        foreach (Feedback f in _feedbackToPlay)
        {
            //하나라도 False면 false를 리턴
            IsSuccessed = f.StartFeedback();
        }

    }

    public void DoFinishFeedback()
    {
        foreach (Feedback f in _feedbackToPlay)
        {
            f.FinishFeedback();
        }
    }
}
