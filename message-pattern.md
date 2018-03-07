
---
#### Intent

消息模式是一类常见的用于解耦合的代码设计方案，其基本设计思想是：核心model定义消息的格式和接口，外围client端代码订阅自己关心的消息，当核心model发送消息时，所有订阅该消息的client端代码都会收到该消息，从而作出适当的响应。

如无特别说明，在本章节中，消息（message）与事件（event）指代相同的内容，文章中可能会交替使用它们。

从消息响应时间上看，消息模式可大致分为两类，一类是同步（或立即）响应模式，典型的如Observer或C#中的event，另一类是异步（或延时）响应模式，典型的如消息队列（MessageQueue，MessageBus）。一个完整的消息系统需要同时支持同步和异步影响模式。

---
#### 同步（或立即）响应模式

按Windows的消息接口惯例，通常使用SendMessage()函数发送的消息为同步消息，接收方需要立即处理。

同步消息处理中，发送方可以立即收到处理反馈，并做出针对性处理。

---
#### 异步（或延时）响应模式

通常实现为一个中心消息队列（MessageQueue，MessageBus）。按Windows的消息接口惯例，通常使用PostMessage()函数发送的消息为异步消息，消息由中心消息队列统一接收，并按情况分发。

该方法的优点是可以平滑游戏各帧的处理时间。有的时候，某些消息处理函数会消耗大量CPU时间，如果所有的消息都同步处理的话，会导致游戏卡帧。而中心消息队列可以检测游戏帧的运行情况，如果发现本帧已经消耗了大量的CPU时间，则可将剩余的消息延迟到下一帧去处理，从而保持游戏流畅运行。

另外，消息队列中的消息可能存在优先级，以及消息合并的现象

---
系统中已经有几个事件管理器，像GameEventManager, FightEventManager，为什么还要
重新设计一个MessageBus，目标含以下几点：

1. 当新加一种message/event时，不需要同步定义一个新的event class，操作起来有些复杂

2. 如果lua需要接收该message，不需要每次都需要导出新的event class的userdata

3. 在lua可以使用统一的方式无脑RemoveListener()，而不需要先自定义一个function以适配
C#的导出接口，同时还要记得在某个时刻手动回收handler

4. 希望支持PostMessage()这种异步事件处理机制，而不是只有同步事件处理机制

---
#### References

1. [Event Queue](http://gameprogrammingpatterns.com/event-queue.html)