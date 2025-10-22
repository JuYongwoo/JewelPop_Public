using UnityEngine;
using System;
using JYW.JewelPop.JSON;
using JYW.JewelPop.Managers;

namespace JYW.JewelPop.StageScene
{
    public class LevelManager<T> where T : JSONVars //������ ���� ���� ������ ����
    {


        public GoalType goalType = GoalType.Joker; //TODO ���� Ȯ�� �� / JYW ��ǥ Ÿ�Ը��� ���� ��ǥ �ٸ��� ����


        private int currentStage = 0;
        private int currentScore = 0;
        private int goalScore = 0;

        public T currentLevel;

        public void OnAwake()
        {
            GameManager.instance.eventManager.DeltaScoreEvent -= DeltaScore;
            GameManager.instance.eventManager.DeltaScoreEvent += DeltaScore;
        }

        public void OnStart(string json)
        {

            //JSON ���� ���� ������ �ʱ�ȭ
            currentLevel = JsonUtility.FromJson<T>(json);
            goalScore = currentLevel.GoalScore;
            goalType = Enum.Parse<GoalType>(currentLevel.GoalType);
            currentStage = currentLevel.Stage;
            currentScore = 0;

            //UI �ʱ�ȭ
            GameManager.instance.eventManager.OnSetCurrentStageUI(currentStage);
            GameManager.instance.eventManager.OnSetScoreUI(currentScore, goalScore);
            GameManager.instance.eventManager.OnPlayAudioClip(GameManager.instance.resourceManager.gameSoundClipsHandles[Sounds.BGM1].Result, 0.25f, true);
        }

        public void OnDestroy()
        {
            GameManager.instance.eventManager.DeltaScoreEvent -= DeltaScore;
        }

        private void DeltaScore(int delta) //���� ������ �ݵ�� �̰��� ���
        {
            currentScore += delta;
            GameManager.instance.eventManager.OnSetScoreUI(currentScore, goalScore);


            //���� ���� ��
            if (currentScore >= goalScore)
            {
                //���� Ŭ����
                GameClear();
            }

        }


        private void GameClear()
        {
            Time.timeScale = 0f;
            GameManager.instance.eventManager.OnShowResultPopup();
            GameManager.instance.eventManager.OnStopAudioClip(GameManager.instance.resourceManager.gameSoundClipsHandles[Sounds.BGM1].Result);
            GameManager.instance.eventManager.OnPlayAudioClip(GameManager.instance.resourceManager.gameSoundClipsHandles[Sounds.Victory].Result, 0.25f, false);
        }


    }

}