using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour
{

		public GameObject player1SpawnLoc;
		public GameObject player2SpawnLoc;
		public Material player1Mat;
		public Material player2Mat;

		public void SpawnPlayer (string playerid)
		{
				if (playerid == "Player1") {
						GameObject temp = (GameObject)Instantiate (Global.Instance.GetPlayerOneGO (), player2SpawnLoc.transform.position, Global.Instance.GetPlayerOneGO ().transform.rotation);
						//Global.Instance.p1Dead = false;
						temp.layer = 10;
						temp.name = "Player1";
						temp.GetComponentInChildren<SkinnedMeshRenderer> ().material.color = Color.blue;

				} else {
						GameObject temp = (GameObject)Instantiate (Global.Instance.GetPlayerTwoGO (), player1SpawnLoc.transform.position, Global.Instance.GetPlayerTwoGO ().transform.rotation);
						//Global.Instance.p2Dead = false;
						temp.layer = 11;
						temp.name = "Player2";
						temp.GetComponentInChildren<SkinnedMeshRenderer> ().material.color = Color.red;
				}
		}
}
