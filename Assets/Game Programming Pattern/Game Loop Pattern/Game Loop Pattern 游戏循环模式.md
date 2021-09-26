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
3. 当设备速度很快时，不会遇到错误。但是浪费性能，比如明明能开到300fps，但是却限制到了30fps；
4. 当设备速度很慢时，游戏也变慢了，导致没法玩；

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

1. 无论设备速度快或慢，游戏都会不稳定。主要因为elapsed改变时，浮点数的计算带来的不精确；

### 固定GameSpeed和最大FPS

固定GameSpeed使游戏的物理引擎和AI都更加稳定。而渲染，不会被GameSpeed影响，并不关心上一次渲染距离这一次渲染过了多久。所以可以在渲染时作让步，释放设备的资源。这里的最大FPS是因为，1s内，最多update()了25次，所以fps看起来最多也就是25帧。

```
double previous = getCurTime();
double lag = 0.0;
while(true)
{
	double current = getCurTime();
	double elapsed = current - previous;
	previous = current;
	
	lag += elapsed;
	processInput();
	while(lag >= MS_PER_UPDATE)
	{
		update();
		lag -= MS_PER_UPDATE;
	}
	render();
}
```

1. 如果设备速度快，则浪费了性能，即使跑高帧率，render出来的画面却没有区别；
2. 如果设备速度慢，帧率会下降；但是如果速度慢到，一次update()比MS_PER_UPDATE还久，则游戏运行慢于现实；

### 固定GameSpeed和可变FPS

逻辑update可能一秒内跑25帧就够。在兼顾逻辑的同时，我们想要让画面更流畅。

```
double previous = getCurTime();
double lag = 0.0;
while(true)
{
	double current = getCurTime();
	double elapsed = current - previous;
	previous = current;
	
	lag += elapsed;
	processInput();
	while(lag >= MS_PER_UPDATE)
	{
		update();
		lag -= MS_PER_UPDATE;
	}
	double interpolation = lag / MS_PER_UPDATE;
	render(interpolation);
}
```

1. 如果设备速度快，此时不会跳帧。在两个逻辑帧之间，表现帧会进行插值。看起来表现更流畅。
2. 如果设备速度慢，一般来说，update()花销比render()要小。所以即使fps低，也能保证游戏的正确运行。

## 引申 Extionsions

https://dewitters.com/dewitters-gameloop/

