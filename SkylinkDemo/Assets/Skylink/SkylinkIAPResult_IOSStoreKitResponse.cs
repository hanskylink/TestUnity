using UnityEngine;
using System.Collections;

public class SkylinkIAPResult_IOSStoreKitResponse : ISkylinkIAPResult{
	private IOSStoreKitResponse _owner;
	public object Value{ get{ return _owner;} set{ _owner = (IOSStoreKitResponse)value; } }
	public bool IsSuccess{ get{ return _owner.state == InAppPurchaseState.Purchased || _owner.state == InAppPurchaseState.Restored; } }
	public string SKU{ get { return _owner.productIdentifier; } }
	public string Message{ get{ return _owner.error.description; } }
}
