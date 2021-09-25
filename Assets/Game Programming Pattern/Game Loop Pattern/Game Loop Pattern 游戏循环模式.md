# Game Loop Pattern 游戏循环模式

## Usage 用途

- 游戏引擎中，已经使用了这个模式，引擎提供一些接口，让我们在不同时机执行不同行为。

## Element 元素

- FPS 一秒内渲染的次数
- Game Speed 一秒内更新游戏逻辑状态的次数

## Normal Style 常见方式

### 最简单的游戏循环

```
while(true)
{
	processInput();
	update();
	render();
}
```

1. 很简单。能跑多快跑多快；
2. 如果设备卡，则游戏速度慢；设备快，则游戏速度也快。没法玩；

### FPS依赖于GameSpeed

```
while(true)
{
	double start = getCurTime();
	processInput();
	update();
	render();
	sleep(start + MS_PER_FRAME - getCurTime());
}
```

1. 很简单。每MS_PER_FRAME的时间跑一个循环；
2. 省电，因为有sleep；
3. 当设备速度很快时，不会遇到错误。但是浪费性能，比如明明能开到300fps，但是却限制到了30fps。
4. 当设备速度很慢时，游戏也变慢了，导致没法玩。

### GameSpeed依赖于FPS

```
double lastTime = getCurTime();
while(true)
{
	double currecnt = getCurTime();
	double elapsed = current - lastTime;
	processInput();
	update(elapsed);
	render();
	lastTime = current;
}
```

