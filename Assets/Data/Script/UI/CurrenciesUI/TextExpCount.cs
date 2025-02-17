using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextExpCount : TextAbstract
{
    protected virtual void LateUpdate() 
    {
        this.LoadExpCount();
    }

    protected virtual void LoadExpCount() 
    {
        int currentExp;
        int nextExp;

        PlayerLevel level = PlayerManagerCtrl.Instance.CurrentPlayer.PlayerLevel;
        currentExp = level.GetCurrentExp();
        nextExp = level.GetNextLevelExp();

        this.text.text = $"{(float)currentExp / nextExp * 100:F2}%";

    }
}
