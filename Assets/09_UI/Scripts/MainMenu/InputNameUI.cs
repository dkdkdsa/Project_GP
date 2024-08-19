using System.Text.RegularExpressions;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class InputNameUI : UIComponent
{
    [SerializeField] private TMP_InputField _inputNameField = null;

    public UnityEvent OnSuccessEvent = null;
    public UnityEvent OnFailureEvent = null;

    [SerializeField] private int _maxCharacterCount = 20;

    private static readonly Regex _invalidCharRegex = new Regex(@"[^a-zA-Z0-9가-힣]", RegexOptions.Compiled);

    private void OnEnable()
    {
        _inputNameField.characterLimit = _maxCharacterCount;

        _inputNameField.onEndEdit.AddListener(OnCheck);
    }

    private void OnDisable()
    {
        _inputNameField.onEndEdit.RemoveListener(OnCheck);
    }

    private void OnCheck(string inputText)
    {
        inputText = inputText.Trim();

        if (IsValidName(inputText))
        {
            DataManager.Instance.PlayerName = inputText;

            OnSuccessEvent?.Invoke();
            Debug.Log("성공");
        }
        else
        {
            OnFailureEvent?.Invoke();
            Debug.Log("실패");
        }
    }

    private bool IsValidName(string input)
    {
        if (string.IsNullOrEmpty(input))
        {
            //이름을 안정했을 때 (최소 1글자 이상)
            Debug.Log("1글자");
            return false;
        }

        if (input.Length > _maxCharacterCount)
        {
            //글자 수가 제한을 초과했을 때
            Debug.Log("글자 수 초과");
            return false;
        }

        if (_invalidCharRegex.IsMatch(input))
        {
            //조건형식에 맞지 않을 때 (초성, 특수문자 제외)
            Debug.Log("특수문자");
            return false;
        }

        foreach (char c in input)
        {
            if (c >= 0x3131 && c <= 0x314E)
            {
                //한글 초성 (Jamo) 범위 검사
                return false;
            }
        }

        return true;
    }
}
