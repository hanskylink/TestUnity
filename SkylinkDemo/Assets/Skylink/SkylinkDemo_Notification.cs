using UnityEngine;
using System.Collections;

public partial class SkylinkDemo : ISkylinkNotificationManagerDelegate {

	private ISkylinkNotificationManager _notiMgr = SkylinkFactory.createNotificationManager();
	// Use this for initialization
	void NotiStart () {
		_notiMgr.Delegate = this;
	}

	public void OnToken(bool success, string token){
		Log ("OnToken:"+success+":"+token);
	}

	void NotiOnGUI(){
		if( GUILayout.Button("Register Push") ){
			Log ("Register");
			_notiMgr.Register();
		}
	}
}
