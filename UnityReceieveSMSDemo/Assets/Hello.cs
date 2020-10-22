using UnityEngine;
using UnityEngine.UI;

public class Hello : MonoBehaviour {
	public Text Sender;
	public Text Message;
	void Start () {
		UnitySMSReceiver.OnSMSReceiveHandler += OnSMSReceive;
	}
	private void OnSMSReceive (object o, UnitySMSReceiver.SMSReceiveEventArgs arg) {
		//Debug.Log (arg.Sender);
		Debug.Log (arg.Message);
		//Sender.text = "Sender：" + arg.Sender;
		Message.text = "Message：" + arg.Message;
	}
}
