<p align="center">
<img width="300" src="https://github.com/user-attachments/assets/451365c6-8957-48f9-8199-ce9b81cb87ca">
</p>

<p align="center">
<img alt="Version" src="https://img.shields.io/github/package-json/v/DCFApixels/Quasi_Random?style=for-the-badge&color=1e90ff">
<img alt="License" src="https://img.shields.io/github/license/DCFApixels/Quasi_Random?color=1e90ff&style=for-the-badge">
</p>

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

</br>

## 目录
* [介绍](#介绍)
* [安装](#安装)
* [描述](#描述)
  * [构造](#构造)
  * [生成](#生成)
  * [状态](#状态)
  * [其他](#其他)
* [示例/比较](#示例比较)

</br>

## 介绍
Quasi随机序列在需要模拟随机填充并均匀填充空间的情况下非常适用。该实现基于新的加法递归R序列和[habr文章](https://habr.com/ru/articles/440892/)。R序列易于计算，并且在整数计算时具有确定性和良好的性能。

我使用该序列来生成[Warcraft 3地图](https://www.youtube.com/watch?v=txSoCd98OcI&list=PLZT7fvvYlYfhqWJBWzJoLQxconfz1lHPq&index=17)的起始位置、商店和其他活动点的生成器。因此，活动点大致均匀分布在整个地图上，同时它们的位置看起来是随机的。

</br>

## 安装
威安装只需将src文件夹中的内容复制到项目中。 src 文件夹包含以下内容：

src\QuasiRandom.cs - 基本版本，不依赖于任何环境；
src\QuasiRandom.unity.cs - 为支持Unity中的向量的扩展；
src\QuasiRandom.unity.mathematics.cs - 为支持Unity.Mathematics中的向量的扩展；

</br>

## 描述

QuasiRandom 实现为一个大小为 4 字节的 struct，可以为 1D、2D、3D 和 4D 空间生成均匀填充的序列。

### 构造
+ `new QuasiRandom()` - 种子为0的实例；
+ `new QuasiRandom(seed)` - 种子为seed的实例；
+ `QuasiRandom.AutoSeed()` - 自动种子的实例；

### 生成

<details>
<summary><b>NextBool</b></summary>

```
[false - true]
```
```c#
bool NextBool();
void NextBool2(out bool x, out bool y);
void NextBool3(out bool x, out bool y, out bool z);
void NextBool4(out bool x, out bool y, out bool z, out bool w);
Bool2 NextBool2();
Bool3 NextBool3();
Bool4 NextBool4();
```

</details>

<details>
<summary><b>NextInt</b></summary>

```
[int.MinValue <= x <= int.MaxValue]
```
```c#
int NextInt();
void NextInt2(out int x, out int y);
void NextInt3(out int x, out int y, out int z);
void NextInt4(out int x, out int y, out int z, out int w);
Int2 NextInt2();
Int3 NextInt3();
Int4 NextInt4();
```

```
[0 <= x < max]
```
```c#
int NextInt(int max);
void NextInt2(int max, out int x, out int y);
void NextInt3(int max, out int x, out int y, out int z);
void NextInt4(int max, out int x, out int y, out int z, out int w);
Int2 NextInt2(int max);
Int3 NextInt3(int max);
Int4 NextInt4(int max);
```

```
[min <= x < max]
```
```c#
int NextInt(int min, int max);
void NextInt2(int min, int max, out int x, out int y);
void NextInt3(int min, int max, out int x, out int y, out int z);
void NextInt4(int min, int max, out int x, out int y, out int z, out int w);
Int2 NextInt2(int min, int max);
Int3 NextInt3(int min, int max);
Int4 NextInt4(int min, int max);
```

</details>

<details>
<summary><b>NextUInt</b></summary>

```
[uint.MinValue <= x <= uint.MaxValue]
```
```c#
uint NextUInt();
void NextUInt2(out uint x, out uint y);
void NextUInt3(out uint x, out uint y, out uint z);
void NextUInt4(out uint x, out uint y, out uint z, out uint w);
UInt2 NextUInt2();
UInt3 NextUInt3();
UInt4 NextUInt4();
```

```
[0 <= x < max]
```
```c#
uint NextUInt(uint max);
void NextUInt2(uint max, out uint x, out uint y);
void NextUInt3(uint max, out uint x, out uint y, out uint z);
void NextUInt4(uint max, out uint x, out uint y, out uint z, out uint w);
UInt2 NextUInt2(uint max);
UInt3 NextUInt3(uint max);
UInt4 NextUInt4(uint max);
```

```
[min <= x < max]
```
```c#
uint NextUInt(uint min, uint max);
void NextUInt2(uint min, uint max, out uint x, out uint y);
void NextUInt3(uint min, uint max, out uint x, out uint y, out uint z);
void NextUInt4(uint min, uint max, out uint x, out uint y, out uint z, out uint w);
UInt2 NextUInt2(uint min, uint max);
UInt3 NextUInt3(uint min, uint max);
UInt4 NextUInt4(uint min, uint max);
```

</details>

<details>
<summary><b>NextLong</b></summary>

```
[long.MinValue <= x <= long.MaxValue]
```
```c#
long NextLong();
void NextLong2(out long x, out long y);
void NextLong3(out long x, out long y, out long z);
void NextLong4(out long x, out long y, out long z, out long w);
Long2 NextLong2();
Long3 NextLong3();
Long4 NextLong4();
```

```
[0 <= x < max]
```
```c#
long NextLong(long max);
void NextLong2(long max, out long x, out long y);
void NextLong3(long max, out long x, out long y, out long z);
void NextLong4(long max, out long x, out long y, out long z, out long w);
Long2 NextLong2(long max);
Long3 NextLong3(long max);
Long4 NextLong4(long max);
```

```
[min <= x < max]
```
```c#
long NextLong(long min, long max);
void NextLong2(long min, long max, out long x, out long y);
void NextLong3(long min, long max, out long x, out long y, out long z);
void NextLong4(long min, long max, out long x, out long y, out long z, out long w);
Long2 NextLong2(long min, long max);
Long3 NextLong3(long min, long max);
Long4 NextLong4(long min, long max);
```

</details>

<details>
<summary><b>NextULong</b></summary>

```
[ulong.MinValue <= x <= ulong.MaxValue]
```
```c#
ulong NextULong();
void NextULong2(out ulong x, out ulong y);
void NextULong3(out ulong x, out ulong y, out ulong z);
void NextULong4(out ulong x, out ulong y, out ulong z, out ulong w);
ULong2 NextULong2();
ULong3 NextULong3();
ULong4 NextULong4();
```

```
[0 <= x < max]
```
```c#
ulong NextULong(ulong max);
void NextULong2(ulong max, out ulong x, out ulong y);
void NextULong3(ulong max, out ulong x, out ulong y, out ulong z);
void NextULong4(ulong max, out ulong x, out ulong y, out ulong z, out ulong w);
ULong2 NextULong2(ulong max);
ULong3 NextULong3(ulong max);
ULong4 NextULong4(ulong max);
```

```
[min <= x < max]
```
```c#
ulong NextULong(ulong min, ulong max);
void NextULong2(ulong min, ulong max, out ulong x, out ulong y);
void NextULong3(ulong min, ulong max, out ulong x, out ulong y, out ulong z);
void NextULong4(ulong min, ulong max, out ulong x, out ulong y, out ulong z, out ulong w);
ULong2 NextULong2(ulong min, ulong max);
ULong3 NextULong3(ulong min, ulong max);
ULong4 NextULong4(ulong min, ulong max);
```

</details>

<details>
<summary><b>NextFloat</b></summary>

```
[0.0f <= x < 1.0f]
```
```c#
float NextFloat();
void NextFloat2(out float x, out float y);
void NextFloat3(out float x, out float y, out float z);
void NextFloat4(out float x, out float y, out float z, out float w);
Float2 NextFloat2();
Float3 NextFloat3();
Float4 NextFloat4();
```

</details>

<details>
<summary><b>NextDouble</b></summary>

```
[0.0d <= x < 1.0d]
```
```c#
double NextDouble();
void NextDouble2(out double x, out double y);
void NextDouble3(out double x, out double y, out double z);
void NextDouble4(out double x, out double y, out double z, out double w);
Double2 NextDouble2();
Double3 NextDouble3();
Double4 NextDouble4();
```

</details>

### 状态

+ `GetState()` - 获取状态；
+ `SetState(state)` - 设置状态；

### 其他

重写了 `Equals`、`GetHashCode`、`ToString` 方法和比较运算符。

</br>

## 示例/比较
下图比较了在二维空间中使用 `System.Random` 和 `QuasiRandom` 生成点的情况：
![ex](https://github.com/DCFApixels/Quasi_Random/assets/99481254/a1556d7d-7e6b-41cc-98dd-7af6aeffb590)
