using UnityEngine;

public interface IScoreUI
{

    public void SetPlayerColor(Color color);
    public void SetNameColor(Color color);
    public void SetScoreText(int score);
    public void SetPlayerName(string name);

}