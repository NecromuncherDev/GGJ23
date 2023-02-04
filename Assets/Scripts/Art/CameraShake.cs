using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public float shakeTimer;
    public float shakeAmount;
    public static CameraShake myCameraShake;
    private Vector3 startPos;

    private bool isShaking;

    void Awake()
    {
        myCameraShake = this;
        isShaking = false;
    }

    [ContextMenu("Shake")]
    public static void Shake()
    {
        CameraShake.myCameraShake.ShakeCamera(myCameraShake.shakeAmount, myCameraShake.shakeTimer);
    }

    void Update()
    {
        if (!isShaking)
        {
            return;
        }
        if (shakeTimer >= 0)
        {
            shakeAmount *= 0.7f;
            Vector2 shakePos = Random.insideUnitCircle * shakeAmount;
            transform.position = new Vector3(transform.position.x + (shakePos.x * 0.3f),
                transform.position.y + shakePos.y,
                transform.position.z);
            shakeTimer -= Time.deltaTime;
        }
        else
        {
            transform.position = startPos;
            isShaking = false;
        }
    }

    public void ShakeCamera(float shakePwr, float shakeDur)
    {
        isShaking = true;
        startPos = transform.position;
        shakeAmount = shakePwr;
        shakeTimer = shakeDur;
    }
}