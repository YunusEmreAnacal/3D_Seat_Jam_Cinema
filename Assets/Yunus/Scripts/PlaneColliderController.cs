using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneColliderController : MonoBehaviour
{
     private bool isOccupied = false;

    public bool IsOccupied()
    {
        return isOccupied;
    }

    public void SetOccupied(bool value)
    {
        isOccupied = value;
    }
}