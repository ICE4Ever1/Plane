using UnityEngine;

public class RectSpawner : Spawner
{
    public Vector2 Size;
    public Vector2 Offset;

    public override void OnLoad(GameObject go)
    {
        base.OnLoad(go);
        var pos = GetARandomPoint();
        go.transform.position = pos;
    }

    public Vector2 GetARandomPoint()
    {
        Vector2 center = transform.position + (Vector3)Offset;
        Vector2 result = center;
        result.x = Random.Range(center.x - Size.x / 2f, center.x + Size.x / 2f);
        result.y = Random.Range(center.y - Size.y / 2f, center.y + Size.y / 2f);
        return result;

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position + (Vector3)Offset,
            Size);
    }
}
