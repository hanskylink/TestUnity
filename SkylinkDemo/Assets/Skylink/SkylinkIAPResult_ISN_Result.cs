using UnityEngine;
using System.Collections;

public class SkylinkIAPResult_ISN_Result : ISkylinkIAPResult {
	private ISN_Result _owner;
	public object Value{ get{ return _owner;} set{ _owner = (ISN_Result)value; } }
	public bool IsSuccess{ get{ return _owner.IsSucceeded; } }
	public string SKU{ get { return ""; } }
	public string Message{ get{ return _owner.error.description; } }
}
