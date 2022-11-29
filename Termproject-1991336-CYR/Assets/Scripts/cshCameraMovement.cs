using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cshCameraMovement : MonoBehaviour
{
    public float clampAngle = 70f;
    public float sensitivity = 50f;
    public float speed = 5f;

    private float rotX;
    private float rotY;
 
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // 마우스의 위치를 고정
        Cursor.visible = false; // 마우스가 보이지 않게 함

        //rotX = transform.localRotation.eulerAngles.x;
        //rotY = transform.localRotation.eulerAngles.y;
    }

    // Update is called once per frame
    void Update()
    {
        mouseMovement();
        

    }

    void keyboardMovement(){
        // WASD 키 또는 화살표키의 이동량을 측정
        Vector3 dir = new Vector3(
            Input.GetAxis("Horizontal"), 
            0,
            Input.GetAxis("Vertical")
        );
        // 이동방향 * 속도 * 프레임단위 시간을 곱해서 카메라의 트랜스폼을 이동
        transform.Translate(dir * speed * Time.deltaTime);
    }

    void mouseMovement(){
        rotX += -(Input.GetAxis("Mouse Y")) * sensitivity * Time.deltaTime; // 마우스 상하
        rotY += Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime; // 마우스 좌우

        rotX = Mathf.Clamp(rotX, -clampAngle, clampAngle); // 좌우 범위
        Quaternion rot = Quaternion.Euler(rotX, rotY, 0); // z축 0
        transform.rotation = rot;
    }


}