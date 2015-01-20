using UnityEngine;
using System.Collections;

public class SkylinkItem_IOSProductTemplate : ISkylinkItem{
	private IOSProductTemplate _value;
	public IOSProductTemplate Value { get{ return _value; } set{ _value = value; } }
	public string SKU { get{ return Value.id; } }
	public string Title{ get{ return Value.title; } }
	public string Price{ get{ return Value.price; } }
	public string Description{ get{ return Value.description; } }
	public string CurrencyCode{ get{ return Value.currencyCode; } }
}

