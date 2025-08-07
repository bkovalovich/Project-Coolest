using UnityEngine;

public static class VectorHelper
{
    public static Vector2 Mult(Vector2 v, float f) {
        return new Vector2(v.x * f, v.y * f);
    }
}
