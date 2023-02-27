# BullsAndCows
숫자 야구 게임 with Unity

작업 순서 대로 적겠습니다.

1. UI 제작.
- 게임 룰 배경 Image : https://www.wallpaperbetter.com/ko/hd-wallpaper-fsfze/download/1920x1080
- 게임 룰 UI(Tab 키 클릭시, SetActive(true)로 보여주기 /  게임 룰 Text 및 배경 Image)
- 게임 씬 UI(전 숫자 입력 결과 출력 스크롤뷰 / 0 ~ 9 숫자 입력 버튼 / 숫자 입력 확인,삭제 버튼 / 시도 횟수 Text / 재시작 버튼 / 숫자 입력 관련 Text) 

![image](https://user-images.githubusercontent.com/99121615/221143046-47b32ec1-1316-49b6-88ac-2ddde7919fef.png)

2. 게임 로직 구현
- GameStart UnityEvent 변수 생성 
- 게임 시작 시, GameStartEvent.Invoke() 를 통해 이벤트 관리.
- 새로운 정답 생성 , 게임 관련 변수 초기화 , 화면내 Text UI 초기화.
- 각종 버튼 리스너 콜백 함수 연결.
- 숫자를 4개 입력하면, 숫자 입력 버튼 활성화
- 활성화된 숫자 입력 버튼 클릭시, 판별하여 화면에 출력.

3. 이전 입력 저장 구현.
- List<GameObject> 를 통해 관리하며, TMP_Text 오브젝트를 프리팹으로 만든후
- 만약, 새로운 숫자 입력으로 결과를 생성한다면 프리팹을 생성후 , List에 추가 하고 ScrollView Content transform을 부모로 설정한다.
- 결과를 생성하기전 List에 있는 요소들을 자신들의 Height 인 240만큼 y축으로 내린다.(가장 최근의 결과가 맨 위에 놓이도록 함.)
![image](https://user-images.githubusercontent.com/99121615/221533796-e5d89245-d391-4d33-95a8-26ddfebcd194.png)
