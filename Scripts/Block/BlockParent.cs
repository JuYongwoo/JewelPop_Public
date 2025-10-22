using JYW.JewelPop.StageScene;
using UnityEngine;

namespace JYW.JewelPop.Block
{

    public class BlockParent : MonoBehaviour
    {

        private YX yx;

        public void SetGridPositionYX(YX yx) //����Ƽ ���� ��ġ�� �ƴ� �׸��� ���� x,y ��ǥ
        {
            this.yx = yx;

        }

        public YX GetGridPositionYX() // //
        {
            return yx;
        }


        public void SetUnityPositionYX((float y, float x) yx)
        {
            gameObject.transform.localPosition = new Vector2(yx.x, yx.y);
        }
    }
}