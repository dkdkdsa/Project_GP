using DG.Tweening;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;



/// <summary>
/// 이름 바꿀 예성
/// </summary>
public class UIMove : UIComponent
{
    [System.Serializable]
    public struct MoveUIData
    {
        public RectTransform UIRectTransform;
        public float MoveDuration;
        public Vector2 StartPos;
        public Vector2 EndPos;
        public float WaitForSecond;
    }

    public List<MoveUIData> MoveUIDataList = new();

    private  Sequence _sequence = null;

    private void Awake()
    {
        _sequence = DOTween.Sequence();
    }

    private void OnEnable()
    {
        StartTitleAnimation();
    }

    public void StartTitleAnimation()
    {
        Setting();


        foreach (var data in MoveUIDataList)
        {
            _sequence.Append(data.UIRectTransform.DOLocalMove(data.EndPos, data.MoveDuration));

            _sequence.AppendInterval(data.WaitForSecond);
        }

    }

    private void Setting()
    {
        for (int i = 0; i < MoveUIDataList.Count; i++)
        {
            MoveUIDataList[i].UIRectTransform.anchoredPosition = MoveUIDataList[i].StartPos;
        }
    }
}

