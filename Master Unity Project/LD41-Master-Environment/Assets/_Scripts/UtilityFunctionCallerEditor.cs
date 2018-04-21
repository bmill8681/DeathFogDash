using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR 
using UnityEditor;

[CustomEditor(typeof(UtilityFunctionCaller))]
public class UtilityFunctionCallerEditor : Editor {

    public UtilityFunctionCaller myCaller;

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        myCaller = (UtilityFunctionCaller)target;
        if (myCaller.allow_actions && myCaller.things != null)
        {
            int L = myCaller.things.Length;

            for (int i = 0; i < L; i++)
            {
                if (myCaller.things[i].Name != "")
                {
                    if (GUILayout.Button(myCaller.things[i].Name))
                    {
                        myCaller.things[i].unity_event.Invoke();
                    }
                }
                else if (GUILayout.Button("Button " + i))
                {
                    myCaller.things[i].unity_event.Invoke();
                }
            }
        }
        
    }
}
#endif