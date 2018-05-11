using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

    // Rigidbody rb = GetComponent<Rigidbody>(); <- import component inyo rb variable
	// Barbarian.animation.Mean

public class NewBehaviourScript : MonoBehaviour {
	//this is a string variable defined in unity in the inspector pane. public means you can see it in the unity inspector
// public string url = "http://api.wunderground.com/api/d5a02b585b94a99a/conditions/q/New_Zealand/Wellington.json";
	public Animator ani;
	public string myName;
	// Use this for initialization, ie componentDidMount. Debug.Log is console.log (Window > console)
	void Start () {
		Debug.Log("Here I am ");
		StartCoroutine(GetWeather());
	}
	IEnumerator GetWeather() {
		UnityWebRequest www = UnityWebRequest.Get("http://api.wunderground.com/api/d5a02b585b94a99a/conditions/q/New_Zealand/Wellington.json");
		// using (WWW www = new WWW(url))
        // {
            yield return www.SendWebRequest();
 
        if(www.isNetworkError || www.isHttpError) {
            Debug.Log(www.error);
        }
        else {
            // Show results as text
            Debug.Log(www.downloadHandler.text);
 
            // Or retrieve results as binary data
            byte[] results = www.downloadHandler.data;
        }
            // Renderer renderer = GetComponent<Renderer>();
            // renderer.material.mainTexture = www.texture;
        // }

		ani = GetComponent<Animator>();
	}


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