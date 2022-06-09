using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEditor;
using UnityEngine;

public class CustomShortcuts : MonoBehaviour
{
    [MenuItem("Shortcuts/Toggle Lock Inspector &q")]
    static void LockUnlockInspector()
    {
        ActiveEditorTracker.sharedTracker.isLocked = !ActiveEditorTracker.sharedTracker.isLocked;
        if (ActiveEditorTracker.sharedTracker.activeEditors.Length != 0)
        {
            ActiveEditorTracker.sharedTracker.activeEditors[0].Repaint();
        }
    }

    [MenuItem("Shortcuts/Clear Logs &x")]
    static void ClearLogs()
    {
        var assembly = Assembly.GetAssembly(typeof(UnityEditor.Editor));
        var type = assembly.GetType("UnityEditor.LogEntries");
        var method = type.GetMethod("Clear");
        method.Invoke(new object(), null);
    }
}

