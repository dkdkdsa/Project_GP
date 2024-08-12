using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

public class SettingButton : UIComponent, IMouseEventHandler
{
    public float ScaleDuration = 1f;
    public float RotateSpeed = 1f;

    private Vector3 _curScaleSize = Vector3.zero;
    private Vector3 _maxScaleSize = new Vector3(1.3f, 1.3f, 1.3f);

    private Tween _rotateTween;

    private void Awake()
    {
        _curScaleSize = transform.localScale;

        _rotateTween = transform.DORotate(new Vector3(0, 0, 360), RotateSpeed, RotateMode.FastBeyond360)
                               .SetEase(Ease.Linear)
                               .SetLoops(-1)
                               .Pause();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        transform.DOScale(_maxScaleSize, ScaleDuration);

        if (!_rotateTween.IsPlaying())
        {
            _rotateTween.Restart();
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        transform.DOScale(_curScaleSize, ScaleDuration);

        if (_rotateTween.IsPlaying())
        {
            _rotateTween.Pause();
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        transform.DOScale(_curScaleSize, ScaleDuration);

        if (_rotateTween.IsPlaying())
        {
            _rotateTween.Pause();
        }
    }
}
