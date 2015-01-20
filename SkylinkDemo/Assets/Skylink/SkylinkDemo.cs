
using UnityEngine;
using System.Collections;

public partial class SkylinkDemo : MonoBehaviour, ISkylinkIAPManagerDelegate{
	
	void Start () {
		IAPStart();
		NotiStart ();
		AnaStart ();
	}
	
	private Vector2 sp;
	private string msg = "debuger";
	
	public void Log(object obj){
		msg = obj.ToString () + "\n" + msg;
	}
	
	void OnGUI(){
		GUILayout.BeginArea (new Rect (0, 0, 500, 900));
		
		sp = GUILayout.BeginScrollView (sp, GUILayout.Width (500), GUILayout.Height (200));
		
		GUILayout.Label (msg);
		
		GUILayout.EndScrollView ();

		AnaOnGUI ();
		NotiOnGUI ();
		IAPOnGUI ();
		
		GUILayout.EndArea ();
	}
}
