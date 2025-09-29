# JewelPop

## 🎮 게임 방식

- **드래그로 스왑**: 마우스를 눌러 이웃한 보석과 위치를 교환합니다.
- **매치 규칙**: 같은 종류의 보석 **3개 이상** 연속으로 맞추면 터집니다.
- **점수 보너스**: **깃발 주변**에서 매치가 일어나면 점수를 획득합니다.
- **승패 조건**
  - **승리**: 제한 시간 내 **목표 점수** 달성
  - **패배**: 제한 시간 내 목표 점수 미달성

---

## 🏗 아키텍처 요약

- **이벤트 허브(ActionManager)** 로 입력/UI/도메인 간 결합도 최소화
- **인터페이스 중심 블록 모델**: 이동/파괴/특수 효과를 인터페이스로 분리
- **Level/Map Manager** 가 보드/목표/타이머를 통합 관리
- **ScriptableObject** 로 게임 모드/오브젝트 정의(데이터 드리븐)

---

## 🗂 폴더 구조 (Scripts)

```
Scripts
├── Block
│   ├── BlockParent.cs
│   ├── BlockChild.cs
│   ├── BlockChild/IMoveAndDesroyable.cs
│   ├── BlockChild/ISpecial.cs
│   ├── BlockChild/MoveAndDesroyable/CommonBlock.cs
│   └── BlockChild/Special/JokerBlock.cs
│
├── Camera/CameraObject.cs
│
├── FX
│   ├── BlockCrushFX.cs
│   └── JokerFX.cs
│
├── JSON/LevelData.cs
│
├── Managers/AppManager
│   ├── ActionManager.cs
│   ├── InputManager.cs
│   ├── ResourceManager.cs
│   └── SoundManager.cs
│
├── Scene/StageScene
│   ├── LevelManager.cs
│   └── MapManager.cs
│   └── StageScene.cs
│
├── ScriptableObjects
│   ├── GameModeSO.cs
│   └── ObjectsSO.cs
│
├── UI
│   ├── BasePopupEffect.cs
│   ├── ResultPopupPanel.cs
│   ├── TitlePanel.cs
│   └── TopPanel.cs
│
└── Utils/Util.cs
```

---

