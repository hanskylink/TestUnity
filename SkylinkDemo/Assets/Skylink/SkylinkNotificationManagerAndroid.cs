

using UnityEngine;
using UnionAssets.FLE;
using System.Collections;

public class SkylinkNotificationManagerAndroid : AbstractSkylinkNotificationManager {
	public override void Register(){
		GoogleCloudMessageService.instance.addEventListener(GoogleCloudMessageService.CLOUD_MESSAGE_SERVICE_REGISTRATION_FAILED, OnRegFailed);
		GoogleCloudMessageService.instance.addEventListener(GoogleCloudMessageService.CLOUD_MESSAGE_SERVICE_REGISTRATION_RECIVED, OnRegstred);
		GoogleCloudMessageService.instance.addEventListener(GoogleCloudMessageService.CLOUD_MESSAGE_LOADED, OnMessageLoaded);
		GoogleCloudMessageService.instance.RgisterDevice();
	}
	
	private void OnRegFailed() {
		if( Delegate != null ){
			Delegate.OnToken( false, "GCM Registration failed :(" );
		}
	}

	private void OnRegstred() {
		if( Delegate != null ){
			Delegate.OnToken( true, GoogleCloudMessageService.instance.registrationId );
		}
		GoogleCloudMessageService.instance.removeEventListener(GoogleCloudMessageService.CLOUD_MESSAGE_SERVICE_REGISTRATION_FAILED, OnRegFailed);
		GoogleCloudMessageService.instance.removeEventListener(GoogleCloudMessageService.CLOUD_MESSAGE_SERVICE_REGISTRATION_RECIVED, OnRegstred);
	}
	
	private void OnMessageLoaded() {
		//AN_PoupsProxy.showMessage ("Message Loaded", "Last GCM Message: " + GoogleCloudMessageService.instance.lastMessage);
	}

}