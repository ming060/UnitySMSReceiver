using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitySMSReceiver : MonoBehaviour {
	public class SMSReceiveEventArgs : EventArgs {
		//public String Sender { get; private set; }
		public String Message { get; private set; }
		public SMSReceiveEventArgs (string message) {
			Message = message;
		}
		//public SMSReceiveEventArgs(string sender, string message)
		//{
		//	Sender = sender;
		//	Message = message;
		//}
	}
	private const string gameObjectName = "UnitySMSReceiver";
	public static event EventHandler<SMSReceiveEventArgs> OnSMSReceiveHandler;
	public void Awake () {
		this.gameObject.name = gameObjectName;
	}
	public void OnSMSReceive (string message) {
		OnSMSReceiveHandler (null, new SMSReceiveEventArgs (message));
	}
	//public void OnSMSReceive(string sender, string message)
	//{
	//	OnSMSReceiveHandler(null, new SMSReceiveEventArgs(sender, message));
	//}
}
