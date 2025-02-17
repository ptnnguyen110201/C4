using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextPlayerLevel : TextAbstract
{
	protected virtual void LateUpdate()
	{
		this.LoadGoldCount();
	}

	protected virtual void LoadGoldCount()
	{
		int level = PlayerManagerCtrl.Instance.CurrentPlayer.PlayerLevel.CurrentLevel;
		this.text.text = level.ToString();
	}
}
