using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class WaterTrigger : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem rippleEffect;
    private void OnTriggerEnter(Collider other)
    {
        PlayerConnector player;
        if (other.TryGetComponent(out player))
        {
            rippleEffect.transform.position = other.ClosestPoint(transform.position);
            rippleEffect.Play();
        }
    }
}
