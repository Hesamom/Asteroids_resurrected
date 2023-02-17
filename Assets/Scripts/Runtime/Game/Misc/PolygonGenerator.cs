using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Ash.Runtime.Game
{
    public class PolygonGenerator : MonoBehaviour, IPolygonGenerator
    {
        [SerializeField]
        private int m_MinAngle,m_MaxAngle;
        
        [SerializeField]
        private float m_RadiusChange;
        

        public List<Vector3> GenerateVertices(float radius)
        {
            var vertices = new List<Vector3>();
            float angle = 360;
            
            while (true)
            {
                if (angle < 25)
                {
                    vertices.Add(vertices[0]);
                    break;
                }
                var r = radius * Random.Range(m_RadiusChange, 1);
                var radian = angle * Mathf.Deg2Rad;
                float x = Mathf.Cos(radian) * r;
                float y = Mathf.Sin(radian) * r;
                
                var pos = new Vector3(x, y, 0);
                vertices.Add(pos);
                angle -= Random.Range(m_MinAngle,m_MaxAngle);
            }

            return vertices;
        }
    }
}
