using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class TimepieceController : MonoBehaviour {
	
	public List<TimepieceSkin> skins = new List<TimepieceSkin>();

	void Update () {
		foreach (TimepieceSkin skin in skins)
		{
			skin.SetTime(DateTime.Now);
		}
	}

}
