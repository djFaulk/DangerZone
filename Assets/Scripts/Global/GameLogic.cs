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

		IEnumerator Start ()
		{
				
				

				while (!gameEnded) {
						
						Global.Instance.time -= Time.deltaTime;
						//Debug.Log (time / 60);
						yield return StartCoroutine (SpawnPlayers ());
						
						yield return StartCoroutine (ResetRound ());

                        yield return StartCoroutine(SpawnTheDead());
						
						yield return StartCoroutine (PlayerScore ());
						
						
						if (Global.Instance.time <= 0) {

								gameEnded = true;
						}

						if (Global.Instance.player1Score >= 3 || Global.Instance.player2Score >= 3) {
								//end game
								gameEnded = true;
						}

				}

				if (gameEnded) {
						winPanel.SetActive (true);
						if (Global.Instance.player1Score > Global.Instance.player2Score) {
								TweenAlpha.Begin (winPanel, 1, 1);
								winPanel.GetComponentInChildren<UILabel> ().text = "Player 1 Wins!";
								yield return StartCoroutine (Winner ());
								

						}
						if (Global.Instance.player1Score < Global.Instance.player2Score) {
								TweenAlpha.Begin (winPanel, 1, 1);
								winPanel.GetComponentInChildren<UILabel> ().text = "Player 2 Wins!";				
								yield return StartCoroutine (Winner ());
						}
						if (Global.Instance.player1Score == Global.Instance.player2Score) {
								TweenAlpha.Begin (winPanel, 1, 1);
								winPanel.GetComponentInChildren<UILabel> ().text = "Tie!";				
								yield return StartCoroutine (Winner ());
						}
				}


		}
		
		IEnumerator PlayerScore ()
		{
				if (Global.Instance.playerScored) {

						Global.Instance.playerScored = false;
						roundReset = true;
				}
				yield return 0;
		}

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

		//		yield return 0;


		}

		IEnumerator SpawnPlayers ()
		{
				if (!gameStarted) {
						Debug.Log ("spawn");
						gameStarted = true;
						Global.Instance.flag = GameObject.FindGameObjectWithTag ("Flag").gameObject;
						gameObject.GetComponent<Spawner> ().SpawnPlayer ("Player1");
						gameObject.GetComponent<Spawner> ().SpawnPlayer ("Player2");
				}
				yield return 0;
		}

		IEnumerator ReSpawnPlayers ()
		{

				gameObject.GetComponent<Spawner> ().SpawnPlayer ("Player1");
				gameObject.GetComponent<Spawner> ().SpawnPlayer ("Player2");

				yield return 0;
		}

		IEnumerator SpawnTheDead ()
		{

                //yield return new WaitForSeconds(.5f);

				
				if (Global.Instance.p1Dead && Global.Instance.p2Dead) {
					
						roundReset = true;
						Global.Instance.p1Dead = false;
						Global.Instance.p2Dead = false;
				} else if (Global.Instance.p1Dead) {
						gameObject.GetComponent<Spawner> ().SpawnPlayer ("Player1");
						Global.Instance.p1Dead = false;
				} else if (Global.Instance.p2Dead) {
						gameObject.GetComponent<Spawner> ().SpawnPlayer ("Player2");
						Global.Instance.p2Dead = false;
				}	
				
				yield return 0;
		}

		IEnumerator Winner ()
		{
								
				
				yield return new WaitForSeconds (2.0f);
				Application.LoadLevel ("Menu");
				yield return 0;

		}

		void Update ()
		{
				if (Input.GetKeyDown (KeyCode.P)) {
						roundReset = true;
				}
		}
		
		
}
