
using System;
using Unity.Mathematics;
using UnityEngine;

public class OneLineWeapon:Weapon
{
    public Vector2 Offset = Vector2.up;
    public Vector2 Direction = Vector2.up;
    public string Tag;
    public override void Attack()
    {
        var bullet = BulletPool.Instance.Claim();
        bullet.TargetTag = Tag;
        bullet.transform.position = transform.position + (Vector3)Offset;
        
        var angle = -90 + Mathf.Rad2Deg * Mathf.Asin(Direction.normalized.y);
        bullet.transform.rotation = Quaternion.Euler(0,0,angle);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color=Color.blue;
        Gizmos.DrawIcon(transform.position + (Vector3)Offset,"ShootPoint");
        Gizmos.DrawRay(transform.position, Direction);
    }
}
