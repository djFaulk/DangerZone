using UnityEngine;
using System.Collections;

public class PlayerDeath : MonoBehaviour, IDeath
{

	#region IDeath implementation

	public void OnDeath ()
	{
		int player = -1;
		if (gameObject.name == "Player1") {
			if(Global.Instance.playerHasFlag == 1) Global.Instance.playerHasFlag = -1;
			player = 1;
			Global.Instance.p1Dead = true;
			//Debug.Log (Global.Instance.p1Dead);
			GameObject p2 = GameObject.Find("Player2");
			//if(p2 != null) p2.GetComponentInChildren<ItemManager> ().itemCatch (GameObject.FindGameObjectWithTag ("Flag"));
			Debug.Log("Flag given to Player 2");
		} else if (gameObject.name == "Player2") {
			if(Global.Instance.playerHasFlag == 2) Global.Instance.playerHasFlag = -1;
			player = 2;
			Global.Instance.p2Dead = true;
			Debug.Log (Global.Instance.p1Dead + " p2");
			GameObject p1 = GameObject.Find("Player1");
			//if (p1 != null) p1.GetComponentInChildren<ItemManager>().itemCatch(GameObject.FindGameObjectWithTag("Flag"));
			Debug.Log("Flag given to Player 1");
		}
		Debug.Log("Player" + player + " has died");
		Messenger<int>.Broadcast(GameEvent.PLAYER_DIED,player);
		Global.Instance.RefreshFlag ();

		Destroy (GetComponentInChildren<ItemManager> ().itemHeld);

		Destroy (gameObject);	
	}

	#endregion


}
