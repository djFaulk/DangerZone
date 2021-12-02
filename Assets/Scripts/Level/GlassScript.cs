using UnityEngine;
using System.Collections;

public class GlassScript : ItemBase
{
	
		public override void onHit ()
		{
				Destroy (gameObject);
		}

	#region implemented abstract members of ItemBase

		public override void OnCollisionEnter (Collision col)
		{
				if (col.transform.tag == "Player" && tag == "ThrownItem") {
						col.gameObject.GetComponent<PlayerDeath> ().OnDeath ();
						Destroy (gameObject);
				}
				transform.GetComponent<Collider>().enabled = true;
				transform.tag = "Item";
				
		}

	#endregion
}