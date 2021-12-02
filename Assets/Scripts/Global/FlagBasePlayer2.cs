using UnityEngine;
using System.Collections;

public class FlagBasePlayer2 : MonoBehaviour
{

		void OnTriggerEnter (Collider col)
		{
				if (col.gameObject.name == "Player2" && Global.Instance.playerHasflag == "Player2") {
						Global.Instance.player2Score++;
						Global.Instance.playerScored = true;
				} 
		}
}
