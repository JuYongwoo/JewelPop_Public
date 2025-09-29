using UnityEngine;

public abstract class BlockChild : MonoBehaviour
{

    [HideInInspector]
    private BlockPrefabs blockType; //GameManage���� ������Ʈ ������ �Բ� JSON���� �޾ƿ� Ÿ���� ����

    public void SetBlockType(BlockPrefabs blockType)
    {
        this.blockType = blockType;
    }
    public BlockPrefabs GetBlockType()
    {
        return blockType;
    }


}
