using UnityEngine.Windows.Speech;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// Controller with specific keywords for user speech
/// </summary>
public class SpeechController : MonoBehaviour {
    //
    KeywordRecognizer keywordRecognizer;
    Dictionary<string, System.Action> keywords = new Dictionary<string, System.Action>();

    // Use this for initialization
    void Start () {
        keywords.Add("Wähle Feuerpfeil", () =>
        {
            // action to be performed when this keyword is spoken
            Debug.Log("User said: Wähle Feuerpfeil!");
        });
        keywords.Add("Wähle Eispfeil", () =>
        {
            // action to be performed when this keyword is spoken
            Debug.Log("User said: Wähle Eispfeil!");
        });
        keywords.Add("Wähle Explosionspfeil", () =>
        {
            // action to be performed when this keyword is spoken
            Debug.Log("User said: Wähle Explosionspfeil!");
        });
        keywords.Add("Upgrade Feuerpfeil", () =>
        {
            // action to be performed when this keyword is spoken
            Debug.Log("User said: Upgrade Feuerpfeil!");
        });
        keywords.Add("Upgrade Eispfeil", () =>
        {
            // action to be performed when this keyword is spoken
            Debug.Log("User said: Upgrade Eispfeil!");
        });
        keywords.Add("Upgrade Explosionspfeil", () =>
        {
            // action to be performed when this keyword is spoken
            Debug.Log("User said: Upgrade Explosionspfeil!");
        });
        keywords.Add("Wähle Ja", () =>
        {
            // action to be performed when this keyword is spoken
            Debug.Log("User said: Wähle Ja!");
        });
        keywords.Add("Wähle Nein", () =>
        {
            // action to be performed when this keyword is spoken
            Debug.Log("User said: Wähle Nein!");
        });
        keywordRecognizer = new KeywordRecognizer(keywords.Keys.ToArray());
        keywordRecognizer.OnPhraseRecognized += KeywordRecognizer_OnPhraseRecognized;
        keywordRecognizer.Start();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    /// <summary>
    /// Trigger action for speech input
    /// </summary>
    /// <param name="args"></param>
    private void KeywordRecognizer_OnPhraseRecognized(PhraseRecognizedEventArgs args)
    {
        System.Action keywordAction;
        // if the keyword recognized is in our dictionary, call that Action.
        if (keywords.TryGetValue(args.text, out keywordAction))
        {
            keywordAction.Invoke();
        }
    }
}