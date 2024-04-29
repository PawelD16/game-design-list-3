public abstract class BaseState
{
    public Enemy Enemy { get; set; }

    public StateMachine StateMachine { get; set; }

    public abstract void Enter();
    public abstract void Perform();
    public abstract void Exit();
}
