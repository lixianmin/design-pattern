
---

#### Intent

“使用基类提供的操作集合来定义子类中的行为。”

> 当你发现你的设计里可能充满大量子类的时候，首先要考虑的其实是**数据驱动**的方案，尝试找到一种使用数据来定义行为的方法。---- 换句话说，想尽办法让策划去配表（死道友不列贫道：能让策划做的事情就不要让程序做，能让别的程序做的事情就不要自己做）

---

#### Description

通过子类沙盒模式，我们将得到：

1. 一个近乎万能的base class：
   1. 提供了subclass所需要的大部分非逻辑性API，换句话说，实现subclass功能的主要手段就是排列组合这些API
   2. 一个受限的环境，一个sandbox，一个领域 （这意味着你有机会创造一种DSL）
2. 一大波与base class强耦合的subclasses：
   1. subclass通过base class与外部系统交互，因此降低了与外部系统的耦合度
   2. subclass不需要大量编写外部系统相关的API，只需要使用base class提供的接口即可



封装encapsulation通常是有意义的，比如在base class中提供PlaySound\(\)相关的接口，可以使subclasses忽略其中的实现细节，比如音效的优先级和排队，换句话说，如果base class不提供这层封装的话，subclasses就得自己去考虑这些问题，而这往往超越了subclasses逻辑代码的职责范围。

> 新手往往讨厌使用底层代码之外的封装，因为这在一定程度阻碍了他们了解底层代码（或者说跳槽）。举个简单的例子，Unity3d中写日志的接口是Debug.Log\(\)，项目组通常应该提供自己的封装，比如我们项目使用Console.WriteLine\(\) 对其封装，这中间隐藏了打印额外信息（日志时间、帧）、IO卡顿处理等行为。



这个模式有用嘛？你可能会说我干嘛要建立那么多的子类。这个模式是有用的， 你可能不经意间就使用了这个模式:

1. Unity3d里的MonoBehaviour, EditorWindow等，当然里面的可能有很多方法没有故意设计成protected

2. 你在设计UI界面的时候，是不是经常会继承自一个名字类似于UIWindow的类？

---

#### References

1. [subclass sandbox](http://gameprogrammingpatterns.com/subclass-sandbox.html)
2. [子类沙盒](https://tantiyin.gitbooks.io/gameprogrammingpatterns/42-子类沙盒.html)



