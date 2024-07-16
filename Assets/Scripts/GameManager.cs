
using Utils;

public class GameManager:MonoSingleton<GameManager>
{
    public int PlaneIndex;
    public override void OnAwake()
    {
        base.OnAwake();
        InputManager.Instance.Init();
    }

    public void LoadGameScene()
    {
        SceneManager.Instance.Load("Level1");
    }

    public void LoadGameStart()
    {
        BulletPool.Instance.ReleaseAll();
        EffectPool.Instance.ReleaseAll();
        SceneManager.Instance.Load("Start");
    }
}
