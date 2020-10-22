using UnityEngine;
using UnityEngine.UI;

public class Hello : MonoBehaviour {
	public Text Sender;
	public Text Message;
	void Start () {
		UnitySMSReceiver.OnSMSReceiveHandler += OnSMSReceive;
	}
	private void OnSMSReceive (object o, UnitySMSReceiver.SMSReceiveEventArgs arg) {
        Sender.text = "Sender：" + arg.Sender;
        Message.text = "Message：" + arg.Message;
	}
}
