using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class TeleportTrigger : MonoBehaviour
{
    [SerializeField] private Transform teleportPostion;

    private void OnTriggerEnter(Collider other)
    {
        PlayerConnector player;
        if(other.TryGetComponent(out player))
        {
            player.GetController.Teleport(teleportPostion.position);
        }
    }

#if UNITY_EDITOR
    private BoxCollider collider;
    private void OnValidate()
    {
        if (!collider) collider = GetComponent<BoxCollider>();

        collider.isTrigger = true;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(0, 1, 0, 0.5f);
        Gizmos.DrawCube(transform.position, collider.size);
    }
    private void OnDrawGizmos()
    {
        
    }

#endif
}
