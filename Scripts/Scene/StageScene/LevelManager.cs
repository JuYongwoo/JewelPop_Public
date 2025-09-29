using UnityEngine;
using System;

public class LevelManager<T> where T : JSONVars //������ ���� ���� ������ ����
{
    public enum GoalType
    {
        Joker
    }

    GoalType goalType = GoalType.Joker; //TODO ���� Ȯ�� �� / JYW ��ǥ Ÿ�Ը��� ���� ��ǥ �ٸ��� ����
    
    
    private int currentStage = 0;

    private int currentScore = 0;
    private int goalScore = 0;

    public T currentLevel;

    public void Init(string json)
    {

        //JSON ���� ���� ������ �ʱ�ȭ
        currentLevel = JsonUtility.FromJson<T>(json);
        goalScore = currentLevel.goalScore;
        goalType = Enum.Parse<GoalType>(currentLevel.goalType);
        currentStage = currentLevel.stage;
        currentScore = 0;

        //UI �ʱ�ȭ
        ActionManager.setCurrentStageUI(currentStage);
        ActionManager.setScoreUI(currentScore, goalScore);
        AppManager.instance.soundManager.PlaySound(Sounds.BGM1, 0.25f, true);
    }


    public void deltaScore(int delta) //���� ������ �ݵ�� �̰��� ���
    {
        currentScore += delta;
        ActionManager.setScoreUI(currentScore, goalScore);


        //���� ���� ��
        if (currentScore >= goalScore)
        {
            //���� Ŭ����
            GameClear();
        }

    }

    public int getScore()
    {
        return currentScore;
    }

    private void GameClear()
    {
        Time.timeScale = 0f;
        AppManager.instance.actionManager.showResultPopup();
        AppManager.instance.soundManager.StopSound(Sounds.BGM1);
        AppManager.instance.soundManager.PlaySound(Sounds.Victory, 0.25f, false);
    }


}

