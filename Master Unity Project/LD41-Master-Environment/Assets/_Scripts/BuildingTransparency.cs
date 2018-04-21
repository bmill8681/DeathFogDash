using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingTransparency : MonoBehaviour {

    public Material building_mat;
    public Material building_tp_mat;
    Material instance_material;

    Color color;

    float alpha = 1;
    Coroutine isFading = null;
    MeshRenderer mr;

    public void pingFade()
    {
        if (isFading == null)
        {
            mr = GetComponent<MeshRenderer>();
            mr.material = building_tp_mat;
            instance_material = mr.material;
            color = instance_material.color;
            isFading = StartCoroutine(Fade());
        }
        alpha -= .03f;
    }


    IEnumerator Fade()
    {
        while (alpha < 1)
        {
            color.a = alpha;
            instance_material.SetColor("_Color", color);
            alpha = Mathf.Clamp(alpha + .01f, 0.4f, 1f);
            yield return null;
            
        }
        mr.material = building_mat;
        isFading = null;
    }

}
