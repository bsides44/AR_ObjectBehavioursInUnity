using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class windscript : MonoBehaviour {
	Vector3 myVector;
	// Use this for initialization
	void Start () {
		myVector = new Vector3(0.0f, 0.0f, 100.0f);
		transform.GetComponent<Cloth>().externalAcceleration = myVector;
		// -Physics.gravity / 2;
	}
	
	// Update is called once per frame
// 	void Update () {
		
// 	}
}
