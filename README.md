# PokerGame
This is a simple demo for two players to get arbitrary number of pokers on arbitrary row where there may contain three pokers, five pokers or seven pokers on some round.

拿纸牌游戏的解决思路如下：
1、建立一个基于.NET6的PokerGame解决方案，该方案包含两个工程Poker.Core和Poker.Demo。
2、Poker.Core解决以下问题：
     2.1、记录拿纸牌游戏的玩家信息（通过类Player实现）；
     2.2、记录每一行纸牌的信息（通过类PokerContainer实现）；
     2.3、初始化15个纸牌排成三行的游戏布局（通过类PokerLayout实现）；
     2.4、记录在纸牌游戏中某一轮某个玩家在某一行拿走的纸牌数量（通过类StepsRecorder实现）；
     2.5、保存游戏玩家玩游戏记录（通过类GameRecordManager实现）；
     2.6、格式化输出当前纸牌的布局提示信息、控制玩家每一轮在某行拿纸牌的数量、在游戏过程中撤回游戏到某一轮、判断游戏是否已结束（通过类PokerGameController实现）。
3、Poker.Demo解决以下问题：
     3.1、初始化两个拿纸牌游戏的玩家“1号玩家”和“2号玩家”并指定1号玩家为当前玩家， 初始化当前游戏为第1轮，提供格式化输出当前纸牌的布局提示信息的方法、开始游戏的方法、撤回游戏到某一轮的方法、重新开始游戏的方法（通过类PorkerGameClient实现）；
     3.2、纸牌游戏程序启动类提供游戏的启动入口方法和统一显示错误的提示信息的方法（通过类Program实现）。
