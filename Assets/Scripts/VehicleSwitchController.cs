using StarterAssets;
using UnityEngine.InputSystem;
using UnityEngine;

public class VehicleSwitchController : MonoBehaviour
{
    [Header("Player")]
    [SerializeField] private ThirdPersonController thirdPersonController;
    [SerializeField] private CharacterController characterController;
    [SerializeField] private PlayerInput playerInput;
    [SerializeField] private GameObject playerModel;
    [SerializeField] private GameObject playerCamera;

    [Header("Vehicle")]
    [SerializeField] private PlayerInput vehicleInput;
    [SerializeField] private GameObject vehicleCamera;
    [SerializeField] private GameObject vehicleUI;
    [SerializeField] private Transform driverSeat;
    [SerializeField] private Transform exitPoint;
    [SerializeField] private float enterDistance = 3f;

    private bool isDriving;

    void Update()
    {
        if (Keyboard.current.fKey.wasPressedThisFrame)
        {
            if(isDriving)
            {
                ExitVehicle();
            }
            else
            {
                EnterVehicle();
            }
        }
    }

    private void EnterVehicle()
    {
        float distance = Vector3.Distance(transform.position, driverSeat.position);

        if (distance <= enterDistance)
        {
            playerInput.enabled = false;
            thirdPersonController.enabled = false;
            characterController.enabled = false;

            playerModel.SetActive(false);
            playerCamera.SetActive(false);

            transform.SetPositionAndRotation(driverSeat.position, driverSeat.rotation);
            transform.SetParent(driverSeat);

            vehicleInput.enabled = true;
            vehicleCamera.SetActive(true);
            vehicleUI.SetActive(true);

            isDriving = true;
            Debug.Log("isDriving = " + isDriving);
        }
    }

    private void ExitVehicle()
    {
        vehicleInput.enabled = false;
        vehicleCamera.SetActive(false);
        vehicleUI.SetActive(false);
        
        transform.SetParent(null);
        transform.SetPositionAndRotation(exitPoint.position, exitPoint.rotation);

        playerInput.enabled = true;
        thirdPersonController.enabled = true;
        characterController.enabled = true;

        playerModel.SetActive(true);
        playerCamera.SetActive(true);

        isDriving = false;
        Debug.Log("isDriving = " + isDriving);
    }
}
