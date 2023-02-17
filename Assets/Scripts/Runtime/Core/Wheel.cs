using System;
using JetBrains.Annotations;

namespace Ash.Runtime.Core
{
    /// <summary>
    /// Applies rotation to the entity 
    /// </summary>
    public class Wheel
    {
        private readonly ITransform m_Transform;

        public Wheel([NotNull] ITransform transform)
        {
            m_Transform = transform ?? throw new ArgumentNullException(nameof(transform));
        }
        
        public void Rotate(float degree)
        {
            m_Transform.EulerAngle += degree;
        }
        
    }
}


