
---
#### Composition与Component不是一回事

OOP中经常提到is-a与has-a的表述。

1. is-a关系体现在接口上，指接口归一化，是为了简化设计，让人脑便于记忆和使用。需要注意的是，在OOP的is-a指多态而不是继承。

2. 而组合（Composition），在实现上它是处于**封装**的内部，是属于实现细节，并**不体现在对外接口上（这一点与is-a完全相反）**，所以不会被调用者察觉到。**组合其实是use-a**，而且这个use是不稳定的，今天是use-a，明天就可能变成use-another。

3. 真正的has-a关系是指组件（Component），它将一部分具现的功能提炼出来，借用了组合的概念，但却是可以被调用者察觉的，因此在独立演化这点上不如组合。

---
#### References

1. [Composition over inheritance](https://en.wikipedia.org/wiki/Composition_over_inheritance)
2. [进化游戏的层次结构 - 用组件来重构你的游戏实体](http://www.cnblogs.com/Henrya2/archive/2010/10/14/1851717.html)