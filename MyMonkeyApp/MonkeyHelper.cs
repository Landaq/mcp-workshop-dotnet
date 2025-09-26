// MonkeyHelper.cs
// MyMonkeyApp 프로젝트의 원숭이 데이터 관리 및 헬퍼 클래스

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace MyMonkeyApp;

/// <summary>
/// Monkey 데이터 관리를 위한 정적 헬퍼 클래스
/// </summary>
public static class MonkeyHelper
{
    private static List<Monkey> monkeys = new();
    private static int randomPickCount = 0;

    /// <summary>
    /// MCP 서버에서 원숭이 데이터를 비동기로 가져옵니다.
    /// </summary>
    public static async Task LoadMonkeysAsync()
    {
        // MCP 서버 API 엔드포인트 예시
        var url = "https://raw.githubusercontent.com/jamesmontemagno/app-monkeys/master/MonkeysApp/monkeydata.json";
        using var httpClient = new HttpClient();
        var json = await httpClient.GetStringAsync(url);
        var data = JsonSerializer.Deserialize<List<Monkey>>(json);
        if (data != null)
            monkeys = data;
    }

    /// <summary>
    /// 모든 원숭이 목록을 반환합니다.
    /// </summary>
    public static List<Monkey> GetMonkeys() => monkeys;

    /// <summary>
    /// 이름으로 특정 원숭이 정보를 반환합니다.
    /// </summary>
    public static Monkey? GetMonkeyByName(string name)
    {
        return monkeys.FirstOrDefault(m => m.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
    }

    /// <summary>
    /// 랜덤 원숭이 하나를 반환하고, 호출 횟수를 기록합니다.
    /// </summary>
    public static Monkey? GetRandomMonkey()
    {
        if (monkeys.Count == 0) return null;
        randomPickCount++;
        var rand = new Random();
        return monkeys[rand.Next(monkeys.Count)];
    }

    /// <summary>
    /// 랜덤 원숭이 선택 횟수를 반환합니다.
    /// </summary>
    public static int GetRandomPickCount() => randomPickCount;
}
