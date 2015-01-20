using UnityEngine;
using System.Collections;

public partial class SkylinkDemo : ISkylinkIAPManagerDelegate{

	private string SKU_GAM100 = "100gem";
	private string SKU_NO_ADS = "no_ads2";

	private ISkylinkIAPManager iapMgr = SkylinkFactory.createIAPManager();

	// Use this for initialization
	void IAPStart () {
		iapMgr.Delegate = this;
		// manually do this is safety
		iapMgr.AddProduct (SKU_GAM100);
		iapMgr.AddProduct (SKU_NO_ADS);
	}

	public void OnInitComplete(ISkylinkIAPManager mgr, ISkylinkIAPResult result){
		Log ("OnInitComplete:"+result.IsSuccess);
		if( result.IsSuccess ){
			if( mgr.IsAndroid ){
				Log ("RetrieveItemDetails:");
				mgr.RetrieveItemDetails();
			}else if( mgr.IsIOS ){
				OnRetrieveItemDetailFinished( mgr, result );
			}
		}else{
			Log ( result.Message );
		}
	}
	public void OnBuyItemComplete(ISkylinkIAPManager mgr, ISkylinkIAPResult result){
		Log ("OnBuyItemComplete:"+result.IsSuccess);
		if( result.IsSuccess ){
			Log ( "item:"+result.SKU );
			if( mgr.IsIOS ){
				Log ( "Receipt:"+SkylinkFactory.GetReceipt( result ) );
				if( SkylinkFactory.IsRestoreItem( result ) ){
					Log ("restore item:"+result.SKU);
				} else {
					Log ("new item:"+result.SKU);
				}
			} else if( mgr.IsAndroid ){
				Log ("ConsumeItem:"+result.SKU);
				mgr.ConsumeItem( result.SKU );
			}

		}else{
			Log ( result.Message );
		}
	}
	public void OnRestoreComplete(ISkylinkIAPManager mgr, ISkylinkIAPResult result){
		Log ("OnRestoreComplete:"+result.IsSuccess);
		if( result.IsSuccess ){

		}else{
			Log ( result.Message );
		}
	}
	public void OnConsumeComplete(ISkylinkIAPManager mgr, ISkylinkIAPResult result){
		Log ("OnConsumeComplete:"+result.IsSuccess);
		if( result.IsSuccess ){
			
		}else{
			Log ( result.Message );
		}
	}
	public void OnRetrieveItemDetailFinished(ISkylinkIAPManager mgr, ISkylinkIAPResult result){
		Log ("OnRetrieveItemDetailFinished:"+result.IsSuccess);

		if( result.IsSuccess ){
			ISkylinkItem item = iapMgr.GetItem (SKU_GAM100);
			if( item!= null ){
				Log ("item title:" + item.Title);
				Log ("item description:" + item.Description);
			}else{
				Log ("no have item "+SKU_GAM100);
			}
			
			item = iapMgr.GetItem (SKU_NO_ADS);
			if( item!= null ){
				Log ("item title:" + item.Title);
				Log ("item description:" + item.Description);
			}else{
				Log ("no have item "+SKU_NO_ADS);
			}
		}else{
			Log ( result.Message );
		}

	}
	public void OnVerificationComplete(ISkylinkIAPManager mgr, ISkylinkIAPResult result){
		Log ("OnVerificationComplete"+result.IsSuccess);
	}



	void IAPOnGUI(){
		if( GUILayout.Button("SetupIAB") ){
			Log ("SetupIAB");
			iapMgr.Init();
		}
		
		if( GUILayout.Button("Query") ){
			Log ("Query");
			iapMgr.RetrieveItemDetails();
		}
		
		if( GUILayout.Button("100gem") ){
			Log ("buy 100gem");
			iapMgr.BuyItem(SKU_GAM100);
		}
		
		if( GUILayout.Button("consume 100gem")){
			Log ("consume 100gem");
			iapMgr.ConsumeItem(SKU_GAM100);
		}
		
		if( GUILayout.Button("no_ads") ){
			Log ("buy no_ads");
			iapMgr.BuyItem(SKU_NO_ADS);
		}
		
		if( GUILayout.Button("consume no_ads2")){
			Log ("consume no_ads");
			iapMgr.ConsumeItem(SKU_NO_ADS);
		}
		
		if( GUILayout.Button("restore") ){
			iapMgr.RestoreItem();
		}

	}

	/*
	private Vector2 sp;
	private string msg = "debuger";
	
	public void Log(object obj){
		msg = obj.ToString () + "\n" + msg;
	}
	
	void OnGUI(){
		GUILayout.BeginArea (new Rect (0, 0, 500, 900));
		
		sp = GUILayout.BeginScrollView (sp, GUILayout.Width (500), GUILayout.Height (300));
		
		GUILayout.Label (msg);
		
		GUILayout.EndScrollView ();

		IAPOnGUI ();
		
		GUILayout.EndArea ();
	}
	*/
}
