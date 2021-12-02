using UnityEngine;
using System.Collections;

public class DespawnItems : MonoBehaviour
{

		void OnCollisionEnter (Collision col)
		{
				if (col.gameObject.tag == "Item") {
						Global.Instance.DecrementItemCounter ();
						Destroy (col.gameObject);
				}
				if (col.gameObject.tag == "Player") {
						
						col.gameObject.GetComponent<PlayerDeath> ().OnDeath ();
				}
		}
}
