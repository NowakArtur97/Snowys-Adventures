using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _moveVelocity = 8.0f;
    public float MoveVelocity
    {
        get => _moveVelocity;
        private set => _moveVelocity = value;
    }
    [SerializeField] private float _jumpVelocity = 10.0f;
    public float JumpVelocity
    {
        get => _jumpVelocity;
        private set => _jumpVelocity = value;
    }

    public CoreContainer CoreContainer { get; internal set; }

    public FiniteStateMachine StateMachine { get; internal set; }

    public IdleState IdleState { get; private set; }
    public MoveState MoveState { get; private set; }
    public JumpState JumpState { get; private set; }
    public InAirState InAirState { get; private set; }
    public LandState LandState { get; private set; }
    public PlugInState PlugInState { get; private set; }
    public PlugOutState PlugOutState { get; private set; }
    public ScaredState ScaredState { get; private set; }

    public bool IsScared { get; private set; }

    private void Awake()
    {
        CoreContainer = GetComponentInChildren<CoreContainer>();

        IdleState = new IdleState(this, new List<string>() { "idle1", "idle2", "idle3", "idle4" });
        MoveState = new MoveState(this, new List<string>() { "move" });

        JumpState = new JumpState(this, new List<string>() { "inAir" });
        InAirState = new InAirState(this, new List<string>() { "inAir" });
        LandState = new LandState(this, new List<string>() { "land" });

        PlugInState = new PlugInState(this, new List<string>() { "plugIn" });
        PlugOutState = new PlugOutState(this, new List<string>() { "plugOut" });

        ScaredState = new ScaredState(this, new List<string>() { "scared" });
    }

    private void Start() => StateMachine = new FiniteStateMachine(IdleState);

    private void Update() => StateMachine.CurrentState.LogicUpdate();

    private void FixedUpdate() => StateMachine.CurrentState.PhysicsUpdate();

    public void Scare() => IsScared = true;
}
