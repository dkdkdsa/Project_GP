using DG.Tweening;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UIAlphaController : UIComponent
{
    [System.Serializable]
    public struct AlphaUIData
    {
        public CanvasGroup Group;
        public float Duration;
        [Range(0f, 1f)] public float StartAlpha;
        [Range(0f, 1f)] public float EndAlpha;
        public float WaitForSecond;

        [Header("이벤트들"), Space(10)]
        public UnityEvent OnSettingEvent;
        public UnityEvent OnRevertSettingEvent;
        public UnityEvent OnEndAnimationEvent;
        public UnityEvent OnRevertEndAnimationEvent;
    }

    public bool IsStartAnimation = true;
    public bool IsStartSetting = true;
    public bool IsStartRevert = false;

    public List<AlphaUIData> AlphaUIDataList = new();

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

    public void OnStartUIAnimation(bool revert = false)
    {
        Setting(revert);
        StartUIAnimation(revert);
    }

    private void StartUIAnimation(bool revert = false)
    {
        foreach (var data in AlphaUIDataList)
        {
            float startAlpha = revert ? data.EndAlpha : data.StartAlpha;
            float endAlpha = revert ? data.StartAlpha : data.EndAlpha;

            _sequence.Append(data.Group.DOFade(endAlpha, data.Duration)
                .OnComplete(() =>
                {
                    // 애니메이션 종료 후 이벤트 호출
                    if (revert) data.OnRevertEndAnimationEvent?.Invoke();
                    else data.OnEndAnimationEvent?.Invoke();
                }));

            _sequence.AppendInterval(data.WaitForSecond);
        }
    }

    private void Setting(bool revert = false)
    {
        for (int i = 0; i < AlphaUIDataList.Count; i++)
        {
            float startAlpha = revert ? AlphaUIDataList[i].EndAlpha : AlphaUIDataList[i].StartAlpha;
            AlphaUIDataList[i].Group.alpha = startAlpha;

            if (revert) AlphaUIDataList[i].OnRevertSettingEvent?.Invoke();
            else AlphaUIDataList[i].OnSettingEvent?.Invoke();

        } //end for
    }
}
