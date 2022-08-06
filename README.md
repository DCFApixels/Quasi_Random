# Unity-Quasi_Random
Quasi-Random Number Generator for Unity

Квазислучайные последовательности хорошо подходят когда стоит задача равномерно заполнить пространсво несколькими объектами. Скрипт использует векторы движка Unity.
QuasiRandom.cs содержит в себе 3 класса для 3-х измерений:
Quasi1DRandom - просто генерирует квазислучайное float значение X, которое 0.0 <= X < 1.0;
Quasi2DRandom - генерирует Vector2 значения x и y которого генерирются аналогично значению из Quasi1DRandom;
Quasi3DRandom - генерирует Vector3, аналогичен Quasi2DRandom.
