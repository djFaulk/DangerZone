using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawnManager : MonoBehaviour, IGameManager
{
    public ManagerStatus status {get; private set;}
    [SerializeField] private GameObject p1SpawnLocation;
    [SerializeField] private GameObject p2SpawnLocation;
    [SerializeField] private GameObject PlayerOneGO;
    [SerializeField] private GameObject PlayerTwoGO;

    //[SerializeField] private GameObject player1Obj;
    private bool player1Spawned;
    private bool player2Spawned;
    //[SerializeField] private GameObject player2Obj;

    private void Awake() {
		Messenger<int>.AddListener(GameEvent.PLAYER_DIED, OnDeath);
        Debug.Log("Adding listener in PlayerSpawnManager");
	}

    private void OnDestroy() {
		Messenger<int>.RemoveListener(GameEvent.PLAYER_DIED, OnDeath);
	}

    public void Startup()
    {
        Debug.Log("Spawn Manager Starting Up");

        status = ManagerStatus.Initializing;

        player1Spawned = false;
        player2Spawned = false;

        status = ManagerStatus.Started;
    }



    public void SpawnPlayers()
    {
        if(!player1Spawned)
        {        
            GameObject player1Obj = (GameObject)Instantiate (PlayerOneGO, p1SpawnLocation.transform.position, PlayerOneGO.transform.rotation);
            player1Spawned = true;
            player1Obj.layer = 10;
            player1Obj.name = "Player1";
            player1Obj.GetComponentInChildren<SkinnedMeshRenderer>().material.color = Color.blue;
        }

        if(!player2Spawned)
        {
            GameObject player2Obj = (GameObject)Instantiate (PlayerTwoGO, p2SpawnLocation.transform.position, PlayerTwoGO.transform.rotation);
            player2Spawned = true;
            player2Obj.layer = 10;
            player2Obj.name = "Player2";
            player2Obj.GetComponentInChildren<SkinnedMeshRenderer>().material.color = Color.red;
        }


    }

    public void RespawnPlayer(int player)
    {
        Debug.Log("Respawning Player: " + player);
        if(player == 1)
        {
            if(!player1Spawned)
            {
                //Debug.LogFormat("Spawning Player at : {0}, {1}, {2}", p1SpawnLocation.transform.position.x, p1SpawnLocation.transform.position.y, p1SpawnLocation.transform.position.z);
                GameObject player1Obj = (GameObject)Instantiate (PlayerOneGO, p1SpawnLocation.transform.position, PlayerOneGO.transform.rotation);
                player1Spawned = true;
                player1Obj.layer = 10;
                player1Obj.name = "Player1";
                player1Obj.GetComponentInChildren<SkinnedMeshRenderer>().material.color = Color.blue;
            }

        } 
        else if (player == 2)
        {
            if(!player2Spawned)
            {
                //Debug.LogFormat("Spawning Player at : {0}, {1}, {2}", p1SpawnLocation.transform.position.x, p1SpawnLocation.transform.position.y, p1SpawnLocation.transform.position.z);
                GameObject player2Obj = (GameObject)Instantiate (PlayerTwoGO, p2SpawnLocation.transform.position, PlayerTwoGO.transform.rotation);
                player2Spawned= true;
                player2Obj.layer = 10;
                player2Obj.name = "Player2";
                player2Obj.GetComponentInChildren<SkinnedMeshRenderer>().material.color = Color.red;
            }

        } else {
            Debug.Log("INVALID PLAYER RESPAWN. ATTEMPTED RESPAWN OF PLAYER " + player);
        }
    }

    private void OnDeath(int player)
    {
        Debug.Log("SpawnPlayerManager.OnDeath: player " + player);
        if(player == 1)
        {
            player1Spawned = false;
        } 
        else if (player == 2)
        {
            player2Spawned = false;
        }
        else
        {
            Debug.Log("INVALID PLAYER DIED. PLAYER " + player + " REPORTED DEAD");
            //return;
        }

        StartCoroutine(WaitForRespawn(1.5f, player));
    }

    IEnumerator WaitForRespawn(float time, int player)
    {
        Debug.Log("Waiting for respawn");
        yield return new WaitForSeconds(time);
		RespawnPlayer (player);
    }
}
