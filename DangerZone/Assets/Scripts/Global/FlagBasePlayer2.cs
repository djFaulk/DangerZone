using UnityEngine;
using System.Collections;

public class FlagBasePlayer2 : MonoBehaviour
{

		void OnTriggerEnter (Collider col)
		{
				if (col.gameObject.name == "Player2" && Global.Instance.playerHasFlag == 2) {
						Global.Instance.player2Score++;
						Global.Instance.playerScored = true;
				} 
		}
}
