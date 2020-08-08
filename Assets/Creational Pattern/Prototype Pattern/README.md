# Prototype Pattern 原型模式

## Usage 用途

游戏中，不同的生成器可以构造不同的怪物实例。为了支持所有怪物类型，可以用蛮力法——为每个类设计一个生成器类。但是这样做的话，太多冗余、重复代码。原型模式提供的思想是，通过一个对象，生成与对象自身类似的其他对象。

## Definition 定义

用原型实例指定创建对象的种类，并且通过拷贝这些原型创建新的对象。

## Element 要素

### Prototype 原型

定义了接口，声明了clone方法，可以通过clone方法复制出与对象类似的其他对象。

### Concrete Prototype 具体原型

实现了Prototype接口，可以clone自身得到新的对象。

### Client 客户

通过调用原型的clone方法，得到新的对象。

## Extension 引申