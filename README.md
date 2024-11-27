<p align="center">
<img width="300" src="https://github.com/user-attachments/assets/451365c6-8957-48f9-8199-ce9b81cb87ca">
</p>

<p align="center">
<img alt="Version" src="https://img.shields.io/github/meta-json/v/DCFApixels/Quasi_Random?style=for-the-badge&color=1e90ff">
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
R-sequence is easy to compute, and when computed in integers it gives good performance. 

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

### State

+ `GetState()` - Receive state;
+ `SetState(state)` - Change state; 

### Other

The methods `Equals`, `GethashCode`, `ToString`, and comparison operators have been overridden.

</br>

## Example/Comparison
Compares `System.Random` and `QuasiRandom` using the example of generating points in two-dimensional space:
![ex](https://github.com/DCFApixels/Quasi_Random/assets/99481254/a1556d7d-7e6b-41cc-98dd-7af6aeffb590)
