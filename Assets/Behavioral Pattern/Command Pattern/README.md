---
typora-copy-images-to: ../../../Pictures
typora-root-url: ../../../Pictures
---

# Command Pattern 命令模式

## Usage 用途

- 配置输入

把不同按键对应的行为与按键本身解耦。还可以实现改键功能。

- AI引擎与角色的接口

AI引擎提供命令对象让角色执行。

## Definition 定义

 将一个请求（request）封装成一个对象，以便使用不同的请求、队列或日志来参数化其他对象。命令模式也支持可撤销的操作。

![image-20210905141742658](/image-20210905141742658.png)

## Element 要素

### Command 命令

Command为所有命令声明了一个接口，调用命令对象的execute()方法，就可以让接收者进行相关的动作。接口同时也具备undo()方法，用于回滚命令。

### Concrete Command 具体命令

一个具体的命令定义了动作和接收者之间的绑定关系（某个确定的动作是由某个确定的接收者进行的）。调用者用execute()发出请求，由ConcreteCommand调用接收者去进行具体的动作。

### Client 客户

负责创建ConcreteCommand，并设置这个命令的接收者，接收者负责执行命令。

### Invoker 调用者

调用者有setCommand()方法，可以通过调用该方法，把命令对象传给调用者。调用者可以持有若干命令对象，并且在某个时间点调用命令对象的execute()方法，将请求付诸实行。

### Receiver 接收者

接收者需要知道如何实行请求，接收者也是真正实现命令的人。

## Extension 引申

- 撤销操作

一个Command除了有execute()也有undo()，方便还原该Command的所作所为。可以用堆栈记录一系列Command，方便一直撤销。

- 队列请求

可以把命令打包，当做对象一样传递。甚至也可以在不同线程中调用请求。

- 日志请求

把所有的动作记录在日志中，并且在系统死机之后，可以重新调用这些动作恢复到某个节点。

- 宏命令Macro Command

把多个子Command传到Macro Command中，execute()时遍历调用子command的execute()。

