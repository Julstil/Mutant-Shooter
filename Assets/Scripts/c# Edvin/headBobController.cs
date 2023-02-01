using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class headBobController : MonoBehaviour
{
    [SerializeField] private bool enable;

    [SerializeField, Range(0, 0.02f)] private float amplitude = 0.015f;
    [SerializeField, Range(0, 60)] private float frequency = 10;
    public float range = 100;
    [SerializeField, Range(0, 0.02f)] private float sprintAmplitude;
    [SerializeField, Range(0, 0.02f)] private float crouchAmplitude;
    [SerializeField, Range(0, 60)] private float sprintFrequency;
    [SerializeField, Range(0, 60)] private float crouchFrequency;
    float saveAmplitude;
    float saveFrequency;

    [SerializeField] Transform camera = null;
    [SerializeField] Transform cameraHolder = null;

    private float toggleSpeed = 1;
    private Vector3 startPos;

    movement movement;
    [HideInInspector] public RaycastHit hit;

    // Start is called before the first frame update
    void Start()
    {
        movement = transform.GetComponentInParent<movement>();
        saveFrequency = frequency;
        saveAmplitude = amplitude;
    }

    // Update is called once per frame
    void Update()
    {
        if (!enable) return;

        checkMotion();
        ResetPos();
        camera.LookAt(FocusTarget());

        if (Input.GetKeyDown(movement.sprint))
        {
            frequency = sprintFrequency;
            amplitude = sprintAmplitude;
        }
        else if (Input.GetKeyUp(movement.sprint))
        {
            frequency = saveFrequency;
            amplitude = saveAmplitude;
        }
        
        if (Input.GetKeyDown(movement.crouch))
        {
            frequency = crouchFrequency;
            amplitude = crouchAmplitude;
        }
        else if (Input.GetKeyUp(movement.crouch))
        {
            frequency = saveFrequency;
            amplitude = saveAmplitude;
        }
    }

    private void Awake()
    {
        startPos = camera.localPosition;
    }

    private void PlayMotion(Vector3 motion)
    {
        camera.localPosition += motion;
    }

    private Vector3 FootStepMotion()
    {
        Vector3 pos = Vector3.zero;
        pos.y += Mathf.Sin(Time.time * frequency) * amplitude;
        pos.x += Mathf.Cos(Time.time * frequency / 2) * amplitude * 2;
        return pos;
    }

    private void checkMotion()
    {
        float speed = new Vector3(movement.move.x, 0, movement.move.z).magnitude;

        if (speed < toggleSpeed) return;
        if (!movement.isgrounded) return;

        PlayMotion(FootStepMotion());
    }

    private void ResetPos()
    {
        if (camera.localPosition == startPos) return;
        camera.localPosition = Vector3.Lerp(camera.localPosition, startPos, 1 * Time.deltaTime);
    }

    private Vector3 FocusTarget()
    {
        Vector3 pos = new Vector3(transform.position.x, transform.position.y + cameraHolder.localPosition.y, transform.position.z);

        if(Physics.Raycast(camera.position, camera.forward, out hit, range))
        {
            float pointing = Vector3.Distance(camera.position, hit.point);
            pos += cameraHolder.forward * pointing;   
        }
        
        return pos;
    }
}
