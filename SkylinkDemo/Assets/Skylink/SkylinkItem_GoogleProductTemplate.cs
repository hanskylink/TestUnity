using UnityEngine;
using System.Collections;

public class SkylinkItem_GoogleProductTemplate : ISkylinkItem{
	private GoogleProductTemplate _value;
	public GoogleProductTemplate Value { get{ return _value; } set{ _value = value; } }
	public string SKU { get{ return Value.SKU; } }
	public string Title{ get{ return Value.title; } }
	public string Price{ get{ return Value.price; } }
	public string Description{ get{ return Value.description; } }
	public string CurrencyCode{ get{ return Value.priceCurrencyCode; } }
}
