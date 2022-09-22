using Poker.Demo;
/// <summary>
/// 纸牌游戏程序启动类提供游戏的启动入口方法和统一显示错误的提示信息的方法。
/// </summary>
class Program
{

    static void Main(string[] args)
    {
        PorkerGameClient gameClient = new PorkerGameClient();
        Console.WriteLine("取纸牌游戏开始......");
        Console.WriteLine("$$$$$$$$$$$$$$$$ 玩游戏的命令格式为：行号-纸牌数目,如：3-2表示在第3行拿走2根纸牌 $$$$$$$$$$$$$$$$");
        Console.WriteLine("$$$$$$$$$$$$$$$$ 撤回到某一轮游戏的命令格式为：b-轮号,如：b-2表示撤回到第2轮游戏 $$$$$$$$$$$$$$$$\n");        


        while (true)
        {
            Console.WriteLine(gameClient.ToString());
            Console.WriteLine($"游戏第{gameClient.CurrentSteps}轮。{gameClient.CurrentPlayer.Name}，请选择输入需要执行的命令。");
            Console.WriteLine("输入拿走某一行纸牌的命令的格式为：行号-纸牌数目（行号取值范围是1到3，纸牌数目的取值范围是1到7）。");
            Console.WriteLine("输入撤回到某一轮游戏的命令格式为：b-轮号（轮号必须为大于0的整数）。");
            var readStr = Console.ReadLine();
            
            if (string.IsNullOrWhiteSpace(readStr))
            {
                ShowErrorMessage();
                continue;
            }

            var readChars = readStr.Split('-');
            if (readChars.Length != 2)
            {
                ShowErrorMessage();
                continue;
            }

            int position = 0;
            int number = 0;

            //验证输入的撤回游戏命令格式是否正确以及是否成功撤回到某一轮
            if (readChars[0].Equals("b", StringComparison.OrdinalIgnoreCase))
            {
                if(int.TryParse(readChars[1], out number)){
                    if (number < 1) {
                        Console.WriteLine("撤回到某一轮游戏的轮号必须为大于0的整数！ ");
                        continue; 
                    }
                    if(gameClient.GoBackTo(number))
                    {
                        Console.WriteLine($"游戏撤回到第{number}轮成功！ ");
                        continue;
                    }
                }
            }
            else
            {
                //验证输入的拿走某一行纸牌的命令的格式是否正确
                if (!int.TryParse(readChars[0], out position) || !int.TryParse(readChars[1], out number))
                {
                    ShowErrorMessage();
                    continue;
                }
                if (position < 1 || position > 3 || number < 1 || number > 7)
                {
                    ShowErrorMessage();
                    continue;
                }
                gameClient.Start(position, number);
            }
        }
    }

    /// <summary>
    /// 统一显示错误的提示信息
    /// </summary>
    static void ShowErrorMessage()
    {
        Console.WriteLine("输入的命令格式不正确！请参照格式“行号-纸牌数目”或者“b-轮号”！行号取值范围是1到3，纸牌数目的取值范围是1到7，轮号必须为大于0的整数。\n");
    }
}