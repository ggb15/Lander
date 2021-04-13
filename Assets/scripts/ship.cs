using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField]
    float MaxRelativeVelocity = 2f;

    [SerializeField]
    float maxRot = 10f;

    [SerializeField]
    float thurstForce = 150f;

    [SerializeField]
    float torqueForce = 15f;

    [SerializeField]
    float Fuel = 500f;

    [SerializeField]
    TextMeshProUGUI fuelTXT;

    private void Update()
    {
        if (Fuel > 0)
        {
            if (Input.GetKey(KeyCode.W))
            {
                GetComponent<Rigidbody2D>().AddForce(transform.up * thurstForce * Time.deltaTime);
                Fuel -= 10 * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.A))
            {
                GetComponent<Rigidbody2D>().AddTorque(torqueForce * Time.deltaTime);
                Fuel -= 5 * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.D))
            {
                GetComponent<Rigidbody2D>().AddTorque(-torqueForce * Time.deltaTime);
                Fuel -= 5 * Time.deltaTime;
            }
        }
        Debug.Log(Fuel);

        fuelTXT.text = "Fuel " + System.Convert.ToInt32(Fuel).ToString();

    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "plataforma")
        {
            Debug.Log("aterrei");

            if (collision.relativeVelocity.magnitude > MaxRelativeVelocity || Mathf.Abs(transform.localEulerAngles.z) > maxRot)
            {
                Debug.Log("aterrei mas fui com o boda");
            }
        }
        else
        {
            Debug.Log("morri");
            Destroy(gameObject);
        }
    }
}
