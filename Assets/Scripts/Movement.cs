using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    [SerializeField] InputAction thrust;
    [SerializeField] InputAction rotation;
    [SerializeField] float thrustStrength = 100f;
    [SerializeField] float rotationStrength = 100f;
    [SerializeField] AudioClip mainEngineSFX;
    [SerializeField] ParticleSystem mainThrustParticles;
    [SerializeField] ParticleSystem leftThrustParticles;
    [SerializeField] ParticleSystem rightThrustParticles;

    Rigidbody rb;
    AudioSource audioSource;


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        thrust.Enable();
        rotation.Enable();
    }

    private void FixedUpdate()
    {
        ProcessThrust();
        ProcessRotation();
    }

    private void ProcessThrust()
    {
        if (thrust.IsPressed())
        {
            rb.AddRelativeForce(Vector3.up * thrustStrength * Time.fixedDeltaTime);
            //Debug.Log("Dang, I need some space");
            if(!audioSource.isPlaying)
            {
                audioSource.PlayOneShot(mainEngineSFX);
            }
            if(!mainThrustParticles.isPlaying)
            {
                mainThrustParticles.Play();
            }

        }
        else
        {
            audioSource.Stop();
            mainThrustParticles.Stop();
        }
    }

    private void ProcessRotation()
    {
        float rotationInput = rotation.ReadValue<float>();
        if(rotationInput < 0)
        {
            ApplyRotation(rotationStrength);
            if (!rightThrustParticles.isPlaying)
            {
                leftThrustParticles.Stop();
                rightThrustParticles.Play();
            }
        }
        else if (rotationInput > 0)
        {
            ApplyRotation(-rotationStrength);
            if (!leftThrustParticles.isPlaying)
            {
                rightThrustParticles.Stop();
                leftThrustParticles.Play();
            }
        }
        else
        {
            rightThrustParticles.Stop();
            leftThrustParticles.Stop();
        }
        //Debug.Log("here is our rotation value: " + rotationInput);
    }

    private void ApplyRotation(float rotationThisFrame)
    {
        rb.freezeRotation = true;
        transform.Rotate(Vector3.forward * rotationThisFrame * Time.fixedDeltaTime);
        rb.freezeRotation = false;
    }
}
