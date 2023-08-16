using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class ObjectInspection : MonoBehaviour
{
    [Header("Zoom")]
    public Transform zoomPosition; // Hareket ettirilecek hedef konum
    public float movementSpeed = 2f; // Hareket h�z�
    private bool isMoving = false; // Hareket durumu
    private Vector3 startPosition; // Ba�lang�� konumu
    private float startTime; // Hareketin ba�lama zaman�

    [Header("SetActiveControl")]
    private DroneRotation droneRotation;
    public GameObject objectScript;
    public GameObject[] u�Elements;

    [Header("Rotation")]
    private bool isRotating = false;
    [SerializeField]
    private float rotateSpeed = 1f;
    public float resetSpeed = 2f; // Yumu�ak s�f�rlama h�z�
    private bool isResetting = false;
    private Quaternion startRotation;
    private Quaternion targetRotation = Quaternion.identity;
    public GameObject resetRotationButton;


    private void Start()
    {
        startPosition = transform.position;
        droneRotation = objectScript.GetComponent<DroneRotation>();
        startRotation = transform.rotation;

    }
    private void Update()
    {
        Zoom();
        Rotation();

    }
    public void OnButtonClick()
    {

        if (!isMoving)
        {
            // Butona t�kland���nda hareketi ba�lat
            isMoving = true;
            startTime = Time.time;
            startPosition = transform.position;
            if (droneRotation == null)
            {
                Debug.Log("null");
            }
            else
            {
                droneRotation.enabled = false;
            }

            for (int i = 0; i < u�Elements.Length; i++)
            {
                u�Elements[i].SetActive(false);
            }

        }
        else
        {
            isMoving = false;
            startTime = Time.time;
            if (droneRotation == null)
            {
                Debug.Log("null");
            }
            else
            {
                droneRotation.enabled = true;
            }
            isResetting = false;

            for (int i = 0; i < u�Elements.Length; i++)
            {
                u�Elements[i].SetActive(true);
            }
        }


    }

    public void Zoom()
    {
        if (isMoving)
        {
            float distanceCovered = (Time.time - startTime) * movementSpeed;
            float journeyLength = Vector3.Distance(startPosition, zoomPosition.position);
            float fractionOfJourney = distanceCovered / journeyLength;
            transform.position = Vector3.Lerp(startPosition, zoomPosition.position, fractionOfJourney);
            resetRotationButton.SetActive(true);


        }
        if (!isMoving)
        {
            float distanceCovered = (Time.time - startTime) * movementSpeed;
            float journeyLength = Vector3.Distance(startPosition, zoomPosition.position);
            float fractionOfJourney = distanceCovered / journeyLength;

            transform.position = Vector3.Lerp(zoomPosition.position, startPosition, fractionOfJourney);
            if (isResetting == false)
            {
                transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, resetSpeed * Time.deltaTime);
            }
            if (fractionOfJourney >= 1.0f)
            {
                isResetting = true;
            }
            resetRotationButton.SetActive(false);

        }
    }

    public void Rotation()
    {
        if (isRotating && isMoving)
        {
            float horizontalInput = Input.GetAxis("Mouse X") * rotateSpeed;
            float verticalInput = Input.GetAxis("Mouse Y") * rotateSpeed;
            transform.Rotate(Vector3.up, -horizontalInput, Space.World);
            transform.Rotate(Vector3.right, -verticalInput, Space.Self);
        }
    }

    private void OnMouseDown()
    {
        // Fare t�klamas� ba�lad���nda, objenin rotasyonunu de�i�tirmeye ba�lamak i�in gerekli bilgileri al
        isRotating = true;
    }

    private void OnMouseUp()
    {
        // Fare t�klamas� b�rak�ld���nda, objenin rotasyonunu durdur
        isRotating = false;
    }

    public void OnClickRotation()
    {
        transform.rotation = startRotation;
    }


}
