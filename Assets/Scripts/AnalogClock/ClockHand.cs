using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ClockHand : MonoBehaviour {

	public enum HandType {
		Seconds,
		Minutes,
		Hours
	}

	public HandType handType;
	
	private System.DateTime setTime;
	private int position = -1;
	private bool firstTick = true;

	public void SetTime(System.DateTime time) {

		bool isUpdating = false;

		switch (handType) {
		case HandType.Seconds:
			isUpdating = time.Second != setTime.Second ? true : false;
			break;
		case HandType.Minutes:
			isUpdating = time.Minute != setTime.Minute ? true : false;
			break;
		case HandType.Hours:
			isUpdating = time.Hour != setTime.Hour ? true : false;
			break;
		}

		setTime = time;

		if (isUpdating) {
			UpdatePosition();
		}

	}

	private void UpdatePosition() {

		switch (handType) {
		case HandType.Seconds:
			position = setTime.Second * 6;
			break;
		case HandType.Minutes:
			position = setTime.Minute * 6;
			break;
		case HandType.Hours:
			position = setTime.Hour * 30;
			break;
		}

		var targetRotation = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, -1 * (float) position);

		if (!firstTick) {
			LeanTween.rotate(gameObject, targetRotation, 0.1f);
		}
		else {
			transform.localEulerAngles = targetRotation;
			firstTick = false;
		}


	}

}
