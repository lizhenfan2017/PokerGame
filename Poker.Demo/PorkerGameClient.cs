using Poker.Core;

namespace Poker.Demo
{
    /// <summary>
    /// 初始化两个拿纸牌游戏的玩家“1号玩家”和“2号玩家”并指定1号玩家为当前玩家；
    /// 初始化当前游戏为第1轮；
    /// 提供格式化输出当前纸牌的布局提示信息的方法、开始游戏的方法、撤回游戏到某一轮的方法、重新开始游戏的方法
    /// </summary>
    public class PorkerGameClient
    {
        private readonly PokerPlayer _bluePlayer;
        private readonly PokerPlayer _redPlayer;
        private PokerGameController _gameControl;

        public PorkerGameClient()
        {
            this._bluePlayer = new PokerPlayer
            {
                Id = 1,
                Name = "1号玩家"
            };
            this._redPlayer = new PokerPlayer
            {
                Id = 2,
                Name = "2号玩家"
            };
            this._gameControl = new PokerGameController();
            this.CurrentPlayer = _bluePlayer;
        }

        /// <summary>
        /// 当前第几轮
        /// </summary>
        public int CurrentSteps { get; private set; } = 1;


        /// <summary>
        /// 当前玩家
        /// </summary>
        public PokerPlayer CurrentPlayer { get; private set; }


        /// <summary>
        /// 取纸牌游戏开始的入口方法
        /// </summary>
        /// <param name="position">游戏玩家取纸牌的行号</param>
        /// <param name="toGetNumber">游戏玩家取纸牌的数量</param>
        public void Start(int position, int toGetNumber)
        {
            var result = _gameControl.Play(this.CurrentPlayer, this.CurrentSteps, position, toGetNumber);
            if (result)
            {
                if (_gameControl.IsGameOver())
                {
                    this.Reset();
                    Console.WriteLine($"$$$$$$$$$$$$$$$$ 纸牌已拿完，游戏结束！【{this.CurrentPlayer.Name}】输了，下次努力哟！游戏即将重新开始。$$$$$$$$$$$$$$$$");
                    return;
                }

                this.CurrentPlayer = (this.CurrentPlayer == this._bluePlayer) ? this._redPlayer : this._bluePlayer;

                if (CurrentPlayer == _bluePlayer)
                {
                   this.CurrentSteps += 1;
                }
                    
            }
        }

        /// <summary>
        /// 撤回游戏到某一轮
        /// </summary>
        /// <param name="steps"></param>
        public bool GoBackTo(int steps)
        {
            var stepsRecorder = _gameControl.GoBackTo(steps);
            if (stepsRecorder != null)
            {
                this.CurrentPlayer = stepsRecorder.Player!;
                this.CurrentSteps = stepsRecorder.Steps;
                return true;
            }
            Console.WriteLine("撤回失败，没有可撤回的步数！");
            return false;
        }


        /// <summary>
        /// 重置游戏
        /// </summary>
        private void Reset()
        {
            this._gameControl = new PokerGameController();
            this.CurrentSteps = 1;
            GameRecordManager.Clear();
        }

        public override string ToString()
        {
            return this._gameControl.ToString();
        }
    }
}