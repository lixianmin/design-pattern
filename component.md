
---

客观上讲，Unity3d是使用组件尤为成功的例子。2011年我们初次接触Unity3d的时候惊为天人，在用其制作《Touch》页游的时候，大量的使用了MonoBehaviour，但后来我们在2013年制作《Torchlight Mobile》的时候已经改为禁止使用MonoBehaviour，原因是我们发现尽管使用MonoBehaviour写Script很方便，但其Update\(\)的调用顺序不容易确定，最重要的是当代码出现bug的时候，无论是断点还是日志都无法对当前哪些对象已经Update\(\)过做出任何提示。

我们一直强调解耦解耦，并且认为组合优于继承，但实际上可能并没有在实操中从组合身上获得多少益处。至少在Unity3d自身上是这样，现在想想我们对Unity3d最大的误会可能根源于它的引擎代码并不是实际游戏项目的一部分，这导致我们调试MonoBehaviour或其它Component相关的bug的时候感觉尤其困难。

在些实体组件系统将解耦组件的设计发挥到了极致，**允许你对一个实体添加新的组件而不让实体知道**。在这种系统中，一个可行的假设就是在实体中按组件的类型（枚举）对组件进行排序，从而将组件对象的更新顺序固定下来。

组件模式可能会成为一个**以后游戏设计时重点参考**的设计模式。



---

#### References

1. [Data Oriented Design](http://www.dataorienteddesign.com)
2. [进化游戏的层次结构 - 用组件来重构你的游戏实体](http://www.cnblogs.com/Henrya2/archive/2010/10/14/1851717.html)


