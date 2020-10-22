using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitySMSReceiver : MonoBehaviour {
	public class SMSReceiveEventArgs : EventArgs {
		public string Sender { get; private set; }
		public string Message { get; private set; }
		public SMSReceiveEventArgs (string sender, string message) {
			Sender = sender;
			Message = message;
		}
	}
	private const string gameObjectName = "UnitySMSReceiver";
	public static event EventHandler<SMSReceiveEventArgs> OnSMSReceiveHandler;
	public void Awake () {
		this.gameObject.name = gameObjectName;
	}
	public void OnSMSReceive (string message) {
		var data = JsonUtility.FromJson<SMSContainer>(message);
		OnSMSReceiveHandler (null, new SMSReceiveEventArgs (data.S, data.M));
	}
	public class SMSContainer
	{
		public string S;
		public string M;
	}
}
