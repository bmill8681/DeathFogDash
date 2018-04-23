using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class setScoreScript : MonoBehaviour {

    public TextMeshProUGUI tmPro;

    private void Awake()
    {
        tmPro = this.gameObject.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update () {
        int testScore = 123456789;
        string strTest = testScore.ToString();
        tmPro.text = strTest;
	}
}
