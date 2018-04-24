using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FogDistanceIndicator_Script : MonoBehaviour {

    GameObject player;
    GameObject fog;
    public Image fogUI;


    private float MAX_HEIGHT = 195.0f;
    private float MIN_HEIGHT = 0.0f;
    private float MAX_SPREAD = 175.0f;
    float actual_pos;

    private void Start()
    {
        player = GameController.instance.player.gameObject;
        fog = Proceed.instance.deathray.gameObject;
        fogUI.rectTransform.localPosition = new Vector3(0f, 0f, 0f);
        actual_pos = getDistance();
    }

    void LateUpdate () {
        float pos = getDistance();
        actual_pos = Mathf.Lerp(actual_pos, pos, 0.05f);
        //if(fogUI.rectTransform.localPosition.y >= -pos + 100) { }
        fogUI.rectTransform.localPosition = new Vector3(5.0f, -actual_pos + 100.0f, 0.0f);
    }

    private float getDistance()
    {
        float fogPos = fog.transform.position.x;
        float pPos = player.transform.position.x;
        float spread = pPos - fogPos;
        //spread = spread * 88f/175f;
        if (spread > MAX_SPREAD)
        {
            spread = MAX_SPREAD;
        }
        else if (spread < 0.0f)
        {
            spread = 0.0f;
        }
        return spread;
    }
}
