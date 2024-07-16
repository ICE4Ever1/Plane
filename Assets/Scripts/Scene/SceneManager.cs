
using Utils;

public class SceneManager:MonoSingleton<SceneManager>
{
    public Border GlobalBorder;

    public void Load(string name)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(name);
    }
}
