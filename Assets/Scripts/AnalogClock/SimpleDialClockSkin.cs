using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SimpleDialClockSkin : TimepieceSkin {
	
	public List<ClockHand> hands = new List<ClockHand>();

	public override void SetTime(System.DateTime time) {
		foreach (ClockHand hand in hands) {
			hand.SetTime(time);
		}
	}
}
