using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class SpiralClockSkin : TimepieceSkin {

	public List<DigitHolder> digitHolders = new List<DigitHolder>();
	public SpiralDigit digitPrototype;
	public float lastDigitHolderSize = 0.3f;
	public float lastDigitAlphaColor = 0.1f;

	private System.DateTime setTime;
	
	void Start () {
		PopulateDigits();
		SetupDigits();
	}

	public override void SetTime (System.DateTime time)
	{
		var diffInSeconds = (time - setTime).TotalSeconds;

		if (diffInSeconds >= 1) {

			setTime = time;

			// If a difference between a new and already set time is around 1 second we will animate a seconds' shift on a spiral.
			if (diffInSeconds < 1.1f) {
				digitHolders[digitHolders.Count - 1].digit.GetComponent<Text>().text = GetCorrectSeconds(time.Second).ToString("D2");
				DigitHolder.StartShiftReaction(digitHolders[0]);
			} else {
				SetupDigits();
			}
		}
	}

	private void PopulateDigits() {

		var scale = new Vector3(1,1,1);
		var shrinkRate = Mathf.Pow(1f/lastDigitHolderSize, 1f/digitHolders.Count) - 1;
		var alpha = 1f;
		var alphaChangeRate = Mathf.Pow(1f/lastDigitAlphaColor, 1f/digitHolders.Count) - 1;

		foreach(DigitHolder holder in digitHolders) {

			var holderIndex = digitHolders.IndexOf(holder);
			holder.nextHolder = holderIndex + 1 < digitHolders.Count ? digitHolders[holderIndex + 1] : digitHolders[0];

			holder.GetComponent<Text>().text = string.Empty;
			holder.GetComponent<RectTransform>().localScale = scale;

			var digit = Object.Instantiate(digitPrototype) as SpiralDigit;
			holder.digit = digit;

			scale -= scale * shrinkRate;

			holder.alphaColor = alpha;
			alpha -= alpha * alphaChangeRate;
		}

		digitPrototype.gameObject.SetActive(false);

	}

	private void SetupDigits() {

		var seconds = setTime.Second;
		
		foreach(DigitHolder holder in digitHolders) {

			holder.SetColor();

			var digit = holder.digit;
			digit.transform.SetParent(transform);
			digit.transform.position = digitPrototype.transform.position;
			digit.transform.rotation = holder.transform.rotation;
			digit.GetComponent<RectTransform>().localScale = holder.GetComponent<RectTransform>().localScale;
			digit.GetComponent<RectTransform>().anchoredPosition = holder.GetComponent<RectTransform>().anchoredPosition;
			// "D2" stands for adding a padding 0 to a number when it's needed e.g. 01, 09, 51.
			digit.GetComponent<Text>().text = GetCorrectSeconds(seconds).ToString("D2");

			seconds -= 1; 
		}

	}

	private int GetCorrectSeconds(int seconds) {

		// When seconds are negative it means they are counting a prev minute like that: 3,2,1,0,59,58,57.
		if (seconds < 0) {
			return 60 + seconds;
		} else {
			return seconds;
		}

	}

}
