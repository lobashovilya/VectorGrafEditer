using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VectorGrafEditer_Kursovaya
{
    class Rectangle
    {
        public Rectangle()
        {
            foreach (int i in GetRectangle())
            {
                rectangle[i] = -1;
            }
            for (int i = 0; i < rectangleColors.Length; i++)
            {
                SetColor(i, Color.Black);
                SetWidth(i, rectangleWidth[i]);
            }
        }

        public Color[] rectangleColors = new Color[100];
            
            public Color GetColor(int i)
        {
            return rectangleColors[i];
        }

        public void SetColor(int i, Color value)
        {
            rectangleColors[i] = value;
        }

        public int[] rectangleWidth = new int[100];

        public int GetWidth(int i)
        {
            return rectangleWidth[i];
        }

        public void SetWidth(int i, int value)
        {
            rectangleWidth[i] = value;
        }

        int[] rectangle = new int[100];

        public int[] GetRectangle()
        {
            return rectangle;
        }

        public void SetIndex(int index)
        {
            rectangle[index] = index;
        }
        public void ClearIndex()
        {
            for (int i = 0; i < rectangle.Length; i++)
            {
                rectangle[i] = -1;
            }
        }
        public bool EqualIndex(int i)
        {
            if (rectangle[i] == i) return true;
            else return false;
        }
    }
}
