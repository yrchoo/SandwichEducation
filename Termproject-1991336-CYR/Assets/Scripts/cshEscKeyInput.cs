using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class cshEscKeyInput : MonoBehaviour
{
    public GameObject cam;
    public GameObject escPanel;
    private bool isESCPushed = false;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && !isESCPushed){
            isESCPushed = true;
            escInput();
        }
        else if(Input.GetKeyDown(KeyCode.Escape) && isESCPushed){
            isESCPushed = false;
            escInput2();
        }
    }


    void escInput(){
        // escPanel 출력
        escPanel.SetActive(true);
        Cursor.lockState = CursorLockMode.None; // 마우스 위치 고정 풀기
        Cursor.visible = true; // 마우스가 보이게
        // 카메라 움직임 스크립트를 정지
        cam.GetComponent<cshCameraMovement>().enabled = false;
        // player 움직임 스크립트 정지
        gameObject.GetComponent<cshPlayerMovement>().enabled = false;
    }

    void escInput2(){
        // escPanel 출력
        escPanel.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked; // 마우스 위치 고정
        Cursor.visible = false; // 마우스가 보이지 않게 함
        // 카메라 움직임 스크립트를 활성화
        cam.GetComponent<cshCameraMovement>().enabled = true;
        // player 움직임 스크립트 활성화
        gameObject.GetComponent<cshPlayerMovement>().enabled = true;
    }

    public void onExitBtn(){
        Application.Quit();
    }

    public void onRestartBtn(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
