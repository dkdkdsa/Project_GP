using TMPro;
using UnityEngine;

public class TimeUI : ExpansionMonoBehaviour, ITimeUI<int>
{

    [SerializeField] private TMP_Text _timeText;

    public void SetText(string text)
    {

        _timeText.text = text;

    }

    public void SetTimeText(int time)
    {

        _timeText.text = time.ToString();

    }

}