using System.Collections.Generic;
using System.Linq;
using Behaviours.FlockBehaviours;
using UnityEngine;
using UnityEngine.UIElements;

namespace Assets.Scripts.Creatures.Components
{
    /// <summary>
    ///     Class responsible for controlling the movement of the flock
    /// </summary>
    public class FlockController : MonoBehaviour
    {
        private List<FlockAgent> agents;

        public FlockBehaviour[] behaviors;

        public float[] weights;

        private void Start()
        {
            var boidColliders = Physics2D.OverlapCircleAll(transform.position, 10f);
            agents = boidColliders.Select(o => o.GetComponent<FlockAgent>()).ToList();
        }
        
        // Update is called once per frame
        private void Update()
        {
            Start();
            foreach (var agent in agents)
            {
                var context = agent.GetNearbyObjects();
                var move = ChooseBehaviour(agent, context);
                agent.Move(move);
            }
        }

        private Vector2 ChooseBehaviour(FlockAgent agent, List<Transform> surrounding)
        {
            //set up move
            var move = Vector2.zero;

            //iterate through behaviors
            for (var i = 0; i < behaviors.Length; i++)
            {
                var partialMove = behaviors[i].CalculateMove(agent, surrounding) * weights[i];

                if (partialMove != Vector2.zero)
                {
                    if (partialMove.sqrMagnitude > weights[i] * weights[i])
                    {
                        partialMove.Normalize();
                        partialMove *= weights[i];
                    }

                    move += partialMove;
                }
            }

            return move;
        }
    }
}