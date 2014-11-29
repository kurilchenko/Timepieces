using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DigitHolder : MonoBehaviour {

	public static float animationTime = 0.6f;

	public SpiralDigit digit;
	public DigitHolder nextHolder;
	public float alphaColor = 1;

	public static void StartShiftReaction(DigitHolder targetHolder) {
		targetHolder.ShiftDigitToNextHolder();
	}

	public void SetColor() {
		var oldColor = digit.GetComponent<Text>().color;
		var newColor = new Color(oldColor.r, oldColor.g, oldColor.b, alphaColor);
		digit.GetComponent<Text>().color = newColor;
	}

	private void ShiftDigitToNextHolder() {

		var formerDigit = digit;
		digit = null;

		nextHolder.PushDigit(formerDigit);

	}

	private void PushDigit(SpiralDigit newDigit) {

		bool didStartChainReaction = digit == null ? true : false;

		var formerDigit = digit;
		digit = newDigit;

		if (!didStartChainReaction) {
			AnimateShift();
			nextHolder.PushDigit(formerDigit);
		}
		else {
			SetAsFirst();
		}

	}

	private void AnimateShift() {

		LeanTween.move(digit.GetComponent<RectTransform>(), gameObject.GetComponent<RectTransform>().anchoredPosition, animationTime);
		LeanTween.scale(digit.GetComponent<RectTransform>(), gameObject.GetComponent<RectTransform>().localScale, animationTime);
		LeanTween.rotate(digit.gameObject, transform.eulerAngles, animationTime);

		SetColor();
	}

	private void SetAsFirst() {

		digit.GetComponent<RectTransform>().anchoredPosition = gameObject.GetComponent<RectTransform>().anchoredPosition;
		digit.GetComponent<RectTransform>().localScale = gameObject.GetComponent<RectTransform>().localScale;
		digit.transform.rotation = transform.rotation;

		SetColor();
	}

}
