using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PlayerConnector : MonoBehaviour
{
    [SerializeField] private PlayerController controller;
    [SerializeField] private PlayerGraphics graphics;

    public PlayerController GetController => controller;
    private void Initialize()
    {
        controller.SetConnector(this);
        graphics.SetConnector(this);
    }

    private void Awake()
    {
        Initialize();
    }


}
