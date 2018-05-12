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
	public object dir_obj;
	public string wind_kph;
	public object dirLettersObj;
	public string dirLettersString;
	public object kph_obj;
	public string wind_dir;
	public object kphNumsObj;
	public string kphNumsString;
	public int kphNumsInt;
	public string[] kphSplit;

	private const string URL = "http://api.wunderground.com/api/d5a02b585b94a99a/conditions/q/New_Zealand/Wellington.json";

	void Start () {
		Debug.Log("Here I am ");
		StartCoroutine(LoadWind());

		if (kphNumsInt> 10) {
  	ani.SetTrigger("Run");
  }
  		if (kphNumsInt< 10) {
  	ani.SetTrigger("Walk");
  }
  		if (dirLettersString.Contains("S")) {
  	ani.SetTrigger("Cry");
  }
  		if (dirLettersString.Contains("N")) {
  	ani.SetTrigger("Wink");
  }
	}

	IEnumerator LoadWind() {
		var windDirRegex = "(\"wind_dir\":\".*?\\w??\\W)";
		var windKphRegex = "(\"wind_kph\":\\d+.\\d)";
		var dirRegex = "([NESW])";
		var kphRegex = "(\\d+(?:\\D\\d))"; 

		WWW www = new WWW("http://api.wunderground.com/api/d5a02b585b94a99a/conditions/q/New_Zealand/Wellington.json");
		yield return www;
		// current_observation = JsonUtility.FromJson<CurrentObservation>(www.text);
		weatherString = www.text;

		match = Regex.Match(weatherString, windDirRegex);
		dir_obj = match;
		wind_dir = dir_obj.ToString();
		match = Regex.Match(wind_dir, dirRegex);
		dirLettersObj = match;
		dirLettersString = dirLettersObj.ToString();

		match = Regex.Match(weatherString, windKphRegex);
		kph_obj = match;
		wind_kph = kph_obj.ToString();
		match = Regex.Match(wind_kph, kphRegex);
		kphNumsObj = match;
		kphNumsString = kphNumsObj.ToString();
		kphSplit = kphNumsString.Split('.');
		kphNumsInt = int.Parse(kphSplit[0]);

	}
}

// Update is called once per frame    
//     void Update() {

// }
