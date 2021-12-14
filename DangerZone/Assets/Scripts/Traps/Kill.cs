using UnityEngine;
using System.Collections;

public class Kill : MonoBehaviour
{

		void OnTriggerEnter (Collider col)
		{
				if (col.tag == "Player") {
					col.GetComponent<PlayerDeath> ().OnDeath ();
				}
				else if (col.tag == "Flag")
				{	
					Transform flagSpawn = GameObject.Find("Main Camera").transform.Find("FlagSpawn");
					col.gameObject.transform.position = new Vector3(flagSpawn.position.x, flagSpawn.position.y, flagSpawn.position.z);
				}
		}
}
