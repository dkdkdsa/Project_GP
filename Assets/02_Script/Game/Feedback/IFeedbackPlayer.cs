using System;

public interface IFeedbackPlayer
{
    public event Action OnStartFeedbackEvent;
    public event Action OnFinishFeedbackEvent;

    public void PlayFeedback();
    public void DoPlayFeedback();
    public void FinishFeedback();
    public void DoFinishFeedback();
}

