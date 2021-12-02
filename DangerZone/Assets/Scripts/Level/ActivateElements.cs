using UnityEngine;
using System.Collections;

public class ActivateElements : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerStay(Collider col)
    {
        if (col.tag == "Elements")
        {
            col.GetComponent<ElementMove>().CameraActive();
           
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.tag == "Elements")
        {
            col.GetComponent<ElementMove>().CameraNotActive();
        }
    }
}
