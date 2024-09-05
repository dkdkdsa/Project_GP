using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUI : ExpansionMonoBehaviour, IScoreUI
{

    [SerializeField] private TMP_Text _nameText;
    [SerializeField] private TMP_Text _scoreText;
    [SerializeField] private Image _playerIcon;

    private void Awake()
    {

        _playerIcon.material = Instantiate(_playerIcon.material);

    }

    public void SetNameColor(Color color)
    {

        _nameText.color = color;

    }

    public void SetPlayerColor(Color color)
    {

        _playerIcon.material.SetColor("_ColorReplaceToColor", color);

    }

    public void SetPlayerName(string name)
    {

        _nameText.text = name;

    }

    public void SetScoreText(int score)
    {

        _scoreText.text = $"점수 : {score}";

    }

}