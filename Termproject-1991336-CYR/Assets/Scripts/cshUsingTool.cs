using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class cshUsingTool : MonoBehaviour{


    [Header("Camera")]
    public Camera cam;

    [Header("Panel")]
    public GameObject toolPanel;

    [Header("Refrigerator")]
    public GameObject refrigPanel;
    private bool usingRefrig = false;


    [Header("Knikfe")]
    public GameObject knife;
    public Material knifeMat;
    public Material dangerKnifeMat;
    Renderer rend;
    
    [Header("MovingHandle")]
    public GameObject handle;
    public GameObject tomato;
    public int clickedTime = 0;
    int moveSeq = 0;
    public GameObject startPos;
    public GameObject endPos;
    public float speed = 0.01f;
    private bool moveToEnd = false;
    private bool moveToStart = false;
    private Vector3 velo = Vector3.zero;

    private float time = 0f;
    private bool isWorking = false;





    // Start is called before the first frame update
    void Start()
    {
        clickedTime = 0;
        rend = knife.GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                if(hit.transform.gameObject.tag == "Tool" && !usingRefrig) // 냉장고 사용중엔 도구 사용 X
                {
                    Debug.Log(hit.transform.gameObject);

                    moveSeq = clickedTime % 5;

                    switch(moveSeq){
                        case 0: // 패널 띄우기
                        toolPanel.SetActive(true); 
                        isWorking = true;
                        rend.sharedMaterial = dangerKnifeMat; break;
                        
                        case 1: // 토마토 두기
                        tomato.SetActive(true); break;

                        case 2: // 핸들 밀기
                        moveToStart = false;
                        moveToEnd = true; break;

                        case 3: // 토마토 제거
                        tomato.SetActive(false); break;

                        case 4: // 핸들 당기기
                        moveToEnd = false;
                        moveToStart = true;
                        // 패널 제거
                        toolPanel.SetActive(false);
                        isWorking = false;
                        rend.sharedMaterial = knifeMat; break;

                        default: break;
                    }

                    clickedTime++;
                    
                }   
                if(hit.transform.gameObject.tag == "Refrig" && !isWorking) // 도구 사용중엔 냉장고 열기 X
                {
                    if(!usingRefrig){
                        usingRefrig = true;
                        refrigPanel.SetActive(true);
                    }
                    else{
                        usingRefrig = false;
                        refrigPanel.SetActive(false);
                    }
                }
            }
        }

        if(moveToEnd){
            movingTomato(endPos);
        }
        if(moveToStart){
            movingTomato(startPos);
        }
        if(isWorking){
            changeMat();
        }

    }

    void movingTomato(GameObject pos){
        handle.transform.position = Vector3.SmoothDamp(handle.transform.position, pos.transform.position, ref velo, 0.1f);
    }

    void changeMat(){
        time += Time.deltaTime;
        if((int)time % 2 == 0){
            rend.sharedMaterial = knifeMat;
        }
        else{
            rend.sharedMaterial = dangerKnifeMat;
        }
    }

}
