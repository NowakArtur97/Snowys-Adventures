using UnityEngine;

public class CoreContainer : MonoBehaviour
{
    private Animation _animation;

    public Animation Animation
    {
        get => GenericUtil<Animation>.GetOrDefault(_animation, transform.parent.name);
        private set => _animation = value;
    }

    private AnimationToStateMachine _animationToStateMachine;

    public AnimationToStateMachine AnimationToStateMachine
    {
        get => GenericUtil<AnimationToStateMachine>.GetOrDefault(_animationToStateMachine, transform.parent.name);
        private set => _animationToStateMachine = value;
    }

    private Input _input;

    public Input Input
    {
        get => GenericUtil<Input>.GetOrDefault(_input, transform.parent.name);
        private set => _input = value;
    }

    private Movement _movement;

    public Movement Movement
    {
        get => GenericUtil<Movement>.GetOrDefault(_movement, transform.parent.name);
        private set => _movement = value;
    }

    private CollisionSenses _collisionSenses;

    public CollisionSenses CollisionSenses
    {
        get => GenericUtil<CollisionSenses>.GetOrDefault(_collisionSenses, transform.parent.name);
        private set => _collisionSenses = value;
    }

    private Sound _sound;

    public Sound Sound
    {
        get => GenericUtil<Sound>.GetOrDefault(_sound, transform.parent.name);
        private set => _sound = value;
    }

    private void Awake()
    {
        Animation = GetComponentInChildren<Animation>();
        AnimationToStateMachine = GetComponentInChildren<AnimationToStateMachine>();
        Input = GetComponentInChildren<Input>();
        Movement = GetComponentInChildren<Movement>();
        CollisionSenses = GetComponentInChildren<CollisionSenses>();
        Sound = GetComponentInChildren<Sound>();
    }
}
