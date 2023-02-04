using static Platformer.Core.Simulation;
using Platformer.Mechanics;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class ActionDemage: MonoBehaviour
{
    [SerializeField] private Collider2D damageBy;
    float throttlingInterval = 2;
    float lastCollision = 0;
    GameObject player;


    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            player = null;
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        //Debug.Log($"Trigger enter {collider.gameObject.name}");
        if (damageBy.Equals(collider))
        {
            //Debug.Log("Demage enter");
            if (player != null && Time.time - lastCollision > throttlingInterval)
            {
                //Debug.Log("Do damage");
                var playerHealth = player.GetComponent<Health>();
                if (playerHealth != null)
                {
                    lastCollision = Time.time;
                    playerHealth.Decrement();
                }
            }
        }
        else
        {
            //Debug.Log("Player enter");
            if (collider.gameObject.tag == "Player")
            {
                player = collider.gameObject;
            }
        }
    }
}

