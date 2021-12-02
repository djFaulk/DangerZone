using UnityEngine;
using System.Collections;

public class MouseAiming : MonoBehaviour {

	Vector3 mousePos;
	Vector3 playerPos;
	Vector3 cPlayerInput;
	Vector3 temp;

	float angle;

	public GameObject bulletPrefab;
	GameObject bullet;
	GameObject player;

	public bool mouseKeyboard;

    public float maxMouseDist = 50.0f;

	// Use this for initialization
	void Start () {
		player = GameObject.Find("Player1");
		mouseKeyboard = true;
		//bullet = Instantiate(bulletPrefab, transform.position, transform.rotation) as GameObject;
	}
	
	// Update is called once per frame
	void Update () {
		if(mouseKeyboard){
			mousePos = Input.mousePosition;
            playerPos = Camera.main.WorldToScreenPoint(this.transform.position);

			mousePos.x = mousePos.x - playerPos.x;
			mousePos.y = mousePos.y - playerPos.y;

			angle = Mathf.Atan2(mousePos.y, mousePos.x)* Mathf.Rad2Deg;
			this.transform.rotation = Quaternion.Euler(new Vector3(0.0f, 0.0f, angle));

			Debug.DrawRay(transform.position, transform.right, Color.cyan);

			if(Input.GetMouseButtonDown(0)){
				temp = mousePos - transform.position;
                temp = Vector3.ClampMagnitude(temp, maxMouseDist);
				temp = 25.0f*temp/maxMouseDist;
	
				bullet = Instantiate(bulletPrefab, transform.position, transform.rotation) as GameObject;
				bullet.GetComponent<Rigidbody>().AddForce(temp + player.GetComponent<Rigidbody>().velocity, ForceMode.Impulse );
				Destroy(bullet, 2.5f);
			}
		} else {

			cPlayerInput = new Vector3(Input.GetAxis("Player1RightStickX"), Input.GetAxis("Player1RightStickY"), 0.0f);

			//bullet.transform.position = transform.position + cPlayerInput;

			angle = Mathf.Atan2(Input.GetAxis("Player1RightStickX"), Input.GetAxis("Player1RightStickY")) * Mathf.Rad2Deg;

			transform.rotation = Quaternion.Euler(0.0f, 0.0f, angle);

			Debug.DrawRay(transform.position, transform.right, Color.cyan);

			if(Input.GetButtonDown("Player1X")){
				//temp = cPlayerInput;
				//temp = temp * Vector3.Distance(transform.position, cPlayerInput);
                temp = 25.0f * cPlayerInput;
				
				bullet = Instantiate(bulletPrefab, transform.position, transform.rotation) as GameObject;
				bullet.GetComponent<Rigidbody>().AddForce(temp + player.GetComponent<Rigidbody>().velocity, ForceMode.Impulse );
                bullet.layer = 10;
				Destroy(bullet, 2.5f);
			}

		}

	}

}
