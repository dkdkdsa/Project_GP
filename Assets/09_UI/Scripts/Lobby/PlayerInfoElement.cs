using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInfoElement : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _playerNameText;
    [SerializeField] private Image _isHostImage;
    [SerializeField] private Image _playerCharactorImage;

    public void Init(string name, Color color, bool isHost)
    {
        _isHostImage.gameObject.SetActive(isHost);

        _playerNameText.text = name;

        _playerCharactorImage.material = Instantiate(_playerCharactorImage.material);
        _playerCharactorImage.material.SetColor("_ColorReplaceToColor", color);
    }
}
