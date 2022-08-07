# Unity-Quasi_Random
Quasi-Random Number Generator for Unity
<br><br>
Квазислучайные последовательности хорошо подходят когда стоит задача равномерно заполнить пространсво несколькими объектами. Скрипт использует векторы движка Unity.
<br>
![image](https://user-images.githubusercontent.com/99481254/183282958-04fbb0d9-c8c5-495c-be0b-3629676a03c2.png)
<br><br>
QuasiRandom.cs содержит в себе 3 класса для 3-х измерений:<br>
Quasi1DRandom - просто генерирует квазислучайное float значение X, которое 0.0 <= X < 1.0;<br>
Quasi2DRandom - генерирует Vector2 значения x и y которого генерирются аналогично значению из Quasi1DRandom;<br>
Quasi3DRandom - генерирует Vector3, аналогичен Quasi2DRandom.

каждый из 3-х классов имеет функции GetState и SetState, может использоваться для сохранения состояния рандома между игровыми сессиями, или же для отладки во время разработки.
