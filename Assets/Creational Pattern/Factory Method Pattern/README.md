#Factory Method Pattern 工厂方法模式 

## Usage 用途

希望创建一个对象，但创建对象的过程比较复杂时，想要对外隐藏这些细节时使用工厂方法模式。（不复杂用构造函数即可）比如：

- 创建的对象在一个pool中（对象池）
- 对象代码的作者希望隐藏对象真实的的类型，而构造函数一定要真实的类名才能用（只需要改工厂方法即可，不需要改使用该对象的别的代码）
-  对象创建时会有很多参数来决定如何创建出这个对象（createSth方法中可以容纳参数，根据参数创建相应的对象）

## Definition 定义

定义了一个创建对象的接口，但由子类决定要实例化的类是哪一个。工厂方法使类把实例化推迟到子类。

## Element 要素

### Product 产品

定义了工厂生产的产品的基类或接口。

### ConcreteProduct 具体产品

实现了Product接口的对象类。

### Creator

声明了工厂方法（抽象），同时也可以实现一个默认的工厂方法，返回“无”产品。

### ConcreteCreator

继承了Creator类，并且覆盖了工厂方法，返回ConcreteProduct。

## Extension 引申

- 抽象工厂模式