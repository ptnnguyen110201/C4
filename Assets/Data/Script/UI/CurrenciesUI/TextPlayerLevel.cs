using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextPlayerLevel : TextAbstract
{
	protected virtual void FixedUpdate()
	{
		this.LoadGoldCount();
	}

	protected virtual void LoadGoldCount()
	{
		int level = PlayerCtrl.Instance.PlayerLevel.CurrentLevel;
		this.text.text = level.ToString();
	}
}
