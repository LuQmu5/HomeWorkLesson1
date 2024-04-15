using UnityEditor;
using UnityEngine;
using System.Linq;

[CustomEditor(typeof(Test))]
public class TestEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        Test test = (Test)target;

        if (GUILayout.Button("Collect Points"))
        {
            test.CollectPoints(GameObject.FindGameObjectsWithTag("MovementPoint").Select(p => p.transform).ToList());
        }

        EditorUtility.SetDirty(target);
    }
}