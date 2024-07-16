using Utils;

public class InputManager : Singleton<InputManager>
{
    private InputActions m_Actions;

    public InputManager()
    {
        m_Actions = new();
        m_Actions.Move.Enable();
    }
    public void Init()
    {

    }

    public InputActions.MoveActions Move => m_Actions.Move;
}
