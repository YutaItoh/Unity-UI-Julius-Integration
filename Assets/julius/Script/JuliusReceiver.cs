using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class JuliusReceiver : MonoBehaviour {

	//field
	private		GameObject 		juliusClient;
	private 	Julius_Client	juliusClientScript;

	private 	Button			button;
	private		Text			buttonText;

	public 		string			command;
	public 		string[] 		receivedText = new string[0];
	private		string			formattedCommand;


	IEnumerator PressButton (){
		button.interactable = false;
		yield return new WaitForSeconds(0.4f);
		button.interactable = true;
	}

	// Initialization, fetching JuliusServer and Button Components
	void Awake () {
		juliusClient = GameObject.FindGameObjectWithTag ("Julius");
		juliusClientScript = juliusClient.GetComponent<Julius_Client>();
		if(juliusClient != null){
			Debug.Log ("JuliusClientFound");
		}
		if(juliusClientScript != null)
			Debug.Log("JuliusScriptFetched" );


		button = gameObject.GetComponent<Button>();
		buttonText = gameObject.GetComponentInChildren<Text>();
		if(button != null && buttonText != null)
			Debug.Log ("Button Components Fetched");
	}

	private void matchData() {
		formattedCommand = formatReceived();
		if(formattedCommand.Equals(command)){
			//DoSomething()
			StartCoroutine("PressButton");
		}
	}


	string formatReceived() {
		string format = string.Empty;
		for(int i = 0; i < receivedText.Length; i++){
			format += receivedText[i];
			if(i < receivedText.Length-1)
				format += " ";
		}
			Debug.Log("ReceiferFormat:" + format);
			return format;
	}

	public void RecieveData(string[] array){
		this.receivedText = array;
		matchData();
	}
}
