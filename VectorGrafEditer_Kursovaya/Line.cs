using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace VectorGrafEditer_Kursovaya
{
     class Line
    {
            public Line() 
            {

                foreach (int i in GetLines())
                {
                    lines[i] = -1;
                }
                for (int i = 0; i < linesColors.Length; i++)
                {
                     SetColor(i, Color.Black);
                     SetWidth(i, linesWidth[i]);
                }
            }
            
            public Color[] linesColors = new Color[100];
            
            public Color GetColor (int i)
            {
                return linesColors[i];
            }

            public void SetColor (int i, Color value)
            {
                linesColors[i] = value;
            }

            public int[] linesWidth = new int[100];

            public int GetWidth(int i)
            {
                return linesWidth[i];
            }

            public void SetWidth(int i, int value)
            {
                linesWidth[i] = value;
            }

            int[] lines = new int[100];

            public int[] GetLines ()
            {
                return lines;
            }
            
            public void SetIndex (int index)
            {
                lines[index] = index;
            }
            public void ClearIndex()
            {
                for (int i = 0;i < lines.Length;i++)
                {
                    lines[i] = -1;
                }
            }
            public bool EqualIndex(int i)
            {
                if (lines[i] == i) return true;
                else return false;
            }
    }
}
