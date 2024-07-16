using System;
using UnityEngine;

public class Border:MonoBehaviour
{
    public Vector2 Size;
    public Vector2 Center => transform.position;
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(Center, Size);
    }

    public bool ClampMove(Border other,ref Vector2 move)
    {
        return ClampMove(other.Center, other.Size,ref move);
    }
    public bool ClampMove(Vector2 center,Vector2 size,ref Vector2 move)
    {
        bool res = true;
        int yExceed = 0, xExceed = 0;
        Vector2 borderHalfSize = Size / 2;
        Vector2 halfSize = size / 2;
        
        if (center.x + halfSize.x > Center.x + borderHalfSize.x)
        {
            res = false;
            xExceed = 1;
        }
        move.x = xExceed * move.x > 0 ? 0 : move.x;
        if (center.x - halfSize.x < Center.x - borderHalfSize.x)
        {
            res = false;
            xExceed = -1;
        }
        move.x = xExceed * move.x > 0 ? 0 : move.x;
        if (center.y + halfSize.y > Center.y + borderHalfSize.y)
        {
            res = false;
            yExceed = 1;
        }
        move.y = yExceed * move.y > 0 ? 0 : move.y;
        if (center.y - halfSize.y < Center.y - borderHalfSize.y)
        {
            res = false;
            yExceed = -1;
        }
        move.y = yExceed * move.y > 0 ? 0 : move.y;

        //move.x = xExceed * move.x > 0 ? 0 : move.x;
        //move.y = yExceed * move.y > 0 ? 0 : move.y;
        
        return res;
    }
}