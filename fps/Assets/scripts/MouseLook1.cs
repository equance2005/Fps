using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//���������ת
//���������ת�����������ת



public class MouseLook1 : MonoBehaviour
{
    public float mouseSenitivity = 100f;//����������
    public Transform playerBody;
    public float xRotation = 0f;



    // Start is called before the first frame update
    void Start()
    {
        //���ع��
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX =  Input.GetAxis("Mouse X")*mouseSenitivity*Time.deltaTime*10;
        float mouseY = Input.GetAxis("Mouse Y")*mouseSenitivity* Time.deltaTime*10;

        xRotation -= mouseY;
        xRotation  = Mathf.Clamp(xRotation, -80f, 40f);
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);//��Һ�����ת
         
    }
}
