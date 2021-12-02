using UnityEngine;
using System.Collections;

public class GunAbility : MonoBehaviour
{

		public float shootCoolDown = 5.0f;

		public GameObject bulletPrefab;

		public GameObject pointToShootFrom;

		public float bulletSpeed;

		// Use this for initialization
		void Start ()
		{
	
		}
	
		// Update is called once per frame
		void Update ()
		{

				if (Input.GetButtonDown (this.gameObject.name + "Y")) {
						if (shootCoolDown <= 0) {
								shootCoolDown = 5.0f;

								GameObject bullet = Instantiate (bulletPrefab, pointToShootFrom.transform.position,
                    Quaternion.identity) as GameObject;
								bullet.gameObject.name = gameObject.name;
								bullet.GetComponent<Bullet> ().velocity = gameObject.transform.forward * bulletSpeed;

						}

				}

				if (shootCoolDown > 0) {

						shootCoolDown -= Time.deltaTime;

				}


		}
}
