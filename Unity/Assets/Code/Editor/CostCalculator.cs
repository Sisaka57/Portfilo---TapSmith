using UnityEngine;
using UnityEditor;
using UnityEngine.Math;

public class CostCalculator : EditorWindow
{
    private AnimationCurve ProgressCurve = AnimationCurve.Linear(0, 0, 1, 1);
    private Range TapRange = new Range(0, 1000);
    private Range LevelRange = new Range(0, 100);
    private int CurrentLevel;
    private int RequiredTaps;

    // Add menu named "My Window" to the Window menu
    [MenuItem("Window/Game/Cost Calculator")]
    static void Init()
    {
        // Get existing open window or if none, make a new one:
        CostCalculator window = (CostCalculator)EditorWindow.GetWindow(typeof(CostCalculator));
        window.Show();
    }

    void OnGUI()
    {
        GUILayout.Label("Cost Progress", EditorStyles.boldLabel);
        GUILayout.Label("Progress Curve");
        ProgressCurve = EditorGUILayout.CurveField(ProgressCurve, Color.blue, new Rect(0f, 0, 1, 1));
        GUILayout.Label("Level Ranges");
        GUILayout.BeginHorizontal();
        GUILayout.Label("Min");
        LevelRange.Min = EditorGUILayout.IntField(LevelRange.Min);
        GUILayout.Label("Max");
        LevelRange.Max = EditorGUILayout.IntField(LevelRange.Max);
        GUILayout.EndHorizontal();
        GUILayout.Label("Cost Ranges");
        GUILayout.BeginHorizontal();
        GUILayout.Label("Min");
        TapRange.Min = EditorGUILayout.IntField(TapRange.Min);
        GUILayout.Label("Max");
        TapRange.Max = EditorGUILayout.IntField(TapRange.Max);
        GUILayout.EndHorizontal();
        GUILayout.BeginHorizontal();
        GUILayout.Label("Current Level");
        CurrentLevel = EditorGUILayout.IntField(CurrentLevel);
        GUILayout.EndHorizontal();
        GUILayout.BeginHorizontal();
        GUILayout.Label("Required Cost for Level");
        RequiredTaps = Mathf.RoundToInt(ProgressCurve.Evaluate((float)Mathf.Clamp(CurrentLevel, LevelRange.Min, LevelRange.Max) / (float)LevelRange.Max) * TapRange.Max);
        GUILayout.Label(RequiredTaps.ToString());
        GUILayout.EndHorizontal();
    }
}