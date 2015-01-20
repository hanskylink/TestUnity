using UnityEngine;
using System.Collections;

public class SkylinkIAPResult_BillingResult : ISkylinkIAPResult {
	private BillingResult _owner;
	public object Value{ get{ return _owner;} set{ _owner = (BillingResult)value; } }
	public bool IsSuccess{ get{ return _owner.isSuccess; } }
	public string SKU{ get { return _owner.purchase.SKU; } }
	public string Message{ get{ return _owner.message; } }
	
}
