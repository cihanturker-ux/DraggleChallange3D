using Cinemachine;
using UnityEngine;

public class CinemachineShake : MonoBehaviour
{
    public static CinemachineShake Instance { get; private set; }

    [SerializeField] private float intensity = 0.04f;
    [SerializeField] private float shakeTime = 0.4f;
    
    private CinemachineVirtualCamera cinemachineVirtualCamera;
    private CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin;

    private float timer;

    void Awake()
    {
        Instance = this;
        cinemachineVirtualCamera = GetComponent<CinemachineVirtualCamera>();
        cinemachineBasicMultiChannelPerlin = cinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
    }

    public void ShakeCamera()
    {
        cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = intensity;
        timer = shakeTime;
    }

    private void Update()
    {
        if (timer > 0f)
        {
            timer -= Time.deltaTime;
            if (timer <= 0f)
            {
                cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = Mathf.Lerp(intensity, 0f, 1 - (timer / shakeTime));
            }
        }
    }
}
