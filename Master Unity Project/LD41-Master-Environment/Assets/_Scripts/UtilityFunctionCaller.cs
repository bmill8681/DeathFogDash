
using UnityEngine;
using UnityEngine.Events;

#if UNITY_EDITOR 


[ExecuteInEditMode]
public class UtilityFunctionCaller : MonoBehaviour
{
    [System.Serializable]
    public struct AuggoVent {
        public string Name;
        public UnityEvent unity_event;
    }
    [Header("Custom Events")]
    public AuggoVent[] things;
    [Space(20)]
    [Header("Buttons")]
    public bool allow_actions;


}
#endif
