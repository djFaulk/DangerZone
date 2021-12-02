using UnityEngine;
using System.Collections;

public class Invisibility : MonoBehaviour
{


		public float invisibilityCoolDown = 0.0f;

		public float invisibilityTimer = 0.0f;

		public bool invisible = false;

		public GameObject shield;

		// Use this for initialization
		void Start ()
		{
	
		}
	
		// Update is called once per frame
		void Update ()
		{

				if (Input.GetButtonDown (this.gameObject.name + "Y")) {

						if (invisibilityCoolDown <= 0) {

								invisibilityCoolDown = 5.0f;

								gameObject.GetComponentInChildren<SkinnedMeshRenderer> ().enabled = false;
								gameObject.layer = 15;


								invisible = true;
						}

				}

				if (invisible == true) {

						invisibilityTimer -= Time.deltaTime;

				}

				if (invisibilityTimer <= 0) {

						gameObject.GetComponentInChildren<SkinnedMeshRenderer> ().enabled = true;
						//gameObject.collider.enabled = true;
						//shield.collider.enabled = false;

						invisible = false;
						if (gameObject.name == "Player1") {
								gameObject.layer = 10;
						}
						if (gameObject.name == "Player2") {
								gameObject.layer = 11;
						}
						invisibilityTimer = 3.0f;

				}


				if (invisibilityCoolDown > 0) {

						invisibilityCoolDown -= Time.deltaTime;

						//Debug.Log(invisibilityCoolDown);

				}

		}
}
