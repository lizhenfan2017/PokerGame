namespace Poker.Core
{
    /// <summary>
    /// 记录每一行纸牌的信息
    /// </summary>
    public class PokerContainer
    {
        /// <summary>
        /// 纸牌所在的行数（1—3）
        /// </summary>
        public int Position { get; set; }


        /// <summary>
        /// 当前行数的纸牌数量
        /// </summary>
        public int Number { get; set; }

    }
}