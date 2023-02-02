using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GGJ.Core
{
    [System.Serializable]
    public class Level
    {
        public Node[] nodes;
    }

    public class LevelManager : MonoBehaviour
    {
        public Transform player;

        public Level[] layers;

        private void Start()
        {
            InitPlayerPosition();
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                var node = RaycastNode2D();
                if (node == null)
                    return;

                var levelIndex = FindLevelIndex(node);
                Debug.Assert(levelIndex != LevelIndex.Invalid);

                if (State.VisitedLevels.Contains(levelIndex) || State.CurrentLayer != levelIndex.LayerIndex)
                    return;

                player.position = node.transform.position;
                State.VisitLevel(levelIndex);
            }
        }

        private Node RaycastNode2D()
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);
            if (hit.collider == null)
            {
                return null;
            }

            var node = hit.collider.GetComponent<Node>();
            return node;
        }

        // TODO: Rewrite this
        private LevelIndex FindLevelIndex(Node node)
        {
            for (int i = 0; i < layers.Length; i++)
            {
                var layer = layers[i];
                for (int j = 0; j < layer.nodes.Length; j++)
                {
                    if (layer.nodes[j] == node)
                    {
                        return new LevelIndex { LayerIndex = i, NodeIndex = j };
                    }
                }
            }

            return LevelIndex.Invalid;
        }

        private void InitPlayerPosition()
        {
            if (State.CurrentLevelIndex == LevelIndex.Invalid)
                return;

            var level = layers[State.CurrentLevelIndex.LayerIndex];
            var node = level.nodes[State.CurrentLevelIndex.NodeIndex];
            player.position = node.transform.position;
        }
    }
}