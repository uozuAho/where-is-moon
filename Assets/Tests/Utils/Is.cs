using UnityEngine;

namespace Tests.Utils
{
    internal class Is : NUnit.Framework.Is
    {
        public static VectorConstraint CloseTo(Vector3 expected)
        {
            return new VectorConstraint(expected, 0.05f);
        }
    }
}
