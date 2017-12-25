

---
#### Intent

“使用基类提供的操作集合来定义子类中的行为。”

> 当你发现你的设计里可能充满大量子类的时候，首先要考虑的其实是**数据驱动**的方案，尝试找到一种使用数据来定义行为的方法。---- 换句话说，想尽办法让策划去配表（死道友不列贫道：能让策划做的事情就不要让程序做，能让别的程序做的事情就不要自己做）


---
#### Description


1. 一个近乎万能的基类：
    1.  提供了子类所需要的大部分非逻辑性API，换句话说，实现子类功能的主要手段就是排列组合这些API
    2.  一个受限的环境，一个sandbox，一个领域，

这个模式有用嘛？你可能会说我干嘛要建立那么多的子类。这个模式是有用的， 你可能不经意间就使用了这个模式:

1. Unity3d里的MonoBehaviour, EditorWindow等，当然里面的可能有很多方法没有故意设计成protected

2. 你在设计UI界面的时候，是不是经常会继承自一个名字类似于UIWindow的类？

----
#### References

1. [subclass sandbox](http://gameprogrammingpatterns.com/subclass-sandbox.html)
2. [子类沙盒](https://tantiyin.gitbooks.io/gameprogrammingpatterns/42-%E5%AD%90%E7%B1%BB%E6%B2%99%E7%9B%92.html)
