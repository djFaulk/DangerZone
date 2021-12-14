using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Global : MonoBehaviour
{
		

		public static Global Instance; 
		
		public int player1Score = 0;
		public int player2Score = 0;
		public List<GameObject> gameItems;
		public bool p1Dead = false;
		public bool p2Dead = false;
		public int playerHasFlag;
		public bool playerScored = false;
		public float time = 300f;
		public Sprite player1Item = null;
		public Sprite player2Item = null;
		public GameObject playerOneGameObject;
		public GameObject playerTwoGameObject;
		public GameObject flag;
		public List<string> playerNeedsSpawn;
		private int totalObjectsAllowed = 15;
		private int objSpawnedAmount = 0;
		private bool respawnNeeded = false;
		

		void Awake ()
		{
				Instance = this;
				DontDestroyOnLoad (this);
		}

        void Update()
        {
            Global.Instance.time -= Time.deltaTime;
        }
	#region Player
		public GameObject GetPlayerOneGO ()
		{
				return playerOneGameObject;
		}

		public GameObject GetPlayerTwoGO ()
		{
				return playerTwoGameObject;
		}

		public void SetPlayerOneGO (GameObject go)
		{
				playerOneGameObject = go;
		}

		public void SetPlayerTwoGO (GameObject go)
		{
				playerTwoGameObject = go;
		}
		public void PlayerDeathSpawn (string player)
		{
				playerNeedsSpawn.Add (player);
		}
		
		public void SetRespawnNeeded (bool respawn)
		{
				respawnNeeded = respawn;
		}
		public bool GetRespawnNeeded ()
		{
				return respawnNeeded;
		}
		#endregion

	#region Items
		public bool CanSpawnItem ()
		{
				return objSpawnedAmount < totalObjectsAllowed;
		}
		public void IncrementItemCounter ()
		{
				objSpawnedAmount ++;
		}
		public void DecrementItemCounter ()
		{
				objSpawnedAmount--;
		}
		public GameObject GetRandomItem ()
		{
				return gameItems [Random.Range (0, gameItems.Count)];
		}
		
#endregion
	#region bad programming
		public void RefreshFlag ()
		{
				flag.GetComponent<Collider>().enabled = true;
				flag.GetComponent<Rigidbody>().useGravity = true;
				flag.transform.position = new Vector3(flag.transform.position.x, flag.transform.position.y, 0);
		}
	#endregion
}
