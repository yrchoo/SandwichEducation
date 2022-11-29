using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cshMakeSandwich : MonoBehaviour
{

    private bool start = false; // 샌드위치 만들기를 시작했는지
    private bool putMeat = false; // 햄을 올렸는 지
    private bool putCheese = false; // 치즈를 올렸는지
    private bool toast = false; // 빵을 구웠는지
    private bool putVegi = false; // 야채를 올렸는지
    private bool putTomato = false; // 토마토를 올렸는지
    private bool putSauce = false; // 소스를 뿌렸는지
    private bool putBread = false;
    private bool end = false;

    [Header("Camera")]
    public Camera cam;

    [Header("Sandwich Object")]
    public GameObject sandwich;
    public GameObject underBread;
    public GameObject ham;
    public GameObject cheese;
    public GameObject vegi;
    public GameObject tomato;
    public GameObject sauce;
    public GameObject upperBread;
    public GameObject endPointer;
    public GameObject putSandwich;
    public GameObject baking;
    public GameObject notYet;

    [Header("ToDoText")]
    public GameObject todoPanel;
    public Text one;
    public Text two;
    public Text three;
    public Text four;
    public Text five;
    public Text six;
    public Text seven;
    public Text eight;

    // Start is called before the first frame update
    void Start()
    {
        
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
                if(hit.transform.gameObject.tag == "Bread" && !start)
                {
                    Debug.Log(hit.transform.gameObject);
                    start = true;
                    underBread.SetActive(true);
                    // 다음 단계를 할 수 있도록 활성화
                    putMeat = true;
                    // to-do list 글씨 색상 변경
                    one.color = Color.gray;
                }
                else if(hit.transform.gameObject.tag == "Meat" && putMeat)
                {
                    
                    Debug.Log(hit.transform.gameObject);

                    ham.SetActive(true);
                    // 진행된 단계는 비활성화
                    putMeat = false;
                    // 다음 단계를 할 수 있도록 활성화
                    putCheese = true;
                    // to-do list 글씨 색상 변경
                    two.color = Color.gray;
                }
                else if(hit.transform.gameObject.tag == "Cheese" && putCheese)
                {
                    
                    Debug.Log(hit.transform.gameObject);

                    cheese.SetActive(true);
                    
                    // 진행된 단계는 비활성화
                    putCheese = false;
                    // 다음 단계를 할 수 있도록 활성화
                    toast = true;
                    // to-do list 글씨 색상 변경
                    three.color = Color.gray;
                }
                else if(hit.transform.gameObject.tag == "Oven" && toast)
                {
                    
                    Debug.Log(hit.transform.gameObject);
                    // 현재 빵이 구워짐을 출력하기
                    Debug.Log("빵이 구워지는 중...");
                    baking.SetActive(true);
                    // 진행된 단계는 비활성화
                    toast = false;
                    // 다음 단계를 할 수 있도록 활성화
                    putVegi = true;
                    // to-do list 글씨 색상 변경
                    four.color = Color.gray;
                }
                else if(hit.transform.gameObject.tag == "Vegi" && putVegi)
                {
                    
                    Debug.Log(hit.transform.gameObject);
                    vegi.SetActive(true);
                    // 진행된 단계는 비활성화
                    putVegi = false;
                    // 다음 단계를 할 수 있도록 활성화
                    putTomato = true;
                    // to-do list 글씨 색상 변경
                    five.color = Color.gray;
                }
                else if(hit.transform.gameObject.tag == "Tomato" && putTomato)
                {
                    
                    Debug.Log(hit.transform.gameObject);
                    tomato.SetActive(true);
                    // 진행된 단계는 비활성화
                    putTomato = false;
                    // 다음 단계를 할 수 있도록 활성화
                    putSauce = true;
                    // to-do list 글씨 색상 변경
                    six.color = Color.gray;
                }
                else if(hit.transform.gameObject.tag == "Sauce" && putSauce)
                {
                    
                    Debug.Log(hit.transform.gameObject);
                    sauce.SetActive(true);
                    // 진행된 단계는 비활성화
                    putSauce = false;
                    // 다음 단계를 할 수 있도록 활성화
                    putBread = true;
                    // to-do list 글씨 색상 변경
                    seven.color = Color.gray;
                }
                else if(hit.transform.gameObject.tag == "Bread" && putBread)
                {
                    Debug.Log(hit.transform.gameObject);
                    
                    upperBread.SetActive(true);
                    // 진행된 단계는 비활성화
                    putBread = false;

                    // 다음 단계를 할 수 있도록 활성화
                    end = true;
                    // to-do list 글씨 색상 변경
                    eight.color = Color.gray;
                    // 샌드위치를 둘 곳 표시
                    endPointer.SetActive(true);
                }
                else if(hit.transform.gameObject.tag == "End" && end)
                {
                    end = false;
                    Debug.Log(hit.transform.gameObject);

                    upperBread.SetActive(true);
                    // 샌드위치 제조가 끝남
                    start = false;
                    // to-do list 글씨 색상 변경
                    todoPanel.SetActive(false);
                    // 샌드위치를 둘 곳 표시 비활성화
                    endPointer.SetActive(false);
                    //손에 들고 있는 샌드위치 비활성화
                    sandwich.SetActive(false);
                    // 내려두는 곳 샌드위치 활성화
                    putSandwich.SetActive(true);

                }
                else if(start){ // 현재 진행해야할 파트가 아닌 것을 누른 경우
                    Debug.Log(hit.transform.gameObject);
                    notYet.SetActive(true);
                    Debug.Log("현재 순서가 아닙니다.");
                }
                
            }
        }
    }
}
