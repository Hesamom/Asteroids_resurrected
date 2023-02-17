using Ash.Runtime.Core;
using NSubstitute;
using NUnit.Framework;
using UnityEngine;

namespace Ash.Tests
{
    public class EngineTest 
    {
        private Engine m_Engine;
        private IRigidBody m_RigidBody;

        [SetUp]
        public void Setup()
        {
            m_RigidBody = Substitute.For<IRigidBody>();
            m_Engine = new Engine(m_RigidBody);
        }
    
        [Test]
        public void WhenMove_IsCalled_ShouldAddForceByDirection()
        {
            const float force = 10;
        
            m_Engine.Direction = Vector2.right;
            m_Engine.Accelerate(force);

            m_RigidBody.Received().AddForce(Vector2.right * force);
        }
    }
}
