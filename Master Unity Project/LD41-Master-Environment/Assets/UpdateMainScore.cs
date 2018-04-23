using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpdateMainScore : MonoBehaviour {

    public TextMeshProUGUI scoreText;
	
	// Update is called once per frame
	void Update () {
        int score = GameController.instance.total_points;
        scoreText.text = score.ToString();
	}
}
