using UnityEngine;
using UnityEngine.UI;

public class StageScene : MonoBehaviour
{
    public static StageScene instance;

    public MapManager mapManager = new MapManager();
    public LevelManager<JSONVars> levelManager = new LevelManager<JSONVars>();




    private bool clicking = false;
    private GameObject startBlock = null;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        

    }
    private void Start()
    {


        //JYW
        //Ÿ��Ʋ ������ AppManager�� �̹� �ʱ�ȭ �Ǿ��־�� �ϴµ� ���� Title �� ����
        //������ ������ StageManager�� Start���� �ʱ�ȭ

        AppManager.instance.actionManager.StageSceneInputController = () =>
        {
            if (AppManager.instance.actionManager.getIsInMotion() || AppManager.instance.actionManager.getIsBoardChanged()) return; //�̵� �߿��� �Է� ����
            if (Input.GetMouseButtonDown(0))
            {
                Click();

            }
            else if (Input.GetMouseButtonUp(0))
            {
                UnClick();
            }

            if (clicking)
            {
                HandleClicking();

            }
        };

        levelManager.Init(AppManager.instance.resourceManager.levelDatasJSONHandle.Result.text); //���� ���������� ���� �´� ���� ������ �ε�(������ Level_1��)// dict Ű���� �������� �޾ƿ��� ������
        mapManager.Init(levelManager.currentLevel);
        
        
        
        Time.timeScale = 1f; //�������� ����

    }


    private void Update()
    {
        mapManager.OnUpdate();

    }


    private void Click()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        LayerMask mask = LayerMask.GetMask("Block");

        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, 100, mask);
        if (hit.collider != null)
        {
            startBlock = hit.collider.gameObject;
            clicking = true;

        }

        if (startBlock == null) UnClick();
    }

    private void UnClick()
    {
        if (!clicking) return; //�̹� �� ��ȯ�ؼ� ������ �ʿ� X

        startBlock = null;
        clicking = false;

    }

    private void HandleClicking()
    {
        if (startBlock == null)
        {
            UnClick();
            return;
        }


        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        LayerMask mask = LayerMask.GetMask("Block");

        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, 100, mask);
        if (hit.collider != null)
        {

            if (hit.collider.gameObject != startBlock)
            {
                AppManager.instance.actionManager.inputBlockChangeAction(startBlock, hit.collider.gameObject);
                UnClick();
            }
        }


    }
}
