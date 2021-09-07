# State Pattern 状态模式

## Usage 用途

## Definition 定义

允许对象在内部状态改变时改变它的行为。需要把状态封装成为独立的类，并把动作委托到当前状态的对象。

![state](https://github.com/JanHoChoi/Unity-Design-Pattern/blob/master/Pictures/state.gif)

## Element 要素

### Context 上下文

上下文持有一些内部状态。Client向Context提出请求，不需要了解Context内部在做什么。

### State 状态

State接口定义了所有具体状态的共同接口，任何状态都实现相同的接口，这样一来，状态之间可以互相替换。

### Concrete State 具体状态

具体状态处理来自Context的请求。每个Concrete State都提供了它对请求的实现。所以当Context改变状态时，对应的行为也改变。

## Extension 引申

- 并发状态机

	比如角色的移动相关可以作为一个状态机、主角携带的武器可以作为第二个状态机，主角同时持有两个状态机也ok。

- 层次状态机

	利用继承，子状态继承父状态。子状态不处理的操作可以沿着继承类丢给父状态处理（使用middleclass的话，可以参考cbg写的battleState的做法）。
	
- 下推状态机

	利用栈Stack，存储了状态机的历史状态。当前的状态永远在栈顶。对这个栈可以进行push和pop操作。