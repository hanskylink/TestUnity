using UnityEngine;
using System.Collections;

public partial class SkylinkDemo : MonoBehaviour {
	public GameObject GaV3;

	private GoogleAnalyticsV3 googleAnalytics{ get { return GaV3.GetComponent<GoogleAnalyticsV3> (); } }

	void AnaStart () {

	}

	void AnaOnGUI () {
		if( GUILayout.Button("send LogEvent") ){
			googleAnalytics.LogEvent ("hahacate", "hahaaction", "hahalabel", 10);
		}
		if( GUILayout.Button("send LogScreen") ){
			googleAnalytics.LogScreen("hahascreen");
		}
		if( GUILayout.Button("send LogException") ){
			googleAnalytics.LogException("hahaIncorrect input exception", true);
		}
		if( GUILayout.Button("send LogTiming") ){
			googleAnalytics.LogTiming("hahaLoading", 50L, "hahascreen", "First Load");
		}
		if( GUILayout.Button("send LogSocial") ){
			googleAnalytics.LogSocial("hahatwitter", "retweet", "twitter.com/googleanalytics/status/482210840234295296");
		}
		if( GUILayout.Button("send LogTransaction") ){
			googleAnalytics.LogTransaction("hahaTRANS001", "Coin Store", 1.0, 0.0, 0.0, "USD");
		}
		if( GUILayout.Button("send LogItem") ){
			googleAnalytics.LogItem("hahaTRANS001", "Sword", "100gem", "Weapon", 1.0, 2, "USD");
		}

	}
}
