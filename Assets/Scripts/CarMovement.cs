using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarMovement : MonoBehaviour
{
    [SerializeField] WheelCollider FL;
    [SerializeField] WheelCollider FR;
    [SerializeField] WheelCollider BL;
    [SerializeField] WheelCollider BR;

    [SerializeField] Transform FLTransform;
    [SerializeField] Transform FRTransform;
    [SerializeField] Transform BLTransform;
    [SerializeField] Transform BRTransform;


    public float aceleracion = 100f;
    public float frenado = 60f;
    public float AnguloDesvio = 15f;

    private float aceleracionActual = 0f;
    private float frenadoActual = 0f;
    public float AnguloDesvioActual = 0f;

    public Transform SpawnBala;
    public GameObject Balaprefab;
    public float SpeedBala = 10;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            var bullet = Instantiate(Balaprefab, SpawnBala.position, SpawnBala.rotation);
            bullet.GetComponent<Rigidbody>().velocity = SpawnBala.forward * SpeedBala;

        }
    }
    private void FixedUpdate()
    {
        aceleracionActual = aceleracion * Input.GetAxis("Vertical");

        if (Input.GetKey(KeyCode.Space))
        {
            frenadoActual = frenado;
        }
        else
        {
            frenadoActual = 0f;
        }

        FR.motorTorque = aceleracionActual;
        FL.motorTorque = aceleracionActual;

        FR.brakeTorque = frenadoActual;
        FL.brakeTorque = frenadoActual;
        BR.brakeTorque = frenadoActual;
        BL.brakeTorque = frenadoActual;

        AnguloDesvioActual = AnguloDesvio * Input.GetAxis("Horizontal");
        FL.steerAngle = AnguloDesvioActual;
        FR.steerAngle = AnguloDesvioActual;

        UpdateWheel(FL, FLTransform);
        UpdateWheel(FR, FRTransform);
        UpdateWheel(BL, BLTransform);
        UpdateWheel(BR, BRTransform);

    }

    void UpdateWheel (WheelCollider col, Transform trans)
    {
        Vector3 posicion;
        Quaternion rotacion;
        col.GetWorldPose(out posicion, out rotacion);

        trans.position = posicion;
        trans.rotation = rotacion;
    }
}
