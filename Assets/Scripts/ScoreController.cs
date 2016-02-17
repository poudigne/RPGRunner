using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour {

    public UnityEngine.UI.Text scoreValueText;
    public GameObject player;

	// Use this for initialization
	void Start () {
        scoreValueText.text = "0";
	}
	
	// Update is called once per frame
	void Update () {
        scoreValueText.text = Mathf.RoundToInt(player.transform.position.x).ToString();
	}
}
