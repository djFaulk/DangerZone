using UnityEngine;
using System.Collections;

public class ItemManager : MonoBehaviour
{

		public GameObject itemHeld;
		public GameObject flagHeld;
		public GameObject player;
		public GameObject itemThrown;
		public GameObject pHand;
		public GameObject flagAnch;

		public GameObject rayStart;

		private Vector3 temp;
		public Vector3 cPlayerInput;

		public TestRun movement;

		public bool throwItem;

		private float angle;
		public float catchRange;

		private ItemBase itemScript;

		private RaycastHit rayHitInfo;

		// Use this for initialization
		void Start ()
		{
				flagHeld = null;
				itemHeld = null;
				player = this.gameObject.transform.parent.gameObject;

				throwItem = false;

				movement = GetComponentInParent<TestRun> ();

				catchRange = 1.2f;
	
		}
	
		// Update is called once per frame
		void Update ()
		{
				//Debug.Log (Global.Instance.playerHasflag);
				if (itemHeld != null) {
			
						itemHeld.transform.position = pHand.transform.position;
				}
				if (flagHeld != null) {
						
						flagHeld.transform.position = flagAnch.transform.position;
				}
				

				GetAiming ();

				foreach (Collider col in Physics.OverlapSphere(transform.position, catchRange)) {
						if (col.tag == "Item" || col.tag == "ThrownItem") {
								//Debug.DrawRay (rayStart.transform.position, col.transform.position - rayStart.transform.position);
						}
				}

				if ((Input.GetButton (player.name + "B") || Input.GetKeyDown (KeyCode.E))) {
						Debug.Log (player.name + "B button Pressed");

						foreach (Collider col in Physics.OverlapSphere(transform.position, catchRange)) {
								if (col.tag == "Flag" || col.tag == "Item" || col.tag == "ThrownItem") {
										Debug.DrawRay (rayStart.transform.position, col.transform.position - rayStart.transform.position);
										//if (Physics.Raycast (new Ray (rayStart.transform.position, col.transform.position - rayStart.transform.position), out rayHitInfo, catchRange)) {
										//if (rayHitInfo.collider.tag != "Player")
										itemCatch (col.gameObject);
										//}  
										/*					
					if (itemHeld != null && col.tag == "Flag") {
												if (rayHitInfo.collider.tag != "Player")
														itemCatch (col.gameObject);
										}*/
								}
						}
				}

				if (itemHeld != null && (Input.GetButtonDown (player.name + "X") || Input.GetKeyDown (KeyCode.F))) {
						Debug.Log (player.name + "X button pressed");

						throwItem = true;
				}
		}

		void FixedUpdate ()
		{

				if (itemHeld != null && throwItem == true) {

						//	Debug.Log (player.name + "item thrown");
						if (gameObject.transform.root.name == "Player1") {
								Global.Instance.player1Item = null;
						} else {
								Global.Instance.player2Item = null;
						}
						temp = 10f * cPlayerInput;
						
						throwItem = false;
						itemThrown = itemHeld; //Instantiate (itemHeld, itemHeld.transform.position, itemHeld.transform.rotation) as GameObject;
						itemThrown.tag = "ThrownItem";
						itemThrown.GetComponent<Rigidbody>().useGravity = true;
						itemThrown.GetComponent<Collider>().enabled = true;
						itemThrown.GetComponent<Rigidbody>().AddForce (temp + player.GetComponent<Rigidbody>().velocity, ForceMode.Impulse);
						//Destroy (itemHeld);
						itemHeld = null;
				}

		}

		public void itemCatch (GameObject item)
		{
				if (itemHeld == null && item.tag == "Item") {
						itemHeld = item;
						if (gameObject.transform.root.name == "Player1") {
								Global.Instance.player1Item = item.GetComponent<ItemBase> ().getSprite ();
						} else {
								Global.Instance.player2Item = item.GetComponent<ItemBase> ().getSprite ();
						}
						itemHeld.GetComponent<Collider>().enabled = false;
						itemHeld.GetComponent<Rigidbody>().velocity = Vector3.zero;
						itemHeld.GetComponent<Rigidbody>().useGravity = false;
						itemHeld.tag = "Item";
		
						if (player.name == "Player1")
								itemHeld.layer = 10;
						else if (player.name == "Player2")
								itemHeld.layer = 11;
				}
				if (item.tag == "Flag") {
						flagHeld = item;
						flagHeld.GetComponent<Collider>().enabled = false;
						flagHeld.GetComponent<Rigidbody>().velocity = Vector3.zero;
						flagHeld.GetComponent<Rigidbody>().useGravity = false;
						//itemHeld.tag = "Item";
						Global.Instance.playerHasflag = player.name;
						if (player.name == "Player1") {

								flagHeld.layer = 10;
								
						} else if (player.name == "Player2") {
			
								flagHeld.layer = 11;
								

						}
				}
		}

		void GetAiming ()
		{
				cPlayerInput = new Vector3 (Input.GetAxis (player.name + "RightStickX"), Input.GetAxis (player.name + "RightStickY"), 0.0f);

				angle = Mathf.Atan2 (Input.GetAxis (player.name + "RightStickX"), Input.GetAxis (player.name + "RightStickY")) * Mathf.Rad2Deg;

				transform.rotation = Quaternion.Euler (0.0f, 0.0f, angle);

				Debug.DrawRay (transform.position, cPlayerInput, Color.cyan);
		}
}
