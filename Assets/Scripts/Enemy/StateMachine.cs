using UnityEngine;

public class StateMachine : MonoBehaviour
{
    public BaseState activeState;

    public void Initialize() => ChangeState(new PatrolState());
    private void Update() => activeState?.Perform();

    public void ChangeState(BaseState newState)
    {
        activeState?.Exit();

        activeState = newState;

        if (activeState == null) 
            return;

        activeState.StateMachine = this;
        activeState.Enemy = GetComponent<Enemy>();
        activeState.Enter();
    }
}
