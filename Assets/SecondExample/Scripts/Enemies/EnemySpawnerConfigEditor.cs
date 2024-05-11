using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(EnemySpawnerConfig))]
public class EnemySpawnerConfigEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        EnemySpawnerConfig spawnerConfig = (EnemySpawnerConfig)target;

        if (GUILayout.Button("Collect"))
        {
            List<Vector3> points = new List<Vector3>();

            foreach (var point in FindObjectsOfType<EnemySpawnPoint>())
            {
                points.Add(point.Position);
            }

            spawnerConfig.EnemySpawnPoints = points;
        }

        EditorUtility.SetDirty(target);
    }
}
