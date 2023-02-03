using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
            if (CheckWinGame())
            {
                State.WinGame();
                return;
            }

            if (CheckLoseGame())
            {
                State.LoseGame();
                return;
            }

            InitPlayerPosition();
            UpdateNodeColors();
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
                State.MarkVisited(levelIndex);

                SceneManager.LoadScene("WinLoseTemp");
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

        private void UpdateNodeColors()
        {
            for (int layerIndex = 0; layerIndex < layers.Length; layerIndex++)
            {
                var layer = layers[layerIndex];
                for (int nodeIndex = 0; nodeIndex < layer.nodes.Length; nodeIndex++)
                {
                    var node = layer.nodes[nodeIndex];
                    var spriteRenderer = node.GetComponent<SpriteRenderer>();
                    if (layerIndex != State.CurrentLayer)
                    {
                        spriteRenderer.color = Color.black;
                        continue;
                    }

                    var levelIndex = new LevelIndex { LayerIndex = layerIndex, NodeIndex = nodeIndex };
                    if (State.VisitedLevels.Contains(levelIndex))
                    {
                        spriteRenderer.color = Color.green;
                    }
                }
            }
        }

        private bool CheckWinGame()
        {
            return State.CurrentLayer >= layers.Length;
        }

        private bool CheckLoseGame()
        {
            int visitedNodes = 0;
            for (int nodeIndex = 0; nodeIndex < layers[State.CurrentLayer].nodes.Length; nodeIndex++)
            {
                var levelIndex = new LevelIndex { LayerIndex = State.CurrentLayer, NodeIndex = nodeIndex };
                if (State.VisitedLevels.Contains(levelIndex))
                {
                    visitedNodes++;
                }
            }

            return visitedNodes >= layers[State.CurrentLayer].nodes.Length;
        }
    }
}