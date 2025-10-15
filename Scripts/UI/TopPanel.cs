using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TopPanel : MonoBehaviour
{
    private enum TopPanelObjects
    {
        TopCurrentScoreText,
        TopGoalBodyText,
        TopCurrentStageBodyText,
        TopCurrentScoreFrontImg
    }

    Dictionary<TopPanelObjects, GameObject> topPanelObjs = new Dictionary<TopPanelObjects, GameObject>();

    private void Awake()
    {
        topPanelObjs = Util.MapEnumChildObjects<TopPanelObjects, GameObject>(this.gameObject);
        GameManager.instance.actionManager.SetScoreUIEvent -= SetScore;
        GameManager.instance.actionManager.SetScoreUIEvent += SetScore;
        GameManager.instance.actionManager.SetCurrentStageUIEvent -= SetCurrentStage;
        GameManager.instance.actionManager.SetCurrentStageUIEvent += SetCurrentStage;
    }

    private void Start()
    {
        GameManager.instance.actionManager.GetJokerGoalTranformEvent -= GetJokerGoalTranform;
        GameManager.instance.actionManager.GetJokerGoalTranformEvent += GetJokerGoalTranform;

        Image image = topPanelObjs[TopPanelObjects.TopCurrentScoreFrontImg].GetComponent<Image>();
        image.fillMethod = Image.FillMethod.Vertical;
        image.fillOrigin = 0; // 0 = �ؿ��� ����, 1 = ������ �Ʒ���

    }

    private void OnDestroy()
    {
        GameManager.instance.actionManager.SetScoreUIEvent -= SetScore;
        GameManager.instance.actionManager.SetCurrentStageUIEvent -= SetCurrentStage;
        GameManager.instance.actionManager.GetJokerGoalTranformEvent -= GetJokerGoalTranform;
    }

    private Transform GetJokerGoalTranform()
    {
        topPanelObjs.TryGetValue(TopPanelObjects.TopCurrentScoreText, out var scoreText);
        return scoreText.transform;
    }

    private void SetCurrentStage(int stage)
    {
        topPanelObjs.TryGetValue(TopPanelObjects.TopCurrentStageBodyText, out var bodyText);
        bodyText.GetComponent<Text>().text = stage.ToString();
    }

    private void SetScore(int currentScore, int goalScore)
    {

        topPanelObjs.TryGetValue(TopPanelObjects.TopCurrentScoreText, out var scoreText);
        topPanelObjs.TryGetValue(TopPanelObjects.TopGoalBodyText, out var bodyText);
        topPanelObjs.TryGetValue(TopPanelObjects.TopCurrentScoreFrontImg, out var frontImg);

        scoreText.GetComponent<Text>().text = currentScore.ToString();
        bodyText.GetComponent<Text>().text = (goalScore - currentScore) >= 0 ? (goalScore - currentScore).ToString() : "0";
        frontImg.GetComponent<Image>().fillAmount = Mathf.Clamp01((float)currentScore / (float)goalScore);
    }

}
