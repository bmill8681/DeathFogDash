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

    List<GameObject> current_buildings;
    RaycastHit rch;
    Ray tocam;
    public LayerMask building_mask;

    private void Start()
    {
        transform.parent = new GameObject("PlayerFollower-CamerHolder").transform;
        transform.localPosition = new Vector3(50, 65, -50);
        transform.LookAt(player, Vector3.up);
        target_rotate = 90f;
        current_buildings = new List<GameObject>();
    }



    void Update () {

        transform.parent.position = player.position;
        if (Input.GetKeyDown("left"))
            target_rotate -= 90f;
        else if (Input.GetKeyDown("right"))
            target_rotate += 90f;

        if(target_rotate != current_rotate)
        {
            if(target_rotate > current_rotate)
            {
                if(target_rotate - current_rotate > 5) { transform.parent.RotateAround(player.position, Vector3.up, 5f); current_rotate += 5; }
                else { transform.parent.RotateAround(player.position, Vector3.up, target_rotate - current_rotate); current_rotate += target_rotate - current_rotate; }
            }
            else if (target_rotate < current_rotate)
            {
                if (current_rotate - target_rotate > 5) { transform.parent.RotateAround(player.position, Vector3.up, -5f); current_rotate -= 5; }
                else { transform.parent.RotateAround(player.position, Vector3.up, -(current_rotate - target_rotate)); current_rotate -= current_rotate - target_rotate; }
            }

            transform.LookAt(player, Vector3.up);
            if(debug_text != null)debug_text.text = "Target: " + target_rotate + " Current: " + current_rotate;
        }

        tocam = new Ray(player.position,transform.position - player.position);
        if (Physics.Raycast(tocam,out rch,150f,building_mask))
        {
            rch.collider.gameObject.BroadcastMessage("pingFade");

        }




    }




}
