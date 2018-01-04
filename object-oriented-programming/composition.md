
---
#### Composition与Component不是一回事

OOP中经常提到is-a与has-a的表述。

1. is-a关系体现在接口上，指接口归一化，是为了简化设计，让人脑便于记忆和使用，在OOP的中通过多态实现。

2. 而Composition（组合），在实现上它是处于**封装**的内部，是属于实现细节部分，并**不体现在接口上（这一点与is-a完全相反）**，所以不会被调用者察觉到。

3. 真正的has-a关系是指Component（组件），它将一部分具现的功能提炼出来，借用了Composition的概念，但却是可以被调用者察觉的，因此并没有获得独立演化的优点（也就是封装）。

---
#### References

1. [Composition over inheritance](https://en.wikipedia.org/wiki/Composition_over_inheritance)