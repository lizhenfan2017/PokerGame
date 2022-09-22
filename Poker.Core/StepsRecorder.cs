namespace Poker.Core
{
    /// <summary>
    /// 记录在纸牌游戏中某一轮某个玩家在某一行拿走的纸牌数量
    /// </summary>
    public class StepsRecorder
    {
        /// <summary>
        /// 记录游戏处于第几轮
        /// </summary>
        public int Steps { get; set; }

        /// <summary>
        /// Player的信息
        /// </summary>
        public PokerPlayer? Player { get; set; }


        /// <summary>
        /// Player拿走纸牌的位置（哪一行）
        /// </summary>
        public int Position { get; set; }


        /// <summary>
        /// Player拿走纸牌的个数
        /// </summary>
        public int GotPokerNumbers { get; set; }

    }
}