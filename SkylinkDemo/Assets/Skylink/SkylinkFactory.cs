using UnityEngine;
using System.Collections;
using System;

public class SkylinkFactory : MonoBehaviour {
	public static ISkylinkIAPManager createIAPManager(){
#if UNITY_IOS
		return new SkylinkIAPManagerIOS();
#else
		return new SkylinkIAPManagerAndroid();
#endif
	}

	public static ISkylinkNotificationManager createNotificationManager(){
#if UNITY_IOS
		return new SkylinkNotificationManagerIOS();
#else
		return new SkylinkNotificationManagerAndroid();
#endif
	}

	public static bool IsRestoreItem(ISkylinkIAPResult result){
		if( result is SkylinkIAPResult_IOSStoreKitResponse ){
			IOSStoreKitResponse res = (IOSStoreKitResponse)((SkylinkIAPResult_IOSStoreKitResponse)result).Value;
			return res.state == InAppPurchaseState.Restored;
		}
		return false;
	}

	public static string GetReceipt(ISkylinkIAPResult result){
		if( result is SkylinkIAPResult_IOSStoreKitResponse ){
			IOSStoreKitResponse res = (IOSStoreKitResponse)((SkylinkIAPResult_IOSStoreKitResponse)result).Value;
			return res.receipt;
		}
		return "";
	}
}
