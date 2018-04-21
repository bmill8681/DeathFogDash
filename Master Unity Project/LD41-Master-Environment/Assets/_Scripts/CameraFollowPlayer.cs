using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraFollowPlayer : MonoBehaviour {



    public Transform player;
    float target_rotate = 0f;
    float current_rotate = 0f;
    private bool isRotating = false;
    public Text debug_text;
    
	void Update () {
        if (Input.GetKeyDown("left"))
            target_rotate -= 90f;
        else if (Input.GetKeyDown("right"))
            target_rotate += 90f;

        if(target_rotate != current_rotate)
        {
            if(target_rotate > current_rotate)
            {
                if(target_rotate - current_rotate > 5) { transform.RotateAround(player.position, Vector3.up, 5f); current_rotate += 5; }
                else { transform.RotateAround(player.position, Vector3.up, target_rotate - current_rotate); current_rotate += target_rotate - current_rotate; }
            }
            else if (target_rotate < current_rotate)
            {
                if (current_rotate - target_rotate > 5) { transform.RotateAround(player.position, Vector3.up, -5f); current_rotate -= 5; }
                else { transform.RotateAround(player.position, Vector3.up, -(current_rotate - target_rotate)); current_rotate -= current_rotate - target_rotate; }
            }

            transform.LookAt(player, Vector3.up);
            debug_text.text = "Target: " + target_rotate + " Current: " + current_rotate;
        }




    }




}
