using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AstroEnd.Core.AI
{
    public class AreaConstraint : MonoBehaviour
    {
		public Color sphereColor;
        public float areaOffset = 10;
        void OnDrawGizmosSelected()
        {
            Gizmos.color = sphereColor;
            Gizmos.DrawWireSphere(transform.position, areaOffset);
        }
    }

}
