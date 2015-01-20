using UnityEngine;
using System.Collections;

public interface ISkylinkIAPManagerDelegate {
	void OnInitComplete(ISkylinkIAPManager mgr, ISkylinkIAPResult result);
	void OnBuyItemComplete(ISkylinkIAPManager mgr, ISkylinkIAPResult result);
	void OnRestoreComplete(ISkylinkIAPManager mgr, ISkylinkIAPResult result);
	void OnConsumeComplete(ISkylinkIAPManager mgr, ISkylinkIAPResult result);
	void OnRetrieveItemDetailFinished(ISkylinkIAPManager mgr, ISkylinkIAPResult result);
	void OnVerificationComplete(ISkylinkIAPManager mgr, ISkylinkIAPResult result);
}