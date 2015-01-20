using UnityEngine;
using System.Collections;
using UnionAssets.FLE;
using System.Collections.Generic;

public class SkylinkIAPManagerIOS : ISkylinkIAPManager{

	private ISkylinkIAPManagerDelegate _delegate;
	public ISkylinkIAPManagerDelegate Delegate { set{ _delegate = value; } get{ return _delegate; } }
#if DEBUG
	private string _verifyUrl = IOSInAppPurchaseManager.SANDBOX_VERIFICATION_SERVER;
#else
	private string _verifyUrl = IOSInAppPurchaseManager.APPLE_VERIFICATION_SERVER;
#endif
	public bool IsIOS{ get{ return true; } }
	public bool IsAndroid{ get{ return false; } }

	// Call this function at first time 
	public void Init(){
		IOSInAppPurchaseManager.instance.OnStoreKitInitComplete += OnStoreKitInitComplete;
		IOSInAppPurchaseManager.instance.OnRestoreComplete += OnRestoreComplete;
		IOSInAppPurchaseManager.instance.OnTransactionComplete += OnTransactionComplete;
		IOSInAppPurchaseManager.instance.OnVerificationComplete += OnVerificationComplete;
		IOSInAppPurchaseManager.instance.loadStore ();
	}

	// Call AddProduct before Init, and then we can call BuyItem and GetItem
	public void AddProduct(string sku){
		IOSInAppPurchaseManager.instance.addProductId (sku);
	}

	public void BuyItem(string sku){
		IOSInAppPurchaseManager.instance.buyProduct (sku);
	}

	// You can get item information after OnInitComplete
	public ISkylinkItem GetItem(string sku){
		IOSProductTemplate obj = IOSInAppPurchaseManager.instance.GetProductById (sku);
		if( obj == null )
			return null;
		return new SkylinkItem_IOSProductTemplate{ Value = obj };
	}

	public void ConsumeItem(string sku){
		// IOS don't need this feature
	}

	// Call this function right after OnInitComplete to restore purchased item
	// This function will trigger OnBuyItemComplete
	public void RestoreItem(){
		IOSInAppPurchaseManager.instance.restorePurchases ();
	}

	// This function for verify item in device. 
	// After BuyItem we can get the receipt, and then we can verify it manually. 
	// So we don't need to call this function.
	public void VerifyLastBuy(){
		IOSInAppPurchaseManager.instance.verifyLastPurchase (_verifyUrl);
	}

	public void RetrieveItemDetails(){
		// IOS don't need this feature
	}

	private void OnRestoreComplete(ISN_Result result){
		if( Delegate != null ){
			Delegate.OnRestoreComplete(this, new SkylinkIAPResult_ISN_Result{ Value = result } );
		}
	}

	private void OnVerificationComplete(IOSStoreKitVerificationResponse response) {
		if( Delegate != null ){
			Delegate.OnVerificationComplete(this, new SkylinkIAPResult_ISN_Result{ Value = response } );
		}
	}

	private void OnStoreKitInitComplete(ISN_Result result) {
		if( Delegate != null ){
			Delegate.OnInitComplete(this, new SkylinkIAPResult_ISN_Result{ Value = result } );
		}
	}
	
	private void OnTransactionComplete (IOSStoreKitResponse response) {
		if( Delegate != null ){
			Delegate.OnBuyItemComplete(this, new SkylinkIAPResult_IOSStoreKitResponse{ Value = response } );
		}
	}
}
