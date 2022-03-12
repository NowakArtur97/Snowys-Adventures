using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _moveVelocity;
    public float MoveVelocity
    {
        get => _moveVelocity;
        private set => _moveVelocity = value;
    }

    public CoreContainer CoreContainer { get; internal set; }

    public FiniteStateMachine StateMachine { get; internal set; }

    public IdleState IdleState { get; private set; }
    public MoveState MoveState { get; private set; }

    private void Awake()
    {
        CoreContainer = GetComponentInChildren<CoreContainer>();

        IdleState = new IdleState(this, new List<string>() { "idle1", "idle2", "idle3", "idle4" });
        MoveState = new MoveState(this, new List<string>() { "move" });
    }

    private void Start() => StateMachine = new FiniteStateMachine(IdleState);

    private void Update() => StateMachine.CurrentState.LogicUpdate();

    private void FixedUpdate() => StateMachine.CurrentState.PhysicsUpdate();
}
