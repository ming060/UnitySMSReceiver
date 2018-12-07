using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hello : MonoBehaviour {
	public InputField OTPInputField;
	void Start () {
		UnitySMSReceiver.OnSMSReceiveHandler += OnSMSReceive;
	}
	private void OnSMSReceive (object o, UnitySMSReceiver.SMSReceiveEventArgs arg) {
		Debug.Log (arg.Message);
		OTPInputField.text = arg.Message;
	}
}
