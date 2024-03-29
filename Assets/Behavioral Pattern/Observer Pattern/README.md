# Observer Pattern 观察者模式

## Usage 用途

- 系统的逻辑层数据改了，通知表现层比如UI也作修改；

- 成就系统，要关注各个模块的数据；

## Definition 定义

定义了对象之间的一对多依赖，这样一来，当一个对象改变状态时，它的所有依赖者都会收到通知并通知自动更新。

![observer](https://github.com/JanHoChoi/Unity-Design-Pattern/blob/master/Pictures/observer.gif)

## Element 要素

### Subject 主题

主题接口，提供了方法，可以让对象注册或者取消注册成为该主题的观察者。

### ConcreteSubject 具体主题

实现了主题接口的类，持有具体观察者的状态，当主题状态改变时，通知它的所有观察者改变的情况。

### Observer 观察者

观察者接口，具有Update方法，当主题被改变时，Update方法被调用。

### ConcreteObserver 具体观察者

实现了观察者接口的类，拥有对某个具体主题的引用，存储了需要与主题保持一致的数据；观察者必须注册具体主题，以用于接收更新。

## Extension 引申