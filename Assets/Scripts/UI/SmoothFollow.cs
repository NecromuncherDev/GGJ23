using UnityEngine;

public class SmoothFollow : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float speed;

    [Header("Target")]
    [SerializeField] private Transform objectToFollow;

    [Header("Custom Gap")]
    [SerializeField] bool useCustomGap;
    [SerializeField] Vector3 customGap = Vector3.zero;

    private Vector3 gap = Vector3.zero;

    private void Start()
    {
        gap = useCustomGap ? customGap : transform.position - objectToFollow.position;
    }

    void Update()
    {
        float interpolation = speed * Time.deltaTime;
        transform.position = Vector3.Lerp(transform.position, objectToFollow.position + gap, interpolation);
    }
}