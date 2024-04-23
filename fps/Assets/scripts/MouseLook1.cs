using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//摄像机的旋转
//玩家左右旋转摄像机上下旋转



public class MouseLook1 : MonoBehaviour
{
    public float mouseSenitivity = 100f;//视线灵敏度
    public Transform playerBody;
    public float xRotation = 0f;



    // Start is called before the first frame update
    void Start()
    {
        //隐藏光标
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
        playerBody.Rotate(Vector3.up * mouseX);//玩家横向旋转
         
    }
}
