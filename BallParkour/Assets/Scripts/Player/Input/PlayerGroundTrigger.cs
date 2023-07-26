using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundTrigger : MonoBehaviour
{
    public bool Grounded { get { return grounded; } }

    private bool grounded;
    [SerializeField]
    private int colliders = 0;

    private void OnTriggerEnter(Collider other)
    {
        print("Grounded;");
        if (other.tag != "Player")
            colliders++;
        if (colliders <= 0)
            grounded = false;
        else
            grounded = true;
    }
    private void OnTriggerExit(Collider other)
    {
        print("Non Grounded;");
        if (other.tag != "Player")
            colliders--;
        if (colliders <= 0)
            grounded = false;
        else
            grounded = true;
    }
}
