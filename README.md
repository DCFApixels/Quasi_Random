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
        <img src="https://github.com/user-attachments/assets/3c699094-f8e6-471d-a7c1-6d2e9530e721"></br>
        <span>English</span>
      </a>  
    </td>
    <td nowrap width="100">
      <a href="https://github.com/DCFApixels/Quasi_Random/blob/main/README-ZH.md">
        <img src="https://github.com/user-attachments/assets/8e598a9a-826c-4a1f-b842-0c56301d2927"></br>
        <span>中文</span>
      </a>  
    </td>
  </tr>
</table>

</br>

## Table of Contents

* [Introduction](#Introduction)
* [Installation](#Installation)
* [Description](#Description)
  * [Constructors](#Constructors)
  * [Generation](#Generation)
  * [State](#State)
  * [Other](#Other)
* [Example/Comparison](#ExampleComparison)

</br>

## Introduction
Quasi-random sequences are well suited when the problem is to uniformly fill a space by simulating random filling. The implementation is based on a new additive recursive R-sequence and an article from [Habr](https://habr.com/ru/articles/440892/).
R-sequence is easy to compute, and when computed in integers gives determinism and good performance. 

I used this sequence to generate starting positions, stores and other activity points in the  [БольКрафт](https://www.youtube.com/watch?v=txSoCd98OcI&list=PLZT7fvvYlYfhqWJBWzJoLQxconfz1lHPq&index=17) map generator for Warcraft 3. This way the activity points were placed roughly evenly across the map while making their positions look random.

</br>

## Installation
To install, simply copy the contents of the `src` folder into the project. The `src` folder contains:
+ `src\QuasiRandom.cs` - basic, no environment dependencies;
+ `src\QuasiRandom.unity.cs` - extension of the basic one to support vectors from Unity;  
+ `src\QuasiRandom.unity.mathematics.cs` - extension of basic to support vector types from Unity.Mathematics;

</br>

## Description
QuasiRandom is implemented as a 4 byte structure, can generate sequences with uniform filling for 1D, 2D, 3D and 4D space.

### Constructors
+ `new QuasiRandom()` - instance with seed = 0;
+ `new QuasiRandom(seed)` - instance with seed = seed;
+ `QuasiRandom.AutoSeed()` - instance with auto seed;

### Generation

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

### State

+ `GetState()` - Receive state;
+ `SetState(state)` - Change state; 

### Other

The methods `Equals`, `GethashCode`, `ToString`, and comparison operators have been overridden.

</br>

## Example/Comparison
Compares `System.Random` and `QuasiRandom` using the example of generating points in two-dimensional space:
![ex](https://github.com/DCFApixels/Quasi_Random/assets/99481254/a1556d7d-7e6b-41cc-98dd-7af6aeffb590)
