using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Managers : MonoBehaviour
{
    public static PlayerSpawnManager Spawner {get; private set;}
    private List<IGameManager> _startSequence;
   private void Awake() {
       Spawner = GetComponent<PlayerSpawnManager>();

       _startSequence = new List<IGameManager>();
       _startSequence.Add(Spawner);

       StartCoroutine(StartupManagers());
   }

    private IEnumerator StartupManagers()
    {
        foreach(IGameManager manager in _startSequence)
        {
            manager.Startup();
        }

        yield return null;

        int numModules = _startSequence.Count;
        int numReady = 0;

        while(numReady < numModules)
        {
            int lastReady = numReady;
            numReady = 0;

            foreach(IGameManager manager in _startSequence)
            {
                if(manager.status == ManagerStatus.Started) numReady++;
            }

            if(numReady > lastReady) Debug.Log("Manager Startup Progress: " + numReady + "/" + numModules);

        }
            Debug.Log("All Managers started up");
    }
}
