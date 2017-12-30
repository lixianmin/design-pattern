
---

#### Intent

“使用基类提供的操作集合来定义子类中的行为。”

> 当你发现你的设计里**可能充满无数个子类的时候（个数不确定，会由其它人不断增加）**，首先要考虑的其实是**数据驱动**的方案，尝试找到一种使用数据来定义行为的方法---- 换句话说，想尽办法让策划去配表（能让策划做的事情就不要让程序做，能让别的程序做的事情就不要自己做，所谓死道友不死贫道，这可是亘古不变的真知灼见）。除非你的行为是复杂的、命令式的，那么用数据定义它们的行为可能会更加困难。

通过子类沙盒模式，我们将得到：

---

#### 一个近乎万能的base class

在子类沙盒模式中，base class提供了subclass所需要的大部分非逻辑性基础操作（含API与回调方法），换句话说，书写subclass逻辑的主要手段就是排列组合这些基础操作。该模式通过将基础操作提取到更高的层次（base class）来解决代码冗余问题，当我们发现在subclasses中存在大量重复代码时，我们就会把它们向上移动到base class中作为一个新的可用基本操作。

我们通过将耦合制约于一处来解决耦合问题。base class将与不同的外部系统耦合，而它的上百个subclasses则不会。当外部系统发生变化时，对base class进行修改可能是必须的，但这些subclasses则应被改动。

我们会得到一个受限的（protected）环境，一个sandbox，一个领域 （这意味着你有机会创造一种DSL）。通过使一个派生大量的子类，我们限制该代码在代码库里的影响范围 --- 祸害你一个，福利全社会。

这种模式会催生一种扁平的类层次架构，你的继承链不会太深，扁平的继承树相对容易修改。

封装encapsulation通常是有意义的，比如在base class中提供PlaySound\(\)相关的接口，可以使subclasses忽略其中的实现细节，比如音效的优先级和排队，换句话说，如果base class不提供这层封装的话，subclasses就得自己去考虑这些问题，而这往往超越了subclasses逻辑代码的职责范围。

> 新手往往讨厌使用底层代码之外的封装，因为这在一定程度阻碍了他们了解底层代码（或者说跳槽）。举个简单的例子，Unity3d中写日志的接口是Debug.Log\(\)，项目组通常应该提供自己的封装，比如我们项目使用Console.WriteLine\(\) 对其封装，这中间隐藏了打印额外信息（日志时间、帧）、IO卡顿处理等行为。

---

#### 一大波与base class强耦合的subclasses

1. subclass通过base class与外部系统交互，因此降低了与外部系统的耦合度
2. subclass不需要大量编写外部系统相关的API，只需要使用base class提供的接口即可

---
#### When to use it

这是一个相当温和的设计模式，它只描述了一个基本思想，但并没有详细的实现机制。如果你有一个non-virtual protected方法，那你可能已经在使用这个模式了。

可能的使用情形是：

1. 如果你有一个带有大量subclasses的base class，大量subclasses的意思是数以百计，可能由其它的程序员不断的研发出来。
2. subclasses之间有行为重叠，你希望在它们之间简单的共享代码。
3. 你希望这些subclasses与程序的其它代码之间耦合最小化。

---
#### Description

一些相关的提示：

1. 当你使用update method的时候，你的更新方法通常也是一个沙盒方法。
2. Template method模式与本模式正好相反。在这两个模式中，你都使用一系列操作原语来实现一个函数。使用子类沙盒模式时，函数在subclasses中，原语操作在base class中；而使用Template method时，函数骨架在base class中，而原语操作在subclass中实现。
3. 你可以将本模式看作是外观模式（Facade）的变种。

我真会有需求建立大量的subclasses吗？真实游戏世界里的例子：

1. Unity3d里的MonoBehaviour, EditorWindow等，当然里面的可能有很多方法没有故意设计成protected

2. 你在设计UI界面的时候，是不是经常会继承自一个名字类似于UIWindow的类？

---

#### Problems

[脆弱基类问题](https://en.wikipedia.org/wiki/Fragile_base_class)：数以百计的subclasses与base class密切相关，这个spiderweb式的耦合使得无损地改变基类是很困难的

---

#### References

1. [subclass sandbox](http://gameprogrammingpatterns.com/subclass-sandbox.html)
2. [子类沙盒](https://tantiyin.gitbooks.io/gameprogrammingpatterns/42-子类沙盒.html)



