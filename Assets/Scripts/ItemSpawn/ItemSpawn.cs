using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ItemSpawn : MonoBehaviour
{

		public List<GameObject> spawnLocations;
		
	
		IEnumerator Start ()
		{

		
				while (true) {
						yield return StartCoroutine (SpawnItem ());
						yield return new WaitForSeconds (.5f);

				}
		}
	
		IEnumerator SpawnItem ()
		{
				
				GameObject spawnLocObj = GetRandomSpawnLocation ();
				GameObject objToSpawn = Global.Instance.GetRandomItem ();
				Global.Instance.IncrementItemCounter ();
				GameObject go = (GameObject)Instantiate (objToSpawn, spawnLocObj.transform.position, Quaternion.identity);
				go.tag = "Item";
				
				yield return 0;
		}
	
		void Update ()
		{

		}

		GameObject GetRandomSpawnLocation ()
		{
				return spawnLocations [Random.Range (0, spawnLocations.Count)];
		}
}
