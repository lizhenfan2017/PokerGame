namespace Poker.Core
{
    /// <summary>
    /// 保存游戏玩家玩游戏记录的管理类
    /// </summary>
    public static class GameRecordManager
    {
        private readonly static Stack<StepsRecorder> _gameRecordStack;
        static GameRecordManager()
        {
            _gameRecordStack = new Stack<StepsRecorder>();
        }

        /// <summary>
        /// 记录某一轮游戏某个Player拿走的纸牌信息
        /// </summary>
        /// <param name="recorder"></param>
        public static void Add(StepsRecorder recorder)
        {
            _gameRecordStack.Push(recorder);
        }

        /// <summary>
        /// 清空所有的游戏记录
        /// </summary>
        public static void Clear()
        {
            _gameRecordStack.Clear();
        }

        /// <summary>
        /// 取出所有的游戏记录
        /// </summary>
        /// <param name="steps"></param>
        /// <returns></returns>
        public static List<StepsRecorder> Get(int steps)
        {
            List<StepsRecorder> list = new List<StepsRecorder>();
            _Dequeue(list, steps);
            return list;
        }


        private static void _Dequeue(List<StepsRecorder> list, int steps)
        {
            if (steps < 1)
            {
               return;
            }                

            if (_gameRecordStack.Any(m => m.Steps >= steps))
            {
                var item = _gameRecordStack.Pop();
                list.Add(item);
                _Dequeue(list, steps);
            }
        }
    }
}