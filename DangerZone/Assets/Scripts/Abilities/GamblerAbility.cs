using UnityEngine;
using System.Collections;

public class GamblerAbility : MonoBehaviour
{

		float gamblerAbilityCoolDown;

		

		// Use this for initialization
		void Start ()
		{
	
			

		}
	
		// Update is called once per frame
		void Update ()
		{
	
				if (Input.GetButtonDown (gameObject.name + "Y")) {
						if (gamblerAbilityCoolDown <= 0) {

								//gameObject.GetComponentInChildren<ItemManager> ().itemCatch (Global.Instance.GetRandomItem ());
						}
				}

				if (gamblerAbilityCoolDown > 0) {

						gamblerAbilityCoolDown -= Time.deltaTime;

				}

		}
}
