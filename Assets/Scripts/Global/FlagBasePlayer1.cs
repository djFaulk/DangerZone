using UnityEngine;
using System.Collections;

public class FlagBasePlayer1 : MonoBehaviour
{

		void OnTriggerEnter (Collider col)
		{
				Debug.Log ("Balls" + " " + Global.Instance.playerHasflag + " " + col.gameObject.name);
				
				if (col.gameObject.name == "Player1" && Global.Instance.playerHasflag == "Player1") {
						Global.Instance.player1Score++;
						Global.Instance.playerScored = true;
				} 
		}
}
