using DG.Tweening;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;



/// <summary>
/// 이름 바꿀 예정
/// </summary>
public class UIMoveController : UIComponent
{
    [System.Serializable]
    public struct MoveUIData
    {
        public RectTransform UIRectTransform;
        public float MoveDuration;
        public Vector2 StartPos;
        public Vector2 EndPos;
        public float WaitForSecond;

        [Header("이벤트들"), Space(10)]
        public UnityEvent OnSettingEvent;
        public UnityEvent OnRevertSettingEvent;
        public UnityEvent OnRevertEndAnimationEvent;
        public UnityEvent OnEndAnimationEvent;
    }

    public bool IsStartAnimation = true;
    public bool IsStartSetting = true;
    public bool IsStartRevert = false;

    public List<MoveUIData> MoveUIDataList = new();

    private Sequence _sequence = null;

    private void Awake()
    {
        _sequence = DOTween.Sequence();
    }

    private void OnEnable()
    {
        if (IsStartAnimation) StartUIAnimation(IsStartRevert);
        if (IsStartSetting) Setting(IsStartRevert);
    }

    public void OnStartUIAnimation(bool revert)
    {
        Setting(revert);
        StartUIAnimation(revert);
    }

    private void StartUIAnimation(bool revert)
    {
        foreach (var data in MoveUIDataList)
        {
            Vector2 startPos = revert ? data.EndPos : data.StartPos;
            Vector2 endPos = revert ? data.StartPos : data.EndPos;

            _sequence.Append(data.UIRectTransform.DOLocalMove(endPos, data.MoveDuration)
                .OnComplete(() =>
                {
                    // 애니메이션 종료 후 이벤트 호출 
                    if (revert) data.OnRevertEndAnimationEvent?.Invoke();
                    else data.OnEndAnimationEvent?.Invoke();
                }));

            _sequence.AppendInterval(data.WaitForSecond);
        }
    }

    private void Setting(bool revert)
    {
        for (int i = 0; i < MoveUIDataList.Count; i++)
        {
            Vector2 startPos = revert ? MoveUIDataList[i].EndPos : MoveUIDataList[i].StartPos;

            MoveUIDataList[i].UIRectTransform.anchoredPosition = startPos;

            if (revert) MoveUIDataList[i].OnRevertSettingEvent?.Invoke();
            else MoveUIDataList[i].OnSettingEvent?.Invoke();

        } //end for
    }
}

