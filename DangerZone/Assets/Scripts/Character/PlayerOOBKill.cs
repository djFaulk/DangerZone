using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOOBKill : MonoBehaviour
{

    [SerializeField] private GameObject maincamera;
    private Transform leftBox;
    private Transform rightBox;
    private float leftBound;
    private float rightBound;

    private void Start() {
        maincamera = GameObject.Find("Main Camera");
        leftBox = maincamera.transform.Find("LeftDespawn");
        rightBox = maincamera.transform.Find("RightDespawn");
    }

    // Update is called once per frame
    void Update()
    {
        leftBound = leftBox.position.x - 0.5f;
        rightBound = rightBox.position.x + 0.5f;

        if(transform.position.x < leftBound || transform.position.x > rightBound)
        {
            GetComponent<PlayerDeath> ().OnDeath ();
        }
    }
}
