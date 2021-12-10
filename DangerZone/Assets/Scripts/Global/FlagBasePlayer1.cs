using UnityEngine;
using System.Collections;

public class FlagBasePlayer1 : MonoBehaviour
{

		void OnTriggerEnter (Collider col)
		{
				Debug.Log ("Balls " + Global.Instance.playerHasFlag + " " + col.gameObject.name);
				
				if (col.gameObject.name == "Player1" && Global.Instance.playerHasFlag == 1) {
						Global.Instance.player1Score++;
						Global.Instance.playerScored = true;
				} 
		}
}
