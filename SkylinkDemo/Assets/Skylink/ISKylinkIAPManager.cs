using UnityEngine;
using System.Collections;

public interface ISkylinkIAPManager {
	ISkylinkIAPManagerDelegate Delegate { set; get; }
	bool IsIOS{ get; }
	bool IsAndroid{ get; }
	void Init();
	void AddProduct(string sku);
	void BuyItem(string sku);
	ISkylinkItem GetItem(string sku);
	void ConsumeItem(string sku);
	void RestoreItem();
	void VerifyLastBuy();
	void RetrieveItemDetails();
}