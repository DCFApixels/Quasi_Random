# Quasi Random Generator

<table>
  <tr></tr>
  <tr>
    <td colspan="3">Readme Languages:</td>
  </tr>
  <tr></tr>
  <tr>
    <td nowrap width="100">
      <a href="https://github.com/DCFApixels/Quasi_Random/blob/main/README-RU.md">
        <img src="https://github.com/user-attachments/assets/7bc29394-46d6-44a3-bace-0a3bae65d755"></br>
        <span>Русский</span>
      </a>  
    </td>
    <td nowrap width="100">
      <a href="https://github.com/DCFApixels/DragonECS">
        <img src="https://github.com/user-attachments/assets/30528cb5-f38e-49f0-b23e-d001844ae930"></br>
        <span>English</span>
      </a>  
    </td>
    <td nowrap width="100">
      <a href="https://github.com/DCFApixels/Quasi_Random/blob/main/README-ZH.md">
        <img src="https://github.com/user-attachments/assets/3c699094-f8e6-471d-a7c1-6d2e9530e721"></br>
        <span>中文</span>
      </a>  
    </td>
  </tr>
</table>

* [介绍](#介绍)
* [安装](#安装)
* [描述](#描述)
  * [构造](#构造)
  * [生成](#生成)
  * [状态](#状态)
  * [其他](#其他)
* [示例/比较](#示例比较)


## 介绍
Quasi随机序列在需要模拟随机填充并均匀填充空间的情况下非常适用。该实现基于新的加法递归R序列和[habr文章](https://habr.com/ru/articles/440892/)。R序列易于计算，并且在整数计算时具有良好的性能。

我使用该序列来生成[Warcraft 3地图](https://www.youtube.com/watch?v=txSoCd98OcI&list=PLZT7fvvYlYfhqWJBWzJoLQxconfz1lHPq&index=17)的起始位置、商店和其他活动点的生成器。因此，活动点大致均匀分布在整个地图上，同时它们的位置看起来是随机的。

## 安装
威安装只需将src文件夹中的内容复制到项目中。 src 文件夹包含以下内容：

src\QuasiRandom.cs - 基本版本，不依赖于任何环境；
src\QuasiRandom.unity.cs - 为支持Unity中的向量的扩展；
src\QuasiRandom.unity.mathematics.cs - 为支持Unity.Mathematics中的向量的扩展；

## 描述

QuasiRandom 实现为一个大小为 4 字节的 struct，可以为 1D、2D、3D 和 4D 空间生成均匀填充的序列。

### 构造
+ `new QuasiRandom()` - 种子为0的实例；
+ `new QuasiRandom(seed)` - 种子为seed的实例；
+ `QuasiRandom.AutoSeed()` - 自动种子的实例；

### 生成

<details>
<summary><b>QuasiRandom.cs</b></summary>

+ `bool`<br>[false - true] <br>
`NextBool()` `NextBool2(out x, out y)` `NextBool3(out x, out y, out z)` `NextBool4(out x, out y, out z, out w)`;

+ `int`<br>[int.MinValue <= x <= int.MaxValue] <br>
`NextInt()` `NextInt2(out x, out y)` `NextInt3(out x, out y, out z)` `NextInt4(out x, out y, out z, out w)`;

+ `int`<br>[0 <= x < max] <br>
`NextInt(max)` `NextInt2(max, out x, out y)` `NextInt3(max, out x, out y, out z)` `NextInt4(max, out x, out y, out z, out w)`;

+ `int`<br>[min <= x < max] <br>
`NextInt(min, max)` `NextInt2(min, max, out x, out y)` `NextInt3(min, max, out x, out y, out z)` `NextInt4(min, max, out x, out y, out z, out w)`;

+ `uint`<br>[uint.MinValue <= x <= uint.MaxValue] <br>
`NextUInt()` `NextUInt2(out x, out y)` `NextUInt3(out x, out y, out z)` `NextInt4(out x, out y, out z, out w)`;

+ `uint`<br>[0 <= x < max] <br>
`NextUInt(max)` `NextUInt2(max, out x, out y)` `NextUInt3(max, out x, out y, out z)` `NextUInt4(max, out x, out y, out z, out w)`;

+ `uint`<br>[min <= x < max] <br>
`NextUInt(min, max)` `NextUInt2(min, max, out x, out y)` `NextUInt3(min, max, out x, out y, out z)` `NextUInt4(min, max, out x, out y, out z, out w)`;

+ `long`<br>[long.MinValue <= x <= long.MaxValue] <br>
`NextLong()` `NextLong2(out x, out y)` `NextLong3(out x, out y, out z)` `NextLong4(out x, out y, out z, out w)`;

+ `ulong`<br>[ulong.MinValue <= x <= ulong.MaxValue] <br>
`NextULong()` `NextULong2(out x, out y)` `NextULong3(out x, out y, out z)` `NextULong4(out x, out y, out z, out w)`;

+ `float`<br>[0.0f <= x < 1.0f] <br>
`NextFloat()` `NextFloat2(out x, out y)` `NextFloat3(out x, out y, out z)` `NextFloat4(out x, out y, out z, out w)`;

+ `double`<br>[0.0d <= x < 1.0d] <br>
`NextDouble()` `NextDouble2(out x, out y)` `NextDouble3(out x, out y, out z)` `NextDouble4(out x, out y, out z, out w)`;

+ `VectorX`<br>[0.0f <= x < 1.0f] <br>
`NextVector2()` `NextVector3()` `NextVector4()`;

</details>

<details>
<summary><b>QuasiRandom.unity.cs</b></summary>

+ `VectorX`<br>[0.0f <= x < 1.0f] <br>
`NextUnityVector2()` `NextUnityVector3()` `NextUnityVector4()`; 

+ `VectorXInt`<br>[0.0f <= x < 1.0f] <br>
`NextUnityVector2Int()` `NextUnityVector3Int()`;

</details>

<details>
<summary><b>QuasiRandom.unity.mathematics.cs</b></summary>

+ `bool`<br>[false - true] <br>
`NextBool2()` `NextBool3()` `NextBool4()`;

+ `int`<br>[int.MinValue <= x <= int.MaxValue] <br>
`NextInt2()` `NextInt3()` `NextInt4()`;

+ `int`<br>[0 <= x < max] <br>
`NextInt2(max)` `NextInt3(max)` `NextInt4(max)`;

+ `int`<br>[min <= x < max] <br>
`NextInt2(min, max)` `NextInt3(min, max)` `NextInt4(min, max)`;

+ `uint`<br>[uint.MinValue <= x <= uint.MaxValue] <br>
`NextUInt2()` `NextUInt3()` `NextInt4()`;

+ `uint`<br>[0 <= x < max] <br>
`NextUInt2(max)` `NextUInt3(max)` `NextUInt4(max)`;

+ `uint`<br>[min <= x < max] <br>
`NextUInt2(min, max)` `NextUInt3(min, max)` `NextUInt4(min, max)`;

+ `float`<br>[0.0f <= x < 1.0f] <br>
`NextFloat2()` `NextFloat3()` `NextFloat4()`;

+ `double`<br>[0.0d <= x < 1.0d] <br>
`NextDouble2()` `NextDouble3()` `NextDouble4()`;

</details>

### 状态

+ `GetState()` - 获取状态；
+ `SetState(state)` - 设置状态；

### 其他

重写了 `Equals`、`GetHashCode`、`ToString` 方法和比较运算符。

## 示例/比较
下图比较了在二维空间中使用 `System.Random` 和 `QuasiRandom` 生成点的情况：
![ex](https://github.com/DCFApixels/Quasi_Random/assets/99481254/a1556d7d-7e6b-41cc-98dd-7af6aeffb590)
