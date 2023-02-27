# BullsAndCows
숫자 야구 게임 with Unity

작업 순서 대로 적겠습니다.

1. UI 제작.
- 게임 룰 배경 Image : https://www.wallpaperbetter.com/ko/hd-wallpaper-fsfze/download/1920x1080
- 게임 룰 UI(Tab 키 클릭시, SetActive(true)로 보여주기 /  게임 룰 Text 및 배경 Image)
- 게임 씬 UI(전 숫자 입력 결과 출력 스크롤뷰 / 0 ~ 9 숫자 입력 버튼 / 숫자 입력 확인,삭제 버튼 / 시도 횟수 Text / 재시작 버튼 / 숫자 입력 관련 Text) 

![image](https://user-images.githubusercontent.com/99121615/221143046-47b32ec1-1316-49b6-88ac-2ddde7919fef.png)
![image](https://user-images.githubusercontent.com/99121615/221143112-966c79ad-b211-49cf-8e70-f6ca1910c554.png)

2. 게임 로직 구현
- GameStart UnityEvent 변수 생성 
- 게임 시작 시, GameStartEvent.Invoke() 를 통해 이벤트 관리.
- 새로운 정답 생성 , 게임 관련 변수 초기화 , 화면내 Text UI 초기화.
- 각종 버튼 리스너 콜백 함수 연결.
- 숫자를 4개 입력하면, 숫자 입력 버튼 활성화
- 활성화된 숫자 입력 버튼 클릭시, 판별하여 화면에 출력.

미구현
3. 스크롤뷰에 이전 입력 기록 추가 
