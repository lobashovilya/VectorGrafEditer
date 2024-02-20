using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VectorGrafEditer_Kursovaya
{
    class Figure 
    {
        /// <summary>
        /// Метод задает начальные значения в массиве для всех фигрур,
        /// цвет по умолчанию и ширину линии
        /// </summary>
        public Figure()
        {
            foreach (int i in GetFigure())
            {
                figure[i] = -1;
            }
            for (int i = 0; i < figureColors.Length; i++)
            {
                SetColor(i, Color.Black);
                SetWidth(i, figureWidth[i]);
            }
        }

        public Color[] figureColors = new Color[100];

        /// <summary>
        /// Метод возвращает цвет элемента из массива
        /// </summary>
        /// <param name="i"> Номер элемента из массива </param>
        public Color GetColor(int i)
        {
            return figureColors[i];
        }
        /// <summary>
        /// Метод присваивает цвет фигуре из массива
        /// </summary>
        /// <param name="i"> Номер элемента из массива </param>
        /// <param name="value"> Цвет из библиотеки Color </param>
        public void SetColor(int i, Color value) 
        {
            figureColors[i] = value;
        }

        public int[] figureWidth = new int[100];

        /// <summary>
        /// Метод возвращает ширину линии элемента из массива
        /// </summary>
        /// <param name="i">  Номер элемента из массива </param>
        public int GetWidth(int i)
        {
            return figureWidth[i];
        }
        /// <summary>
        /// Метод присваивает ширину линии фигуре из массива
        /// </summary>
        /// <param name="i"> Номер элемента из массива </param>
        /// <param name="value"> Целочисленная ширина линии </param>
        public void SetWidth(int i, int value)
        {
            figureWidth[i] = value;
        }

        int[] figure = new int[100];

        /// <summary>
        /// Метод возвращает массив фигур
        /// </summary>
        public int[] GetFigure()
        {
            return figure;
        }
        /// <summary>
        /// Метод присваивает индекс фигуры массиву
        /// </summary>
        /// <param name="index"> Номер элемента </param>
        public void SetIndex(int index)
        {
            figure[index] = index;
        }
        /// <summary>
        /// Метода очищает массив с фигурами
        /// </summary>
        public void ClearIndex()
        {
            for (int i = 0; i < figure.Length; i++)
            {
                figure[i] = -1;
            }
        }
        /// <summary>
        /// Метод сравнивает индексы фигур
        /// </summary>
        /// <param name="i">Номер элемента</param>
        /// <returns></returns>
        public bool EqualIndex(int i)
        {
            if (figure[i] == i) return true;
            else return false;
        }
    }
}
