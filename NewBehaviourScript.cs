using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    // Rigidbody rb = GetComponent<Rigidbody>(); <- import component inyo rb variable
	// Barbarian.animation.Mean

public class NewBehaviourScript : MonoBehaviour {
	//this is a string variable defined in unity in the inspector pane. public means you can see it in the unity inspector

	public Animator ani;
	public string myName;
	// Use this for initialization, ie componentDidMount. Debug.Log is console.log (Window > console)
	void Start () {
		Debug.Log("Here I am ");
		ani = GetComponent<Animator>();
	}
	    public float distancePerSecond;


	// Update is called once per frame    
    void Update() {
		if (Input.GetKeyDown(KeyCode.A)) {
  	ani.SetTrigger("RoundKick");
  }
  		if (Input.GetKeyDown(KeyCode.Q)) {
  	ani.SetTrigger("Mean");
  }
  		if (Input.GetKeyDown(KeyCode.Z)) {
  	ani.SetTrigger("Wink");
  }
  		if (Input.GetKeyDown(KeyCode.W)) {
  	ani.SetTrigger("Run");
  }
        // ani.Play("RoundKick");
    }
}

//  var animator:Animator;
 
//      function Start(){
//      animator=GetComponent(Animator);
//      }
//      function Update()
//      {
//              if (Input.GetKeyDown() {
//                      animator.Play("NAME OF ANIMATION");
//      }