using UnityEngine;

public class CoreContainer : MonoBehaviour
{
    private Animation _animation;

    public Animation Animation
    {
        get => GenericUtil<Animation>.GetOrDefault(_animation, transform.parent.name);
        private set => _animation = value;
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

    private void Awake()
    {
        Animation = GetComponentInChildren<Animation>();
        Input = GetComponentInChildren<Input>();
        Movement = GetComponentInChildren<Movement>();
        CollisionSenses = GetComponentInChildren<CollisionSenses>();
    }
}
