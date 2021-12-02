using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameLogic : MonoBehaviour
{
	//public GameObject mainCam; 
	public Transform origin; 
	bool gameStarted = false;
	bool gameEnded = false;

	bool roundReset = false;

	
	int player1Score = 0;
	int player2Score = 0;
	GameObject player1;
	GameObject player2;
	public GameObject winPanel;

	private void Awake() {
		Messenger<int>.AddListener(GameEvent.PLAYER_DIED, SpawnTheDead);
		//Messenger.AddListener(GameEvent.PLAYER_SCORED, PlayerScore);
	}

	private void OnDestroy() {
		Messenger<int>.RemoveListener(GameEvent.PLAYER_DIED, SpawnTheDead);
		//Messenger.RemoveListener(GameEvent.PLAYER_SCORED, PlayerScore);
	}

	void Start ()
	{
			
		SpawnPlayers();
		
		// while (!gameEnded) {
				
		// 	Global.Instance.time -= Time.deltaTime;
		// 	
			
		// 	yield return StartCoroutine (ResetRound ());
			
		// 	
			
		// 	if (Global.Instance.time <= 0) {
		// 			gameEnded = true;
		// 	}

		// 	if (Global.Instance.player1Score >= 3 || Global.Instance.player2Score >= 3) {
		// 			gameEnded = true;
		// 	}

		// }

		// if (gameEnded) {
		// 	winPanel.SetActive (true);
		// 	if (Global.Instance.player1Score > Global.Instance.player2Score) {
		// 			TweenAlpha.Begin (winPanel, 1, 1);
		// 			winPanel.GetComponentInChildren<UILabel> ().text = "Player 1 Wins!";
		// 			yield return StartCoroutine (Winner ());
					

		// 	}
		// 	if (Global.Instance.player1Score < Global.Instance.player2Score) {
		// 			TweenAlpha.Begin (winPanel, 1, 1);
		// 			winPanel.GetComponentInChildren<UILabel> ().text = "Player 2 Wins!";				
		// 			yield return StartCoroutine (Winner ());
		// 	}
		// 	if (Global.Instance.player1Score == Global.Instance.player2Score) {
		// 			TweenAlpha.Begin (winPanel, 1, 1);
		// 			winPanel.GetComponentInChildren<UILabel> ().text = "Tie!";				
		// 			yield return StartCoroutine (Winner ());
		// 	}
		// }


	}
	
	// void PlayerScore ()
	// {
	// 	if (Global.Instance.playerScored) {
			
	// 		Global.Instance.playerScored = false;
	// 		roundReset = true;
	// 	}
	// }

	IEnumerator ResetRound ()
	{
		if (roundReset) {
			roundReset = false;
			player1 = GameObject.Find ("Player1");
			player2 = GameObject.Find ("Player2");
			Destroy (player1);
			Destroy (player2);
			//mainCam.transform.position = origin.position;
			Global.Instance.flag.transform.position = origin.position;
			Global.Instance.flag.tag = "Flag";
			Global.Instance.RefreshFlag ();
			yield return new WaitForSeconds(.3f);
			yield return StartCoroutine(ReSpawnPlayers ());
		}
	}

	void SpawnPlayers ()
	{
			if (!gameStarted) {
				Debug.Log ("spawn");
				gameStarted = true;
				Global.Instance.flag = GameObject.FindGameObjectWithTag ("Flag").gameObject;
				gameObject.GetComponent<PlayerSpawnManager> ().SpawnPlayers ();
			}
			return;
	}

	IEnumerator ReSpawnPlayers ()
	{

			gameObject.GetComponent<PlayerSpawnManager> ().RespawnPlayer (1);
			gameObject.GetComponent<PlayerSpawnManager> ().RespawnPlayer (2);

			yield return 0;
	}

	void SpawnTheDead (int player)
	{
		if (Global.Instance.p1Dead && Global.Instance.p2Dead) {
			roundReset = true;
			Global.Instance.p1Dead = false;
			Global.Instance.p2Dead = false;
		} else if (player == 1 && Global.Instance.p1Dead) {
			gameObject.GetComponent<PlayerSpawnManager> ().RespawnPlayer (1);
			Global.Instance.p1Dead = false;
		} else if (player == 2 && Global.Instance.p2Dead) {
			gameObject.GetComponent<PlayerSpawnManager> ().RespawnPlayer (2);
			Global.Instance.p2Dead = false;
		}	
			
	}

	// IEnumerator Winner ()
	// {
	// 	yield return new WaitForSeconds (2.0f);
	// 	Application.LoadLevel ("Menu");
	// 	yield return 0;

	// }

	void Update ()
	{
			if (Input.GetKeyDown (KeyCode.P)) {
					roundReset = true;
			}
	}
		
		
}
