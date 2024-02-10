using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.LinkLabel;

namespace VectorGrafEditer_Kursovaya
{
     class Elipce
    {
        public Elipce()
        {
            foreach(int i in GetElipce())
            {
                elipce[i] = -1;
            }
            for (int i = 0; i < elipceColors.Length; i++)
            {
                SetColor(i, Color.Black);
                SetWidth(i, elipceWidth[i]);
            }
        }

        public Color[] elipceColors = new Color[100];

        public Color GetColor(int i)
        {
            return elipceColors[i];
        }

        public void SetColor(int i, Color value)
        {
            elipceColors[i] = value;
        }

        public int[] elipceWidth = new int[100];

        public int GetWidth(int i)
        {
            return elipceWidth[i];
        }

        public void SetWidth(int i, int value)
        {
            elipceWidth[i] = value;
        }


        int[] elipce = new int[100];
        
        public int[] GetElipce () 
        {
            return elipce;
        }

        public void SetIndex(int index)
        {
            elipce[index] = index;
        }
        public void ClearIndex()
        {
            for (int i = 0; i < elipce.Length; i++)
            {
                elipce[i] = -1;
            }
        }
        public bool EqualIndex(int i)
        {
            if (elipce[i] == i) return true;
            else return false;
        }
    }
}
