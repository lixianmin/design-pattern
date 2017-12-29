
---

说白了就是你在游戏中常见的Update\(\)或Tick\(\)方法，这可能是在游戏开发中最常见的模式了，常见到一直以来我并不认为它算得上是一种模式

在Update\(\)中使用Hashtable可能问题包括：

1. 遍历顺序不稳定
2. 如果在Update\(\)中有Add, Remove对象的话，可能会导致某些对象被Update\(\)到两次，而其它对象Update\(\)不到的情况；通常来说，新加入的对象应该在下一帧Update\(\)到，而被Remove\(\)的对象应该不需要Update\(\)了
3. 遍历速度慢，Hashtable的遍历速度可能只有array的几分之一，在C\#中实测各容器的遍历开销对比如下，其中SortedTable为自定义映射表，基于array使用二分查找实现：

| 函数 | 遍历类型 | cpu开销 | gc开销 |
| --- | --- | --- | --- |
| SortedTable | Pair | 6 | 0 |
|  | Values | 2 | 0 |
|  | **Values\[i\]** | **1** | **0** |
| Dictionary | Pair | 7 | 0 |
|  | Values | 8 | 12B |
| Hashable | Pair | 4 | 36B |
|  | Values | 3 | 36B |
| SortedDictionary | Pair | 18 | 100B |
|  | Values | 13 | 112B |



