using System;
using Ash.Runtime.Core;
using UnityEngine;

namespace Ash.Runtime.Game
{
    public class ScreenBoundary : MonoBehaviour, IBoundary<Vector2>
    {
        [SerializeField]
        private float m_Margin;
        
        private Camera m_Camera;

        public Vector2 Min { get; set; }
        public Vector2 Max { get; set; }

        private void Awake()
        {
            m_Camera = Camera.main;
        }

        private void Start()
        {
            CalculateBoundary();
        }

        private void LateUpdate()
        {
            CalculateBoundary();
        }

        private void CalculateBoundary()
        {
            Min = GetTopLeft(m_Camera);
            Max = GetTopRight(m_Camera);
        }

        public Vector2 GetTopLeft(Camera camera)
        {
            Vector2 topLeftCorner = Vector2.zero;
            Vector2 topLeftWorld = camera.ViewportToWorldPoint(topLeftCorner);
            Vector2 margin = new Vector2(m_Margin, m_Margin);
           
            topLeftWorld -= margin;
            return topLeftWorld;
        }
        
        public Vector2 GetTopRight(Camera camera)
        {
            Vector2 topRightCorner = Vector2.one;
            Vector2 topRightWorld = camera.ViewportToWorldPoint(topRightCorner); 
            Vector2 margin = new Vector2(m_Margin, m_Margin);
            topRightWorld += margin;
            
            return topRightWorld;
        }
    }
}
