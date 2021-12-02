using UnityEngine;
using System.Collections;

public class CatchingTest : MonoBehaviour {

	public Vector3 throwPos;
	Vector3 temp;
	//Vector3 

	public GameObject bulletPrefab;
	GameObject cCursor;
	public GameObject bullet;
	GameObject player;
	public GameObject pHand;
	public Vector3 handTransform;

	private GameObject caughtItem;

	// Use this for initialization
	void Start () {
		cCursor = Instantiate (bulletPrefab, transform.position, transform.rotation) as GameObject;
		cCursor.transform.GetComponent<Collider>().enabled = false;
		player = GameObject.Find ("P1");
	
	}
	
	// Update is called once per frame
	void Update () {

		throwPos = transform.position + transform.forward * 2.0f + Vector3.up;
		cCursor.transform.position = throwPos;
		if (caughtItem != null) {

						caughtItem.transform.position = pHand.transform.position;
				}
		if (Input.GetKeyDown (KeyCode.E)) {
			
			Debug.Log("E is pressed");
			
			temp = transform.position - cCursor.transform.position;
			
			bullet = Instantiate(bulletPrefab, cCursor.transform.position, cCursor.transform.rotation) as GameObject;
			bullet.GetComponent<Rigidbody>().AddForce(temp * 2.0f, ForceMode.Impulse);
			
			
		}


		if (Input.GetKey (KeyCode.R)) {
			if(bullet != null){
			Destroy(bullet);
				}
			}

		if (Input.GetKeyDown (KeyCode.F)) {

			foreach(Collider col in Physics.OverlapSphere(transform.position+ transform.forward/2.0f, 0.75f)){
				if(col.gameObject.tag == "Item"){
					ItemCatch(col.gameObject);
				}
			}
		}

	
	}

	void fixedUpdate(){
	

	}

	void ItemCatch(GameObject item){
		caughtItem = item;
		item.GetComponent<Rigidbody>().velocity = Vector3.zero;
		item.transform.parent = pHand.transform;
		item.transform.position = pHand.transform.position;
		item.GetComponent<Rigidbody>().useGravity = false;
		item.transform.localPosition = Vector3.zero;
	}
}
