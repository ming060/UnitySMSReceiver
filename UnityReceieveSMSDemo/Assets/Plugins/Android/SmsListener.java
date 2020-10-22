package com.ming.hello;

import android.content.BroadcastReceiver;
import android.content.Context;
import android.content.Intent;
import android.telephony.SmsMessage;

import org.json.JSONException;
import org.json.JSONObject;

import com.unity3d.player.UnityPlayer;

public class SmsListener extends BroadcastReceiver {
    private final String UnityCallbackObject = "UnitySMSReceiver";
    private final String UnityCallbackMethod = "OnSMSReceive";

    @Override
    public void onReceive(Context context, Intent intent) {
        StringBuilder builder = new StringBuilder();

        Object[] objects = (Object[]) intent.getExtras().get("pdus");
        SmsMessage message = SmsMessage.createFromPdu((byte[]) objects[0]);

        String sender = message.getDisplayOriginatingAddress();
        for (int i = 0; i < objects.length; i++) {
            message = SmsMessage.createFromPdu((byte[]) objects[i]);
            builder.append(message.getDisplayMessageBody());
        }

        JSONObject object = new JSONObject();
        try {
            object.put("S", sender);
            object.put("M", builder.toString());
        } catch (JSONException e) {
            e.printStackTrace();
        }

        UnityPlayer.UnitySendMessage(UnityCallbackObject, UnityCallbackMethod, object.toString());
    }
}