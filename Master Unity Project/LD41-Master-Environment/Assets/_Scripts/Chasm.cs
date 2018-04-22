using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chasm : MonoBehaviour {


    Material instance_material;
    Color color;
    bool update_tile = false;
    float alpha = 1;
    Coroutine isFading = null;
    public MeshRenderer mr;
    Tile current_tile = Tile.question_mark;

    private void Awake()
    {

        instance_material = mr.material;
        color = instance_material.color;
    }

    public void pingFade(Tile tile)
    {

        if (isFading == null)
        {
            current_tile = tile;
            instance_material.SetTexture("_MainTex",WordHandler.instance.lettertile_textures[(int)current_tile]);
            isFading = StartCoroutine(Fade());
            alpha = .06f;
        }
        if (current_tile != tile) { update_tile = true; current_tile = tile; }

        alpha = Mathf.Clamp(alpha + .06f, 0f, .3f);
    }


    IEnumerator Fade()
    {
        Debug.Log("Fadein");
        while (alpha > 0)
        {
            if(update_tile)
            {
                alpha = 0f;
                instance_material.SetTexture("_MainTex", WordHandler.instance.lettertile_textures[(int)current_tile]);
                update_tile = false;
            }
            color.a = alpha;
            instance_material.SetColor("_Color", color);
            alpha = Mathf.Clamp(alpha - .04f, 0f, .3f);
            yield return null;
        }
        Debug.Log("Fadeout");

        isFading = null;
    }



}
