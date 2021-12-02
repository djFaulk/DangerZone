using UnityEngine;
using System.Collections;

public class PlayerDeath : MonoBehaviour, IDeath
{
		
		// Use this for initialization
		void Start ()
		{
			
		
		
		}
		void Update ()
		{
			
		}	
		// Update is called once per frame

	#region IDeath implementation

		public void OnDeath ()
		{
				
				if (gameObject.name == "Player1") {
						Global.Instance.p1Dead = true;
						Debug.Log (Global.Instance.p1Dead);
                        GameObject p2 = GameObject.Find("Player2");
                        if(p2 != null) p2.GetComponentInChildren<ItemManager> ().itemCatch (GameObject.FindGameObjectWithTag ("Flag"));
				} else if (gameObject.name == "Player2") {
						Global.Instance.p2Dead = true;
						Debug.Log (Global.Instance.p1Dead + " p2");
                        GameObject p1 = GameObject.Find("Player1");
                        if (p1 != null) p1.GetComponentInChildren<ItemManager>().itemCatch(GameObject.FindGameObjectWithTag("Flag"));
				}
				//Global.Instance.PlayerDeathSpawn (gameObject.name);
				//	Global.Instance.SetRespawnNeeded (true);
				Global.Instance.RefreshFlag ();
			
				Destroy (GetComponentInChildren<ItemManager> ().itemHeld);
				

					
				//
			
				Destroy (gameObject);
				
				
		}

				#endregion


}
