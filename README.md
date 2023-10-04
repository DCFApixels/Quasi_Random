# Quasi Random Generator

## Введение
Квазислучайные последовательности хорошо подходят когда стоит задача равномерно заполнить пространсво иммитируя случайное заполнение. Реализация основана на новой аддитивной рекурсивной R-последовательности и статье [Хабра](https://habr.com/ru/articles/440892/).
R последовательность легко высчитывается, а при подсчете в целых числах дает хорошую производительность. 

Данную последовательность я использовал для генерации стартовых позиций, магазинов и прочих точек активности в генераторе карты [БольКрафт](https://www.youtube.com/watch?v=txSoCd98OcI&list=PLZT7fvvYlYfhqWJBWzJoLQxconfz1lHPq&index=17). Так точки активности располагались примерно равномерно по всей карте и при этом их позиции выглядели случайным.

## Установка
Для установки просто скопируйте содержимое папки `src` в проект. Папка `src` содержит:
+ `src\QuasiRandom.cs` - базовый, без зависимостей от среды;
+ `src\QuasiRandom.unity.cs` - расширение базового для поддержки векторов из Unity;  
+ `src\QuasiRandom.unity.mathematics.cs` - расширение базового для поддержки векторных типов Unity.Mathematics;

## Описание

QuasiRandom реализованн в виде структуры размером 4 байта, может генерировать последовательности с равномерным заполнением для 1D, 2D, 3D и 4D пространства.

### Конструкторы
+ `new QuasiRandom()` - экземпляр с сидом = 0;
+ `new QuasiRandom(seed)` - экземпляр с сидом = seed;
+ `QuasiRandom.AutoSeed()` - экземпляр с автоматическим сидом;

### Генерация

<details>
<summary><b>QuasiRandom.cs</b></summary>

+ `bool` [false - true] <br>
`NextBool()` `NextBool2(out x, out y)` `NextBool3(out x, out y, out z)` `NextBool4(out x, out y, out z, out w)`;

+ `int` [int.MinValue <= x <= int.MaxValue] <br>
`NextInt()` `NextInt2(out x, out y)` `NextInt3(out x, out y, out z)` `NextInt4(out x, out y, out z, out w)`;

+ `int` [0 <= x < max] <br>
`NextInt(max)` `NextInt2(max, out x, out y)` `NextInt3(max, out x, out y, out z)` `NextInt4(max, out x, out y, out z, out w)`;

+ `int` [min <= x < max] <br>
`NextInt(min, max)` `NextInt2(min, max, out x, out y)` `NextInt3(min, max, out x, out y, out z)` `NextInt4(min, max, out x, out y, out z, out w)`;

+ `uint` [uint.MinValue <= x <= uint.MaxValue] <br>
`NextUInt()` `NextUInt2(out x, out y)` `NextUInt3(out x, out y, out z)` `NextInt4(out x, out y, out z, out w)`;

+ `uint` [0 <= x < max] <br>
`NextUInt(max)` `NextUInt2(max, out x, out y)` `NextUInt3(max, out x, out y, out z)` `NextUInt4(max, out x, out y, out z, out w)`;

+ `uint` [min <= x < max] <br>
`NextUInt(min, max)` `NextUInt2(min, max, out x, out y)` `NextUInt3(min, max, out x, out y, out z)` `NextUInt4(min, max, out x, out y, out z, out w)`;

+ `long` [long.MinValue <= x <= long.MaxValue] <br>
`NextLong()` `NextLong2(out x, out y)` `NextLong3(out x, out y, out z)` `NextLong4(out x, out y, out z, out w)`;

+ `ulong` [ulong.MinValue <= x <= ulong.MaxValue] <br>
`NextULong()` `NextULong2(out x, out y)` `NextULong3(out x, out y, out z)` `NextULong4(out x, out y, out z, out w)`;

+ `float` [0.0f <= x < 1.0f] <br>
`NextFloat()` `NextFloat2(out x, out y)` `NextFloat3(out x, out y, out z)` `NextFloat4(out x, out y, out z, out w)`;

+ `double` [0.0d <= x < 1.0d] <br>
`NextDouble()` `NextDouble2(out x, out y)` `NextDouble3(out x, out y, out z)` `NextDouble4(out x, out y, out z, out w)`;

+ `VectorX` [0.0f <= x < 1.0f] <br>
`NextVector2()` `NextVector3()` `NextVector4()`;

</details>

<details>
<summary><b>QuasiRandom.unity.cs</b></summary>

+ `VectorX` [0.0f <= x < 1.0f] <br>
`NextUnityVector2()` `NextUnityVector3()` `NextUnityVector4()`; 

+ `VectorXInt` [0.0f <= x < 1.0f] <br>
`NextUnityVector2Int()` `NextUnityVector3Int()`;

</details>

<details>
<summary><b>QuasiRandom.unity.mathematics.cs</b></summary>

+ `bool` [false - true] <br>
`NextBool2()` `NextBool3()` `NextBool4()`;

+ `int` [int.MinValue <= x <= int.MaxValue] <br>
`NextInt2()` `NextInt3()` `NextInt4()`;

+ `int` [0 <= x < max] <br>
`NextInt2(max)` `NextInt3(max)` `NextInt4(max)`;

+ `int` [min <= x < max] <br>
`NextInt2(min, max)` `NextInt3(min, max)` `NextInt4(min, max)`;

+ `uint` [uint.MinValue <= x <= uint.MaxValue] <br>
`NextUInt2()` `NextUInt3()` `NextInt4()`;

+ `uint` [0 <= x < max] <br>
`NextUInt2(max)` `NextUInt3(max)` `NextUInt4(max)`;

+ `uint` [min <= x < max] <br>
`NextUInt2(min, max)` `NextUInt3(min, max)` `NextUInt4(min, max)`;

+ `float` [0.0f <= x < 1.0f] <br>
`NextFloat2()` `NextFloat3()` `NextFloat4()`;

+ `double` [0.0d <= x < 1.0d] <br>
`NextDouble2()` `NextDouble3()` `NextDouble4()`;

</details>

### Состояние

+ `GetState()` - Получение состояния 
+ `SetState(state)` - Изменение состояния 

### Прочее

Переопределены методы `Equals`, `GethashCode`, `ToString` и операторы сравнения

## Пример/Сравнение
![ex](https://github.com/DCFApixels/Quasi_Random/assets/99481254/a1556d7d-7e6b-41cc-98dd-7af6aeffb590)
