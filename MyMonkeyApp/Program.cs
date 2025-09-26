
using MyMonkeyApp;

class Program
{
	static readonly string[] asciiArts = new[]
	{
		@"  _/\___/\_",
		@" ( o   o )",
		@"  (  =^=  )",
		@"  ("")___("")",
		@"   /     \",
		@"  (|     |)"
	};

	static void ShowAsciiArt()
	{
		var rand = new Random();
		var art = asciiArts[rand.Next(asciiArts.Length)];
		Console.WriteLine(art);
	}

	static async Task Main(string[] args)
	{
		Console.WriteLine("🐵 Welcome to Monkey App! 🐵");
		ShowAsciiArt();
		Console.WriteLine();

		await MonkeyHelper.LoadMonkeysAsync();

		while (true)
		{
			Console.WriteLine("\n메뉴를 선택하세요:");
			Console.WriteLine("1. 모든 원숭이 목록 보기");
			Console.WriteLine("2. 이름으로 원숭이 정보 조회");
			Console.WriteLine("3. 랜덤 원숭이 보기");
			Console.WriteLine("4. 종료");
			Console.Write("선택: ");
			var input = Console.ReadLine();

			switch (input)
			{
				case "1":
					Console.WriteLine("\n[모든 원숭이 목록]");
					foreach (var m in MonkeyHelper.GetMonkeys())
					{
						Console.WriteLine($"- {m.Name} | {m.Location} | 개체수: {m.Population}");
					}
					ShowAsciiArt();
					break;
				case "2":
					Console.Write("원숭이 이름을 입력하세요: ");
					var name = Console.ReadLine();
					var monkey = MonkeyHelper.GetMonkeyByName(name ?? "");
					if (monkey != null)
					{
						Console.WriteLine($"\n이름: {monkey.Name}\n서식지: {monkey.Location}\n개체수: {monkey.Population}\n설명: {monkey.Details}");
					}
					else
					{
						Console.WriteLine("해당 이름의 원숭이를 찾을 수 없습니다.");
					}
					ShowAsciiArt();
					break;
				case "3":
					var randomMonkey = MonkeyHelper.GetRandomMonkey();
					if (randomMonkey != null)
					{
						Console.WriteLine($"\n[랜덤 원숭이]\n이름: {randomMonkey.Name}\n서식지: {randomMonkey.Location}\n개체수: {randomMonkey.Population}\n설명: {randomMonkey.Details}");
						Console.WriteLine($"(랜덤 선택 횟수: {MonkeyHelper.GetRandomPickCount()})");
					}
					else
					{
						Console.WriteLine("원숭이 데이터가 없습니다.");
					}
					ShowAsciiArt();
					break;
				case "4":
					Console.WriteLine("앱을 종료합니다. 안녕! 🐒");
					return;
				default:
					Console.WriteLine("잘못된 입력입니다. 다시 선택하세요.");
					break;
			}
		}
	}
}
