
using UnityEngine;

public static class CompareVector3
{
    public static bool Compare(Vector3 a, Vector3 b)
    {
        return a.x == b.x && a.y == b.y && a.z == b.z;
    }
}