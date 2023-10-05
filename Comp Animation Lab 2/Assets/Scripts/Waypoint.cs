using Cinemachine.Utility;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Waypoint : MonoBehaviour
{
    [SerializeField]
    public Vector3 pos;
    public void SetPos(Vector3 newPos)
    {
        pos = newPos;
    }
    public Vector3 GetPos()
    {
        return pos;
    }
    public Waypoint()
    {
        pos = Vector3.zero;
    }
}
