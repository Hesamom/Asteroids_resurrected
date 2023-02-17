using Ash.Runtime.Game;
using UnityEditor;
using UnityEngine;

namespace Ash.Editor
{
    [CustomEditor(typeof(ScreenBoundary), false)]
    public class ScreenBoundaryEditor : UnityEditor.Editor
    {
        private void OnSceneGUI()
        {
            ScreenBoundary t = (target as ScreenBoundary);
            if (t == null)
            {
                return;
            }
            
            Handles.color = Color.green;

            var camera = Camera.main;
            if (camera == null)
            {
                return;
            }

            var size = t.GetTopRight(Camera.main);
            Handles.DrawWireCube(t.transform.position, size * 2);
        }
    }
}
