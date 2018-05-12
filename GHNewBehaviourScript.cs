using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;


public class NewBehaviourScript : MonoBehaviour {
	// public RootObject rootObject
	//  = new RootObject();
	// public CurrentObservation current_observation;
	public Animator ani; 
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

//the API
private const string URL = "http://api.wunderground.com/api/d5a02b585b94a99a/conditions/q/New_Zealand/Wellington.json";


	void Start () {
		Debug.Log("Here I am ");
		StartCoroutine(LoadWind());
//Once the wind data has been acquired from the API, we can tie the speed and direction to our character's animated actions
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
  //the character asset in unity needs to have an Animator, which sets Triggers for each animation. In the Animator, Triggers sit on the arrow that leads to your desired animation, and are listed under Conditions. We call the triggers above. 
	}

	IEnumerator LoadWind() {
	//JSON parsing didn't work, but we can import the API data as a string using www.text. We then need RegEx to get the desired piece of info from the stringified JSON
		var windDirRegex = "(\"wind_dir\":\".*?\\w??\\W)";
		var windKphRegex = "(\"wind_kph\":\\d+.\\d)";
		var dirRegex = "([NESW])";
		var kphRegex = "(\\d+(?:\\D\\d))"; 

	//www lets us get data from an API, www.text stringifies it
		WWW www = new WWW(URL);
		yield return www;
		// current_observation = JsonUtility.FromJson<CurrentObservation>(www.text);
		weatherString = www.text;

	//we need the direction of the wind, which can be 1-3 letters. Regex.Match returns an object which we need to turn into a string so the If Contains statement can read it.
		match = Regex.Match(weatherString, windDirRegex);
		dir_obj = match;
		wind_dir = dir_obj.ToString();
		match = Regex.Match(wind_dir, dirRegex);
		dirLettersObj = match;
		dirLettersString = dirLettersObj.ToString();

	//same again but we need to turn the number values into an integer. Numbers can be between 1-3 values, followed by a decimal and another value. The int.Parse won't accept decimals in an integer so we need to get the number to the left of the decimal place.
		match = Regex.Match(weatherString, windKphRegex);
		kph_obj = match;
		wind_kph = kph_obj.ToString();
		match = Regex.Match(wind_kph, kphRegex);
		kphNumsObj = match;
		kphNumsString = kphNumsObj.ToString();
		kphSplit = kphNumsString.Split('.');
		kphNumsInt = int.Parse(kphSplit[0]);
	//the integer and string are passed to the If statement, triggering animated actions.
	}
}

// Update is called once per frame    
//     void Update() {

// }
