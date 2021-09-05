# State Pattern 状态模式

## Usage 用途

## Definition 定义

允许对象在内部状态改变时改变它的行为。需要把状态封装成为独立的类，并把动作委托到当前状态的对象。

![state](https://github.com/JanHoChoi/Unity-Design-Pattern/blob/master/Pictures/state.gif)

## Element 要素



## Extension 引申

- 并发状态机

	比如角色的移动相关可以作为一个状态机、主角携带的武器可以作为第二个状态机，主角同时持有两个状态机也ok。

- 层次状态机

	利用继承，子状态继承父状态。子状态不处理的操作可以沿着继承类丢给父状态处理。(TBD，试一下middleclass能不能这么操作)