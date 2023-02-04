using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public static partial class Extensions
{
    /// <summary>
    /// Gets a vector2 from a given direction. 
    /// </summary>
    /// <param name="movementDirection"></param>
    /// <returns></returns>
    public static Vector2 VectorFromDirection(this MovementDirection movementDirection)
    {
        switch (movementDirection)
        {
            case MovementDirection.Left:
                return Vector2.left;
            case MovementDirection.Right:
                return Vector2.right;
            case MovementDirection.Up:
                return Vector2.up;
            case MovementDirection.Down:
                return Vector2.down;

            case MovementDirection.None:
            default:
                return Vector2.zero;
        }
    }
}

