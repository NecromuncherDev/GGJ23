using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GGJ.Core
{

    public class Node : MonoBehaviour
    {
        public Node[] nextNodes;
        public string sceneName;

        [Header("Edges")]
        public SpriteRenderer edge;
        public Sprite LitUp;
        public Sprite Dimmed;

        void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(transform.position, 0.15f);
            Gizmos.color = Color.white;

            // Draw arrow to next nodes
            foreach (var nextNode in nextNodes)
            {
                if (nextNode == null)
                    continue;

                Gizmos.DrawLine(transform.position, nextNode.transform.position);

                // Draw arrow head
                var dir = nextNode.transform.position - transform.position;
                var rot = Quaternion.LookRotation(dir, Vector3.forward);
                Gizmos.DrawRay(nextNode.transform.position, (rot * Vector3.left - dir.normalized) * 0.15f);
                Gizmos.DrawRay(nextNode.transform.position, (rot * Vector3.right - dir.normalized) * 0.15f);
            }
        }
    }

}