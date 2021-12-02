using UnityEngine;
using System.Collections;

public class Kill : MonoBehaviour
{

		void OnTriggerEnter (Collider col)
		{
				if (col.tag == "Player") {
						col.GetComponent<PlayerDeath> ().OnDeath ();
				
						
				}
		}
}
