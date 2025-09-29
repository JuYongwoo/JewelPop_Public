using System.Collections;
using UnityEngine;



public class BlockCrushFX : MonoBehaviour
{


    private void Start() //�Ϲ� ���� �ı� ���
    {
        AppManager.instance.soundManager.PlaySound(Sounds.Block3SFX, 0.5f, false);
        StartCoroutine(DestroyAfterBlockCrushMotion());
    }

    private IEnumerator DestroyAfterBlockCrushMotion()
    {
        yield return new WaitForSeconds(0.8f);
        Destroy(gameObject);

    }

}