using UnityEngine;
using System.Collections;

public interface ISkylinkIAPResult {
	bool IsSuccess{ get; }
	object Value{ get; }
	string SKU{ get; }
	string Message{ get; }
}
