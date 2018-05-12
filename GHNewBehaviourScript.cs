using System.Collections;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour {
	public RootObject rootObject;
	 = new RootObject();
	public User user;
	public Animator ani; 
	public string myName;

	private const string URL = "http://api.wunderground.com/api/d5a02b585b94a99a/conditions/q/New_Zealand/Wellington.json";

	void Start () {
		Debug.Log("Here I am ");
		StartCoroutine(LoadWind());
	}

	IEnumerator LoadWind() {
		WWW www = new WWW("http://api.wunderground.com/api/d5a02b585b94a99a/conditions/q/New_Zealand/Wellington.json");
		yield return www;
		Debug.Log(www.text);
		user = JsonUtility.FromJson<User>(www.text);
		Debug.Log(user); 
	}

// set up unity debugger
//regex if desperate

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
    }
}