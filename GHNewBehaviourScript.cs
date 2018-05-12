using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;


public class NewBehaviourScript : MonoBehaviour {
	// public RootObject rootObject
	//  = new RootObject();
	public CurrentObservation current_observation;
	public Animator ani; 
	public string myName;
	public string weatherString;
	public Match match;
	public object wind_dir;
	public object wind_kph;

	

	private const string URL = "http://api.wunderground.com/api/d5a02b585b94a99a/conditions/q/New_Zealand/Wellington.json";

	void Start () {
		Debug.Log("Here I am ");
		StartCoroutine(LoadWind());
	}

// \"wind_dir\":\".*?"
	IEnumerator LoadWind() {
		var windDirRegex = "(\"wind_dir\":\".*?\\w\\b\\b\\W)";
		var windKphRegex = "(\"wind_kph\":\\.*?\\d.\\d)";
		WWW www = new WWW("http://api.wunderground.com/api/d5a02b585b94a99a/conditions/q/New_Zealand/Wellington.json");
		yield return www;
		// current_observation = JsonUtility.FromJson<CurrentObservation>(www.text);
		weatherString = www.text;
		Debug.Log(current_observation); 
		match = Regex.Match(weatherString, windDirRegex);
		wind_dir = match;
		Debug.Log(wind_dir);
		match = Regex.Match(weatherString, windKphRegex);
		wind_kph = match;
		Debug.Log(wind_kph);

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