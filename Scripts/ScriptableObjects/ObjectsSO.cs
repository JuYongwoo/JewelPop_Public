using UnityEngine;

[CreateAssetMenu(fileName = "NewObjects", menuName = "Game/Objects")]
public class ObjectsSO : ScriptableObject
{
    [SerializeField] private Object[] _objects;

    public int Size => _objects != null ? _objects.Length : 0;

    // Ư�� Ÿ������ ��ȯ�ؼ� ������ //�Ź� ĳ���� ����
    public T[] GetObjects<T>() where T : Object
    {
        T[] result = new T[_objects.Length];
        for (int i = 0; i < _objects.Length; i++)
        {
            result[i] = _objects[i] as T;
        }
        return result;
    }
    public T GetObject<T>(int index) where T : Object
    {
        T result = _objects[index] as T;
        return result;
    }
}
