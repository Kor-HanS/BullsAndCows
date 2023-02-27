using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    // 팝업 UI
    [SerializeField]
    private GameObject Canvas_Rule; // 규칙
    
    // 버튼 UI
    [SerializeField]
    private Button Button_Restart; // 재시작
    [SerializeField]
    private Button[] Buttons_Number; // 배열 숫자 입력 0 ~ 9 
    [SerializeField]
    private Button Button_NumInput; // 번호 입력 -> 길이 4가 되면 활성화.
    [SerializeField]
    private Button Button_NumDelete; // 번호 삭제 -> 입력 중이던 번호 삭제.
    
    // 텍스트 UI
    [SerializeField]
    private TMP_Text Text_Input;

    // prviate 변수
    private int now = 0; // 현재 입력 할 인덱스.
    private int[] answer;
    private int[] inputs; // 4개의 숫자를 string으로 관리.
    private int tryNum = 0; // 시도 횟수

    // public 변수
    public UnityEvent GameStartEvent;

    private void Awake(){
        // 버튼 콜백 함수 연결.
        Button_Restart.onClick.AddListener(OnClickButton_Restart);
        Button_NumDelete.onClick.AddListener(OnClickButton_NumDelete);
        Button_NumInput.onClick.AddListener(OnClickButton_NumInput);
        for(int i = 0 ; i < 10; i++){
            int now = i;
            Buttons_Number[i].onClick.AddListener( delegate { OnClickButton_Number(now);});
        }
        Button_NumInput.interactable = false;
    }

    private void Start() {
        answer = new int[4];
        inputs = new int[4];

        // 이벤트 관리.
        GameStartEvent = new UnityEvent();
        GameStartEvent.AddListener(GenerateNewAnswer);
        GameStartEvent.AddListener(InitializeVariables);
        GameStartEvent.AddListener(UpdateTextInput);

        // 게임 시작.
        GameStartEvent.Invoke();    
    }

    private void Update()
    {
        ShowRule();
    }

    // Tab 클릭시, 룰 팝업창 보여주기.
    public void ShowRule(){
        if(Input.GetKeyDown(KeyCode.Tab)){
            Canvas_Rule.SetActive(true);
        }else if(Input.GetKeyUp(KeyCode.Tab)){
            Canvas_Rule.SetActive(false);
        }
    }

    // Text_Input 초기화.
    public void UpdateTextInput(){
        string inputText = ""; 
        for(int i = 0; i < now; i++){
            inputText += inputs[i];
        }
        Text_Input.text = inputText;
    }

    // 야구게임 정답 생성.
    public void GenerateNewAnswer(){
        int[] t_num = new int[4];
        bool[] t_visit = new bool[10];
        for(int i = 0 ; i < 4; i++){
            if(i == 0){
                t_num[i] = Random.Range(1,10);
                t_visit[t_num[i]] = true;
            }else{
                do{
                    t_num[i] = Random.Range(0,10);
                }while(t_visit[t_num[i]]);
                t_visit[t_num[i]] = true;
            }
            answer[i] = t_num[i];
        }
        print(answer[0]);
        print(answer[1]);
        print(answer[2]);
        print(answer[3]);
    }

    // 게임 관련 변수 초기화.
    public void InitializeVariables(){
        for(int i = 0 ; i < 4; i++){
            answer[i] = 0;
            inputs[i] = 0;
        }
        now = 0;
        tryNum = 0;
        Button_NumDelete.interactable = true;
        Button_NumInput.interactable = false;
        for(int j = 0 ; j < 10; j++){
            Buttons_Number[j].interactable = true;
        }
    }

    // 버튼 콜백 함수
    public void OnClickButton_Restart(){
        GameStartEvent.Invoke();
    }

    public void OnClickButton_Number(int num){
        inputs[now++]  = num;
        print(num);
        // 정답 텍스트 업데이트.
        UpdateTextInput();
        // 4개의 숫자를 모두 골랐다면 입력 버튼 활성화.
        if(now == 4){
            Button_NumInput.interactable = true;
            for(int i = 0 ; i < 10; i++){
                Buttons_Number[i].interactable = false;
            }
        }
    }

    public void OnClickButton_NumDelete(){
    for(int i = 0 ; i < 4; i++){inputs[i] = 0;}
        now = 0;
        for(int i = 0 ; i < 10; i++){
            Buttons_Number[i].interactable = true;
        }
        Button_NumInput.interactable = false;
        UpdateTextInput();
    }

    public void OnClickButton_NumInput(){
        // answer과 inputString 비교후 , 결과 출력. 
    }
}
