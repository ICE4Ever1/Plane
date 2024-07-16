
using UnityEngine;

public class ThreeLineWeapon:Weapon
{
    public Vector2 Offset = Vector2.up;
    public Vector2 Direction = Vector2.up;
    public float Space = 0.5f;
    public string Tag;
    public override void Attack()
    {
        var bullet = CreateOne();
        bullet.transform.position = transform.position + (Vector3)Offset;
        
        bullet = CreateOne();
        bullet.transform.position = transform.position + (Vector3)Offset+new Vector3(-Space,0,0);
        
        bullet = CreateOne();
        bullet.transform.position = transform.position + (Vector3)Offset+new Vector3(Space,0,0);
    }

    private Bullet CreateOne()
    {
        var bullet = BulletPool.Instance.Claim();
        bullet.TargetTag = Tag;

        var angle = -90 + Mathf.Rad2Deg * Mathf.Asin(Direction.normalized.y);
        bullet.transform.rotation = Quaternion.Euler(0,0,angle);
        return bullet;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color=Color.blue;
        Gizmos.DrawIcon(transform.position + (Vector3)Offset+new Vector3(-Space,0,0),"ShootPoint");
        Gizmos.DrawIcon(transform.position + (Vector3)Offset,"ShootPoint");
        Gizmos.DrawIcon(transform.position + (Vector3)Offset+new Vector3(Space,0,0),"ShootPoint");
        Gizmos.DrawRay(transform.position, Direction);
    }
}
