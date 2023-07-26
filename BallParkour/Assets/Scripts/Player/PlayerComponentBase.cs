using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerConnector))]
public class PlayerComponentBase : MonoBehaviour
{
    private PlayerConnector main;

    /// <summary>
    /// Unity Start method
    /// </summary>
    public void SetConnector(PlayerConnector newConnector) => main = newConnector;
}

