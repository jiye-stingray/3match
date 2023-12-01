using UnityEngine;

public static class ItemDatabase 
{
    public static Item[] Items { get; private set; }

   [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)] private static void Initialize() => Items = Resources.LoadAll<Item>("Items/");       // 게임이 시작되면 자동으로 실행되는 함수
}
