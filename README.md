# BeggerLife
 BeggerLife는 거지키우기를 모작한 게임입니다.


# BeggerLife 게임 테스트시 필독
Gamemanager 스크립트의
Current Money(현재 보유하고 있는 돈)
은 BigInteger로 되어있어서 inspector에서 수정이 불가하기 때문에
코드 내부에서 수정하셔야 합니다.

기본 매니저들 

public static UIManager
public static GameManager
public static SoundManager
는 [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
를 통해 게임 시작 전에 미리 호출되어 Managers 하단에
Scene이 변경되어도 파괴되지 않도록 코드를 구현했습니다.

기본 테스트를 위해 시작 돈을 1000경, 클릭시, 초당 돈을 1경으로 설정했습니다.
(값 변경 시 Game창에 적용, 0원으로 변경 시 0원으로 시작)



 # Scene구성
 Scene 구성은
 
 1. SeoulScene
 2. EarthScene
 3. SolarSystemScene
 4. GalaxyScene
 5. SpaceScene
 6. MultiVersScene

으로 나뉘게 됩니다.



# 게임구성

게임 구성은 돈을 벌어서 MultiVerse를 사면 승리하게 되는 게임입니다.

돈을 버는 방법으로는
1. 1초마다 자동으로 오르는 돈을 이용해서 돈을 벌기
2. 화면을 클릭하여 돈을 벌기(안드로이드 또는 마우스 좌클릭)
이 있습니다.

돈을 버는 속도를 올릴 수 있는 방법이 있는데,
1. 일정 돈을 주고 거지 업글 탭에서 업그레이드를 하는 방법
2. 거지 고용을 통해 현재 초당/클릭당 돈의 계수를 곱하는 방법
3. 자산을 사서 초당/클릭당의 돈을 올리는 방법
4. 구매한 자산에서 돈을 회수해서 돈을 얻는 방법
5. 도박(?)하는 방법
이 있습니다.



# 구현 및 미구현 부분
***
구현부분
1. 거지업글
2. 거지고용
3. 도박하기
4. 자산구매(완벽히 구현되지 않았습니다.)
   >> 문제점 : 자산을 구매하면 구매한 자산 Scene으로 넘어가게 되는데
   >> 구매 이후 SoldOutImage가 원래 setactive true로 되야 하지만 Scene이 넘어가면서 초기화 되버리는 현상

5. 거지자산(프리팹은 구현되었으나 코드상 구현이 미숙)
   >> seoulText.text = Managers.GameManager.FormatMoney((Managers.GameManager.moneyPerSec * new BigInteger(0.1f)));
earthText.text = Managers.GameManager.FormatMoney((Managers.GameManager.moneyPerSec * new BigInteger(0.2f)));
solarSystemText.text = Managers.GameManager.FormatMoney((Managers.GameManager.moneyPerSec * new BigInteger(0.3f)));
   >> 를 통해 현재 초당 증가하는 돈에 일정 배율만큼 Text에 올라가게 할 계획이었으나
   >> MoneyPerSec까지는 정상적으로 입력되었지만 곱하고 나니 0원이 되버려서 이후 구현이 힘들어짐.
   >> 버튼을 클릭 시 돈이 회수가 되게 하는 코드를 작성했는데
   >> 조건문에 SoldOutImage가 activeself일때만 돈을 회수가능하게 했지만 4번의 Scene이 넘어가면서 SoldOutImage가
   >> 초기화 되버리는 현상때문에 회수가 불가해지는 현상 발생.

미구현 부분
저장부분
위의 기능을 구현하다가 못했습니다.

설정에 들어가서 사운드 조절 부분
진짜 시간이 부족해서 설정할 시간이 없었습니다.


