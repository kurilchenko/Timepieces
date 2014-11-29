using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SimpleDigitalClockSkin : TimepieceSkin {

	public string timeFormat = "HH:mm:ss";
	public Text text;

	public override void SetTime(System.DateTime time)
	{
		text.text = time.ToString(timeFormat);
	}

}
