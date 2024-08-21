using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class CreateRoomUI : UIComponent
{
    [SerializeField] private TMP_InputField _lobbyNameField = null;

    public UnityEvent OnSuccessEvent = null;
    public UnityEvent OnFailureEvent = null;

    [SerializeField] private int _maxCharacterCount = 20;

    private static readonly Regex _invalidCharRegex = new Regex(@"[^a-zA-Z0-9가-힣]", RegexOptions.Compiled);

    private bool _canCreatedRoom = false;

    private void OnEnable()
    {
        _lobbyNameField.characterLimit = _maxCharacterCount;

        _lobbyNameField.onEndEdit.AddListener(OnCreateRoom);
    }

    private void OnDisable()
    {
        _lobbyNameField.onEndEdit.RemoveListener(OnCreateRoom);
    }


    /// <summary>
    /// Event용
    /// </summary>
    public void OnCreateRoom()
    {
        OnCreateRoom(_lobbyNameField.text);
        if (!_canCreatedRoom) return;

        CreateRoom();
    }

    private async void CreateRoom()
    {
        string name = DataManager.Instance.PlayerName;

        await AppController.Instance.StartHostAsync(name, _lobbyNameField.text);
    }

    private void OnCreateRoom(string inputText)
    {
        inputText = inputText.Trim();

        if (IsValidName(inputText))
        {
            DataManager.Instance.RoomName = inputText;
            _canCreatedRoom = true;

            OnSuccessEvent?.Invoke();
        }
        else
        {
            _canCreatedRoom = false;
            OnFailureEvent?.Invoke();
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
