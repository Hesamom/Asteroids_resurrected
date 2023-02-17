using Ash.Runtime.Core;
using NSubstitute;
using NUnit.Framework;

namespace Ash.Tests
{
    public class WheelTest 
    {
        private Wheel m_Wheel;
        private ITransform m_Rotation;

        [SetUp]
        public void Setup()
        {
            m_Rotation = Substitute.For<ITransform>();
            m_Wheel = new Wheel(m_Rotation);
        }
        
    
        [Test]
        public void WhenRotate_IsCalled_ShouldChangeRotation()
        {
            m_Rotation.EulerAngle = 0;
        
            m_Wheel.Rotate(-1);

            var expected = -1;
            var actual = m_Rotation.EulerAngle;
        
            Assert.AreEqual(expected, actual);
        }
    
    }
}
