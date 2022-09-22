namespace Poker.Core
{
    /// <summary>
    /// 15个纸牌布局排列类
    /// </summary>
    public class PokerLayout
    {
        /// <summary>
        /// 初始化3行（15个）纸牌的布局
        /// </summary>
        /// <returns></returns>
        public static List<PokerContainer> GetPokerLayout()
        {
            List<PokerContainer> layout = new List<PokerContainer>();
            layout.Add(new PokerContainer()
            {
                Position = 1,
                Number = 3
            });
            layout.Add(new PokerContainer
            {
                Position = 2,
                Number = 5
            });
            layout.Add(new PokerContainer
            {
                Position = 3,
                Number = 7
            });
            return layout;
        }
    }
}