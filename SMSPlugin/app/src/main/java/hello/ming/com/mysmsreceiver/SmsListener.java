package hello.ming.com.mysmsreceiver;

import android.content.BroadcastReceiver;
import android.content.Context;
import android.content.Intent;
import android.telephony.SmsMessage;

import com.unity3d.player.UnityPlayer;

public class SmsListener extends BroadcastReceiver {
    private final String UnityCallbackObject = "UnitySMSReceiver";
    private final String UnityCallbackMethod = "OnSMSReceive";

    @Override
    public void onReceive(Context context, Intent intent) {
        StringBuilder builder = new StringBuilder();

        Object[] objects = (Object[]) intent.getExtras().get("pdus");
        SmsMessage message = SmsMessage.createFromPdu((byte[]) objects[0]);
        /*
        TODO replace UnityPlayer.UnitySendMessage function with AndroidJavaProxy callback
        https://docs.unity3d.com/ScriptReference/AndroidJavaProxy.html
        */
        String sender = message.getDisplayOriginatingAddress();
        for (int i = 0; i < objects.length; i++) {
            message = SmsMessage.createFromPdu((byte[]) objects[i]);
            builder.append(message.getDisplayMessageBody());
        }
        UnityPlayer.UnitySendMessage(UnityCallbackObject, UnityCallbackMethod, builder.toString());
    }
}