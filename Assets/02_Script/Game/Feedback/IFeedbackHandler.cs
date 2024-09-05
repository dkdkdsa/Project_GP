using System;

public interface IFeedbackHandler
{
    public abstract bool StartFeedback(); //피드백 생성
    public abstract bool FinishFeedback(); //피드백 종료
    public abstract bool DoStartFeedback();
    public abstract bool DoFinishFeedback();
}