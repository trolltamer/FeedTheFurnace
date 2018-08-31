using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(EventScriptableObject))]
public class EventCustomEditor : Editor {
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        GUI.enabled = Application.isPlaying;

        EventScriptableObject e = target as EventScriptableObject;
        if (GUILayout.Button("Raise"))
        {
            e.Raise();
        }
    }
}
