using UnityEngine;
using System.Collections;

public class SkylinkIAPManagerAndroid : ISkylinkIAPManager {

	private ISkylinkIAPManagerDelegate _delegate;
	public ISkylinkIAPManagerDelegate Delegate { set{ _delegate = value; } get{ return _delegate; } }

	public bool IsIOS{ get{ return false; } }
	public bool IsAndroid{ get{ return true; } }

	private static SkylinkIAPManagerAndroid _instance;

	public void Init(){
		_instance = this;
		AndroidInAppPurchaseManager.ActionProductPurchased += ActionProductPurchased;
		AndroidInAppPurchaseManager.ActionProductConsumed += ActionProductConsumed;
		AndroidInAppPurchaseManager.ActionBillingSetupFinished += ActionBillingSetupFinished;
		AndroidInAppPurchaseManager.ActionRetrieveProducsFinished += ActionRetrieveProducsFinished;
		AndroidInAppPurchaseManager.instance.loadStore ();
	}

	public void AddProduct(string sku){
		AndroidInAppPurchaseManager.instance.addProduct (sku);
	}
	
	public void BuyItem(string sku){
		AndroidInAppPurchaseManager.instance.purchase (sku);
	}

	public ISkylinkItem GetItem(string sku){
		GoogleProductTemplate obj = AndroidInAppPurchaseManager.instance.inventory.GetProductDetails (sku);
		if( obj != null )
			return new SkylinkItem_GoogleProductTemplate{ Value = obj };
		else
			return null;
	}
	
	public void ConsumeItem(string sku){
		AndroidInAppPurchaseManager.instance.consume (sku);
	}
	
	public void RestoreItem(){

	}
	
	public void VerifyLastBuy(){

	}

	public void RetrieveItemDetails(){
		AndroidInAppPurchaseManager.instance.retrieveProducDetails ();
	}

	private void OnActionProductPurchased(BillingResult result){
		if( Delegate != null ){
			Delegate.OnBuyItemComplete(this, new SkylinkIAPResult_BillingResult{ Value = result } );
		}
	}
	
	private void OnActionProductConsumed(BillingResult result){
		if( Delegate != null ){
			Delegate.OnConsumeComplete(this, new SkylinkIAPResult_BillingResult{ Value = result } );
		}
	}
	
	private void OnActionBillingSetupFinished(BillingResult result){
		if( Delegate != null ){
			Delegate.OnInitComplete(this, new SkylinkIAPResult_BillingResult{ Value = result } );
		}
	}
	
	private void OnActionRetrieveProducsFinished(BillingResult result){
		if( Delegate != null ){
			Delegate.OnRetrieveItemDetailFinished(this, new SkylinkIAPResult_BillingResult{ Value = result } );
		}
	}

	private static void ActionProductPurchased(BillingResult result){
		_instance.OnActionProductPurchased (result);
	}

	private static void ActionProductConsumed(BillingResult result){
		_instance.OnActionProductConsumed (result);
	}

	private static void ActionBillingSetupFinished(BillingResult result){
		_instance.OnActionBillingSetupFinished (result);
	}

	private static void ActionRetrieveProducsFinished(BillingResult result){
		_instance.OnActionRetrieveProducsFinished (result);
	}
}
