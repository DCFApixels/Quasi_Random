# Unity-Quasi_Random
Quasi-Random Number Generator for Unity
<br><br>
Квазислучайные последовательности хорошо подходят когда стоит задача равномерно заполнить пространсво несколькими объектами. Скрипт использует векторы движка Unity.
<br>
![image](https://user-images.githubusercontent.com/99481254/183262665-db17d551-c1bb-4141-b576-efd277cb6b93.png)
<br><br>
QuasiRandom.cs содержит в себе 3 класса для 3-х измерений:<br>
Quasi1DRandom - просто генерирует квазислучайное float значение X, которое 0.0 <= X < 1.0;<br>
Quasi2DRandom - генерирует Vector2 значения x и y которого генерирются аналогично значению из Quasi1DRandom;<br>
Quasi3DRandom - генерирует Vector3, аналогичен Quasi2DRandom.

каждый из 3-х классов имеет функции GetState и SetState, может использоваться для сохранения состояния рандома между игровыми сессиями, или же во время разработки для дебага.
