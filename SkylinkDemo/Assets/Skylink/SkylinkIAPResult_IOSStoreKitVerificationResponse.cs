using UnityEngine;
using System.Collections;

public class SkylinkIAPResult_IOSStoreKitVerificationResponse : ISkylinkIAPResult{
	private IOSStoreKitVerificationResponse _owner;
	public object Value{ get{ return _owner;} set{ _owner = (IOSStoreKitVerificationResponse)value; } }
	public bool IsSuccess{ get{ return true; } }
	public string SKU{ get { return _owner.productIdentifier; } }
	public string Message{ get{ return ""; } }
}

