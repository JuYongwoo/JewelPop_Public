using UnityEngine;
public interface IMoveAndDestroyable //�����̰� ���� �� �ִ� ������ �ݵ�� �� �������̽��� ���
{

    public void DestroySelf();// ���������� �ı� ����� �ٸ��Ƿ� �ڽĿ��� ���� ����ȭ
    public void Move(Transform targetParent);
    public void MoveAndBack(Transform targetParent);
    public void Turnoff();

}
