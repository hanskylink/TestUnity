using UnityEngine;
using System.Collections;

public interface ISkylinkItem {
	string SKU { get; }
	string Title{ get; }
	string Price{ get; }
	string Description{ get; }
	string CurrencyCode{ get; }
}