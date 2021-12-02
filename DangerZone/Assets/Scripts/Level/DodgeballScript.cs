using UnityEngine;
using System.Collections;

public class DodgeballScript : ItemBase
{
		void Start ()
		{
				gameObject.GetComponent<SpriteRenderer> ().sprite = base.getSprite ();
		}
	#region implemented abstract members of ItemBase

		public override void onHit ()
		{
				throw new System.NotImplementedException ();
		}

	#endregion

		

		
	#region implemented abstract members of ItemBase
		public override void OnCollisionEnter (Collision col)
		{
				if (col.transform.tag == "Player" && tag == "ThrownItem") {
						col.gameObject.GetComponent<PlayerDeath> ().OnDeath ();
						Global.Instance.DecrementItemCounter ();
						Destroy (gameObject);
				} 
				transform.GetComponent<Collider>().enabled = true;
				transform.tag = "Item";
				
		}
	#endregion
}