using UnityEngine;

public static class ItemDatabase 
{
    public static Item[] Items { get; private set; }

   [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)] private static void Initialize() => Resources.LoadAll<Item>("Items/");       // ������ ���۵Ǹ� �ڵ����� ����Ǵ� �Լ�
}
