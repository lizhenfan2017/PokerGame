using System.Text;

namespace Poker.Core
{
    /// <summary>
    /// 拿纸牌游戏的具体操作类
    /// 格式化输出当前纸牌的布局提示信息、控制玩家每一轮在某行拿纸牌的数量、在游戏过程中撤回游戏到某一轮、判断游戏是否已结束
    /// </summary>
    public class PokerGameController
    {
        private const string pokerSign = "$";

        /// <summary>
        /// 定义15根纸牌的布局变量_layout。
        /// </summary>
        private readonly List<PokerContainer> _layout;

        public PokerGameController()
        {
            _layout = PokerLayout.GetPokerLayout();
        }


        /// <summary>
        /// 拿纸牌的具体操作
        /// </summary>
        public bool Play(PokerPlayer player, int steps, int position, int toGetNumber)
        {
            var pokerContainer = _layout.FirstOrDefault(s => s.Position == position);
            if (pokerContainer == null)
            {
                Console.WriteLine("行号输入有误！行号请在1到3之间取值，请重新输入！\n");
                return false;
            }
            if (pokerContainer.Number == 0)
            {
                Console.WriteLine($"行号输入有误！第{position}行目前没有纸牌，请选择有纸牌的行号重新输入！\n");
                return false;
            }

            if (pokerContainer.Number < toGetNumber)
            {
                Console.WriteLine($"第{position}行目前只有{pokerContainer.Number}根纸牌。{player.Name}，请重新输入小于或等于{pokerContainer.Number}的纸牌数。\n");
                return false;
            }

            pokerContainer.Number -= toGetNumber;

            StepsRecorder srmem = new StepsRecorder
            {
                Player = player,
                Position = position,
                GotPokerNumbers = toGetNumber,
                Steps = steps
            };
            GameRecordManager.Add(srmem);
            return true;
        }


        /// <summary>
        /// 撤回游戏到某一轮
        /// </summary>
        /// <param name="steps"></param>
        /// <returns></returns>
        public StepsRecorder GoBackTo(int steps)
        {
            var list = GameRecordManager.Get(steps);
            StepsRecorder last = null!;
            if (list.Count > 0)
            {
                foreach (var item in list)
                {
                    var pokerContainer = _layout.FirstOrDefault(s => s.Position == item.Position);
                    if (pokerContainer != null)
                    {
                        //恢复移除的数量
                        pokerContainer.Number += item.GotPokerNumbers;
                    }
                    last = item;
                }
            }
            return last;
        }


        /// <summary>
        /// 判断游戏是否已结束。
        /// </summary>
        /// <returns>当前Player是否输了</returns>
        public bool IsGameOver()
        {
            return !_layout.Any(m => m.Number > 0);
        }


        /// <summary>
        /// 格式化输出当前纸牌的布局提示信息
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            if(_layout.Count > 0)
            {
                builder.Append("\n纸牌的排列如下：\n");
            }
            foreach (var item in _layout)
            {
                if (item.Number > 0)
                {
                    builder.Append($"第{item.Position}行：");
                    for (int i = 0; i < item.Number; i++)
                    {
                        builder.Append(pokerSign);
                    }
                    builder.Append("\n");
                }
            }
            return builder.ToString();
        }
    }
}