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

    public void Startup()
    {
        Debug.Log("Spawn Manager Starting Up");

        status = ManagerStatus.Initializing;

        //PlayerOneGO = Global.Instance.GetPlayerOneGO();

        //PlayerTwoGO = Global.Instance.GetPlayerTwoGO();

        status = ManagerStatus.Started;
    }

    public void SpawnPlayers()
    {
        GameObject p1 = (GameObject)Instantiate (PlayerOneGO, p1SpawnLocation.transform.position, PlayerOneGO.transform.rotation);
        p1.layer = 10;
        p1.name = "Player1";
        p1.GetComponentInChildren<SkinnedMeshRenderer>().material.color = Color.blue;

        GameObject p2 = (GameObject)Instantiate (PlayerTwoGO, p2SpawnLocation.transform.position, PlayerTwoGO.transform.rotation);
        p2.layer = 10;
        p2.name = "Player2";
        p2.GetComponentInChildren<SkinnedMeshRenderer>().material.color = Color.red;

    }

    public void RespawnPlayer(int player)
    {
        if(player == 1)
        {
            Debug.LogFormat("Spawning Player at : {0}, {1}, {2}", p1SpawnLocation.transform.position.x, p1SpawnLocation.transform.position.y, p1SpawnLocation.transform.position.z);
            GameObject p1 = (GameObject)Instantiate (PlayerOneGO, p1SpawnLocation.transform.position, PlayerOneGO.transform.rotation);
            p1.layer = 10;
            p1.name = "Player1";
            p1.GetComponentInChildren<SkinnedMeshRenderer>().material.color = Color.blue;
        } 
        else if (player == 2)
        {
            Debug.LogFormat("Spawning Player at : {0}, {1}, {2}", p1SpawnLocation.transform.position.x, p1SpawnLocation.transform.position.y, p1SpawnLocation.transform.position.z);
            GameObject p2 = (GameObject)Instantiate (PlayerTwoGO, p2SpawnLocation.transform.position, PlayerTwoGO.transform.rotation);
            p2.layer = 10;
            p2.name = "Player2";
            p2.GetComponentInChildren<SkinnedMeshRenderer>().material.color = Color.red;
        } else {
            Debug.Log("INVALID PLAYER RESPAWN. ATTEMPTED RESPAWN OF PLAYER " + player);
        }
    }
}
