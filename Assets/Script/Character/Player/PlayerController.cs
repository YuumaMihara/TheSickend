using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Utility;
using Random = UnityEngine.Random;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameObject cam;
    [SerializeField] private GameObject handLight;
    [SerializeField] public float speed = 3.0f;
    [SerializeField] private CurveControlledBob m_HeadBob = new CurveControlledBob();
    [SerializeField] private CurveControlledHandBob m_HandBob = new CurveControlledHandBob();
    [SerializeField] [Range(0f, 1f)] private float m_RunstepLenghten;
    [SerializeField] private bool m_IsWalking;
    [SerializeField] private float m_StepInterval;
    [SerializeField] private AudioClip[] m_FootstepSounds; 
    private CharacterController controller;
    private PlayerCameraController cameraCon;
    private Camera camera;
    private Vector2 m_Input;
    private AudioSource audioSource;
    private float m_StepCycle;
    private float m_NextStep;
    private float gravity = 9.8f;
    private float horizontalInput;
    private float verticalInput;


    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        camera = Camera.main;

        controller = GetComponent<CharacterController>();
        cameraCon = cam.GetComponent<PlayerCameraController>();

        m_HeadBob.Setup(camera, m_StepInterval);
        m_HandBob.Setup(handLight, m_StepInterval);

        m_StepCycle = 0f;
        m_NextStep = m_StepCycle/2f;
    }

    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
    }

    void FixedUpdate()
    {
        CalculateMove();

        if (Input.GetMouseButtonUp(0))
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        ProgressStepCycle(speed);
        UpdateCameraPosition(speed);
        
    }

    private void UpdateCameraPosition(float speed){
        if (controller.velocity.magnitude > 0 && controller.isGrounded)
        {
            camera.transform.localPosition =
                m_HeadBob.DoHeadBob(controller.velocity.magnitude +
                                  (speed*(m_IsWalking ? 1f : m_RunstepLenghten)));
            
            handLight.transform.localPosition = 
                m_HandBob.DoHeadBob(controller.velocity.magnitude +
                                  (speed*(m_IsWalking ? 1f : m_RunstepLenghten)));
        }
    }

    private void ProgressStepCycle(float speed)
        {
            if (controller.velocity.sqrMagnitude > 0)
            {
                m_StepCycle += (controller.velocity.magnitude + (speed*(m_IsWalking ? 1f : m_RunstepLenghten)))*
                             Time.fixedDeltaTime;
            }

            if (!(m_StepCycle > m_NextStep))
            {
                return;
            }

            m_NextStep = m_StepCycle + m_StepInterval;

            PlayFootStepAudio();
        }


        private void PlayFootStepAudio()
        {
            if (!controller.isGrounded)
            {
                return;
            }

            int n = Random.Range(1, m_FootstepSounds.Length);
            audioSource.clip = m_FootstepSounds[n];
            audioSource.PlayOneShot(audioSource.clip);

            m_FootstepSounds[n] = m_FootstepSounds[0];
            m_FootstepSounds[0] = audioSource.clip;
        }


    void CalculateMove()
    {
        Vector3 direction = new Vector3(horizontalInput, 0, verticalInput);
        Vector3 velocity = direction * speed;
        velocity.y -= gravity;
        velocity = transform.transform.TransformDirection(velocity);
        controller.Move(velocity * Time.deltaTime);
    }

}