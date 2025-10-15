using UnityEngine;

public abstract class BlockChild : MonoBehaviour, PooledObejct
{

    [HideInInspector]
    private BlockPrefabs blockType; //GameManage���� ������Ʈ ������ �Բ� JSON���� �޾ƿ� Ÿ���� ����

    public void PoolStart() { }

    public void PoolDestroy() { }
    
    public void SetBlockType(BlockPrefabs blockType)
    {
        this.blockType = blockType;
    }
    public BlockPrefabs GetBlockType()
    {
        return blockType;
    }


}
