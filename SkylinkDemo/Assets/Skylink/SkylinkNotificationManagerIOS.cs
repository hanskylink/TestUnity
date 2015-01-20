
using UnityEngine;
using UnionAssets.FLE;
using System.Collections;
using System;

public class SkylinkNotificationManagerIOS : AbstractSkylinkNotificationManager {
	public override void Register(){
#if UNITY_IPHONE
		IOSNotificationController.instance.RegisterForRemoteNotifications (RemoteNotificationType.Alert |  RemoteNotificationType.Badge |  RemoteNotificationType.Sound);
		IOSNotificationController.instance.addEventListener (IOSNotificationController.DEVICE_TOKEN_RECEIVED, OnTokenReived);
#endif
	}

	private void OnTokenReived(CEvent e) {
		IOSNotificationDeviceToken token = e.data as IOSNotificationDeviceToken;
		if( Delegate != null ){
			Delegate.OnToken( true, token.tokenString );
		}
		IOSNotificationController.instance.removeEventListener (IOSNotificationController.DEVICE_TOKEN_RECEIVED, OnTokenReived);
	}
}