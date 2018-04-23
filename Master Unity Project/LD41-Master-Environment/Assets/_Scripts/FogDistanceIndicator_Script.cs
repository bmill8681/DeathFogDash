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


    private void Start()
    {
        player = GameController.instance.player.gameObject;
        fog = Proceed.instance.deathray.gameObject;
        fogUI.rectTransform.localPosition = new Vector3(0f, 0f, 0f);
    }

    void LateUpdate () {
        float pos = getDistance();
        fogUI.rectTransform.localPosition = new Vector3(-5.0f, -pos + 100.0f, 0.0f);
    }

    private float getDistance()
    {
        float fogPos = fog.transform.position.x;
        float pPos = player.transform.position.x;
        float spread = pPos - fogPos;
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
