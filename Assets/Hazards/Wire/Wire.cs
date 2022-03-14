using System.Collections.Generic;
using UnityEngine;

public class Wire : MonoBehaviour
{
    [SerializeField] private Transform _electricDevicePosition;
    [SerializeField] private Transform _electricContactPosition;
    [SerializeField] private float _wireSegmentLength = 0.25f;
    [SerializeField] private int _wireLength = 35;
    [SerializeField] private float _wireWidth = 0.1f;
    [SerializeField] private Vector2 _forceGravity = new Vector2(0f, -1.0f);
    [SerializeField] private int _numberOfConstraints = 100;

    private LineRenderer _mylineRenderer;
    private List<WireSegment> _wireSegments = new List<WireSegment>();

    private void Start()
    {
        _mylineRenderer = GetComponent<LineRenderer>();

        Vector3 wireStartPoint = _electricDevicePosition.transform.position;

        for (int i = 0; i < _wireLength - 1; i++)
        {
            _wireSegments.Add(new WireSegment(wireStartPoint));
        }

        WireSegment lastSegment = _wireSegments[_wireSegments.Count - 1];
        lastSegment.newPosition = _electricContactPosition.transform.position;
        _wireSegments.Add(lastSegment);
    }

    private void Update() => DrawWire();

    private void FixedUpdate() => Simulate();

    private void Simulate()
    {
        for (int segmentIndex = 1; segmentIndex < _wireLength - 1; segmentIndex++)
        {
            WireSegment segment = _wireSegments[segmentIndex];
            Vector2 velocity = segment.newPosition - segment.oldPosition;
            segment.oldPosition = segment.newPosition;
            segment.newPosition += velocity;
            segment.newPosition += _forceGravity * Time.fixedDeltaTime;
            _wireSegments[segmentIndex] = segment;
        }

        for (int i = 0; i < _numberOfConstraints; i++)
        {
            ApplyConstraints();
        }
    }

    private void DrawWire()
    {
        float wireWidth = _wireWidth;
        _mylineRenderer.startWidth = wireWidth;
        _mylineRenderer.endWidth = wireWidth;

        Vector3[] wirePositions = new Vector3[_wireLength];
        for (int segmentIndex = 0; segmentIndex < _wireLength; segmentIndex++)
        {
            wirePositions[segmentIndex] = _wireSegments[segmentIndex].newPosition;
        }

        _mylineRenderer.positionCount = wirePositions.Length;
        _mylineRenderer.SetPositions(wirePositions);
    }

    private void ApplyConstraints()
    {
        WireSegment firstSegment = _wireSegments[0];
        firstSegment.newPosition = _electricDevicePosition.transform.position;
        _wireSegments[0] = firstSegment;

        WireSegment lastSegment = _wireSegments[_wireSegments.Count - 1];
        lastSegment.newPosition = _electricContactPosition.transform.position;
        _wireSegments[_wireSegments.Count - 1] = lastSegment;

        for (int segmentIndex = 0; segmentIndex < _wireLength - 1; segmentIndex++)
        {
            WireSegment segment = _wireSegments[segmentIndex];
            WireSegment nextSegment = _wireSegments[segmentIndex + 1];

            float dist = (segment.newPosition - nextSegment.newPosition).magnitude;
            float error = Mathf.Abs(dist - _wireSegmentLength);
            Vector2 changeDir = Vector2.zero;

            // Make sure two wire segments do not get too far apart or too close together
            if (dist > _wireSegmentLength)
            {
                changeDir = (segment.newPosition - nextSegment.newPosition).normalized;
            }
            else if (dist < _wireSegmentLength)
            {
                changeDir = (nextSegment.newPosition - segment.newPosition).normalized;
            }

            Vector2 changeAmount = changeDir * error;

            if (segmentIndex != 0)
            {
                segment.newPosition -= changeAmount * 0.5f;
                _wireSegments[segmentIndex] = segment;
                nextSegment.newPosition += changeAmount * 0.5f;
                _wireSegments[segmentIndex + 1] = nextSegment;
            }
            else
            {
                nextSegment.newPosition += changeAmount;
                _wireSegments[segmentIndex + 1] = nextSegment;
            }
        }
    }

    private struct WireSegment
    {
        public Vector2 newPosition;
        public Vector2 oldPosition;

        public WireSegment(Vector2 position)
        {
            newPosition = position;
            oldPosition = position;
        }
    }
}
