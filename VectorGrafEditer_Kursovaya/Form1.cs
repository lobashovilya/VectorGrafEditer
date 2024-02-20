using System.Drawing;
using System.Drawing.Imaging;
using System.Reflection;
using System.Windows.Forms;


namespace VectorGrafEditer_Kursovaya
{
    public partial class Form1 : Form
    {
        String selectedTool;
        int objCount = 0;
        Point[][] p;
        bool mousedown;
        int catch_line_index;
        bool point_focus;
        int catch_point_index_X;
        int catch_point_index_Y;
        int startX = 0;
        int startY = 0;
        int endX = 0;
        int endY = 0;
        String mode;
        Graphics g;
        Figure elipce = new Figure();
        Figure line = new Figure();
        Figure rectangle = new Figure();
        public Form1()
        {
            g = this.CreateGraphics();
            selectedTool = "Line";
            mode = "Рисование";
            point_focus = false;
            mousedown = false;
            catch_line_index = -1;
            catch_point_index_X = -1;
            catch_point_index_Y = -1;
            InitializeComponent();
            p = new Point[100][];
            for (int i = 0; i < 100; i++)
            {
                p[i] = new Point[2];
            }
        }
        /// <summary>
        /// Метод (обработчик) события нажатия кнопки мыши
        /// </summary>
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            mousedown = true;
            if (mode == "Рисование")
            {
                p[objCount][0].X = e.X;
                p[objCount][0].Y = e.Y;
                startX = e.X;
                startY = e.Y;
            }
            if (mode == "Редактирование")
            {
                p[catch_line_index][catch_point_index_X].X = e.X;
                p[catch_line_index][catch_point_index_Y].Y = e.Y;
            }
        }
        /// <summary>
        /// Метод (обработчик) события отпускания кнопки мыши
        /// </summary>
        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            mousedown = false;
            if (mode == "Рисование")
            {
                p[objCount][1].X = e.X;
                p[objCount][1].Y = e.Y;
                endX = e.X;
                endY = e.Y;
                if (selectedTool == "Line")
                {
                    line.SetIndex(objCount);
                }
                if (selectedTool == "Elipce")
                {
                    elipce.SetIndex(objCount);
                }
                if (selectedTool == "Rectangle")
                {
                    rectangle.SetIndex(objCount);
                }
                objCount++;
            }
            if (mode == "Редактирование")
            {
                p[catch_line_index][catch_point_index_X].X = e.X;
                p[catch_line_index][catch_point_index_Y].Y = e.Y;
            }
            pictureBox1.Invalidate();
            mode = "Рисование";
        }
        /// <summary>
        /// Метод (обработчик) события движения кнопки мыши
        /// </summary>
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mousedown)
            {
                if (mode == "Рисование")
                {
                    p[objCount][1].X = e.X;
                    p[objCount][1].Y = e.Y;
                }
                if (mode == "Редактирование")
                {
                    p[catch_line_index][catch_point_index_X].X = e.X;
                    p[catch_line_index][catch_point_index_Y].Y = e.Y;
                }
            }
            else
            {
                mode = "Рисование";
                point_focus = false;
                catch_line_index = -1;
                catch_point_index_X = -1;
                catch_point_index_Y = -1;
                editObject(sender, e);
            }
            pictureBox1.Invalidate();
        }
        /// <summary>
        /// Метод (обработчик) события редактирования фигуры.
        /// В нем реализован расчет координат при редактировании.
        /// </summary>
        private void editObject(object sender, MouseEventArgs e)
        {
            for (int i = 0; i < objCount; i++)
            {
                if (selectedTool == "Line" && line.EqualIndex(i)) // Линия
                {
                    if (Math.Abs(p[i][0].X - e.X) < 5 && Math.Abs(p[i][0].Y - e.Y) < 5)
                    {
                        startX = p[i][0].X;
                        startY = p[i][0].Y;
                        endX = p[i][1].X;
                        endY = p[i][1].Y;
                        point_focus = true;
                        catch_line_index = i;
                        catch_point_index_X = 0;
                        catch_point_index_Y = 0;
                        mode = "Редактирование";
                    }
                    if (Math.Abs(p[i][1].X - e.X) < 5 && Math.Abs(p[i][1].Y - e.Y) < 5)
                    {
                        startX = p[i][0].X;
                        startY = p[i][0].Y;
                        endX = p[i][1].X;
                        endY = p[i][1].Y;
                        point_focus = true;
                        catch_line_index = i;
                        catch_point_index_X = 1;
                        catch_point_index_Y = 1;
                        mode = "Редактирование";
                    }
                }
                if (selectedTool == "Elipce" && elipce.EqualIndex(i)) // Элипс
                {
                    if (Math.Abs(p[i][0].X - e.X) < 5 && Math.Abs(p[i][0].Y - e.Y) < 5)
                    {
                        startX = p[i][0].X;
                        startY = p[i][0].Y;
                        endX = p[i][1].X;
                        endY = p[i][1].Y;
                        point_focus = true;
                        catch_line_index = i;
                        catch_point_index_X = 0;
                        catch_point_index_Y = 0;
                        mode = "Редактирование";
                    }
                    if (Math.Abs(p[i][1].X - e.X) < 5 && Math.Abs(p[i][1].Y - e.Y) < 5)
                    {
                        startX = p[i][0].X;
                        startY = p[i][0].Y;
                        endX = p[i][1].X;
                        endY = p[i][1].Y;
                        point_focus = true;
                        catch_line_index = i;
                        catch_point_index_X = 1;
                        catch_point_index_Y = 1;
                        mode = "Редактирование";
                    }
                    if (Math.Abs(p[i][0].X - e.X) < 5 && Math.Abs(p[i][1].Y - e.Y) < 5)
                    {
                        startX = p[i][0].X;
                        startY = p[i][0].Y;
                        endX = p[i][1].X;
                        endY = p[i][1].Y;
                        catch_line_index = i;
                        catch_point_index_X = 0;
                        catch_point_index_Y = 1;
                        point_focus = true;
                        mode = "Редактирование";
                    }
                    if (Math.Abs(p[i][1].X - e.X) < 5 && Math.Abs(p[i][0].Y - e.Y) < 5)
                    {
                        startX = p[i][0].X;
                        startY = p[i][0].Y;
                        endX = p[i][1].X;
                        endY = p[i][1].Y;
                        catch_line_index = i;
                        catch_point_index_X = 1;
                        catch_point_index_Y = 0;
                        point_focus = true;
                        mode = "Редактирование";
                    }
                }
                if (selectedTool == "Rectangle" && rectangle.EqualIndex(i)) // Прямоугольник
                {
                    if (Math.Abs(p[i][0].X - e.X) < 5 && Math.Abs(p[i][0].Y - e.Y) < 5)
                    {
                        startX = p[i][0].X;
                        startY = p[i][0].Y;
                        endX = p[i][1].X;
                        endY = p[i][1].Y;
                        point_focus = true;
                        catch_line_index = i;
                        catch_point_index_X = 0;
                        catch_point_index_Y = 0;
                        mode = "Редактирование";
                    }
                    if (Math.Abs(p[i][1].X - e.X) < 5 && Math.Abs(p[i][1].Y - e.Y) < 5)
                    {
                        startX = p[i][0].X;
                        startY = p[i][0].Y;
                        endX = p[i][1].X;
                        endY = p[i][1].Y;
                        point_focus = true;
                        catch_line_index = i;
                        catch_point_index_X = 1;
                        catch_point_index_Y = 1;
                        mode = "Редактирование";
                    }
                    if (Math.Abs(p[i][0].X - e.X) < 5 && Math.Abs(p[i][1].Y - e.Y) < 5)
                    {
                        startX = p[i][0].X;
                        startY = p[i][0].Y;
                        endX = p[i][1].X;
                        endY = p[i][1].Y;
                        catch_line_index = i;
                        catch_point_index_X = 0;
                        catch_point_index_Y = 1;
                        point_focus = true;
                        mode = "Редактирование";
                    }
                    if (Math.Abs(p[i][1].X - e.X) < 5 && Math.Abs(p[i][0].Y - e.Y) < 5)
                    {
                        startX = p[i][0].X;
                        startY = p[i][0].Y;
                        endX = p[i][1].X;
                        endY = p[i][1].Y;
                        catch_line_index = i;
                        catch_point_index_X = 1;
                        catch_point_index_Y = 0;
                        point_focus = true;
                        mode = "Редактирование";
                    }
                }
            }
        }
        /// <summary>
        /// Основной метод рисования объектов на холсте
        /// В нем реализована отрисовка объектов, сохранение положения фигур при изменении типа фигуры,
        /// отрисовка проекции фигуры при редактировании.
        /// </summary>
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;
            
            for (int k = 0; k < p.Length; k++)
            {
                if (line.EqualIndex(k)) // Отрисовка объектов
                {
                    Pen linePen = new Pen(line.GetColor(k), line.GetWidth(k));
                    g.DrawLine(linePen, p[k][0].X, p[k][0].Y, p[k][1].X, p[k][1].Y);
                }
                if (elipce.EqualIndex(k))
                {
                    Pen elipcePen = new Pen(elipce.GetColor(k), elipce.GetWidth(k));
                    g.DrawEllipse(elipcePen, p[k][0].X, p[k][0].Y, p[k][1].X - p[k][0].X, p[k][1].Y - p[k][0].Y);
                }
                if (rectangle.EqualIndex(k))
                {
                    Pen rectanglePen = new Pen(rectangle.GetColor(k), rectangle.GetWidth(k));
                    if (p[k][0].X < p[k][1].X)
                    {
                        if (p[k][0].Y < p[k][1].Y)
                        {
                            g.DrawRectangle(rectanglePen, p[k][0].X, p[k][0].Y, Math.Abs(p[k][1].X - p[k][0].X), Math.Abs(p[k][1].Y - p[k][0].Y));
                        }
                        else
                        {
                            g.DrawRectangle(rectanglePen, p[k][0].X, p[k][1].Y, Math.Abs(p[k][1].X - p[k][0].X), Math.Abs(p[k][1].Y - p[k][0].Y));
                        }
                    }
                    else
                    {
                        if (p[k][0].Y < p[k][1].Y)
                        {
                            g.DrawRectangle(rectanglePen, p[k][1].X, p[k][0].Y, Math.Abs(p[k][1].X - p[k][0].X), Math.Abs(p[k][1].Y - p[k][0].Y));
                        }
                        else
                        {
                            g.DrawRectangle(rectanglePen, p[k][1].X, p[k][1].Y, Math.Abs(p[k][1].X - p[k][0].X), Math.Abs(p[k][1].Y - p[k][0].Y));
                        }
                    }
                }

                if (selectedTool == "Line")
                {
                    if (mousedown)
                    {
                        Pen linePen = new Pen(line.GetColor(objCount), line.GetWidth(objCount));
                        g.DrawLine(linePen, p[objCount][0].X, p[objCount][0].Y, p[objCount][1].X, p[objCount][1].Y);
                    }
                    if (point_focus)
                    {
                        g.DrawRectangle(new Pen(Color.Red), p[catch_line_index][catch_point_index_X].X - 5, p[catch_line_index][catch_point_index_Y].Y - 5, 10, 10);
                    }
                }

                if (selectedTool == "Elipce")
                {
                    Pen dashPen = new Pen(Color.Blue);
                    dashPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
                    if (mousedown)
                    {
                        Pen elipcePen = new Pen(line.GetColor(objCount), line.GetWidth(objCount));
                        g.DrawEllipse(elipcePen, p[objCount][0].X, p[objCount][0].Y, p[objCount][1].X - p[objCount][0].X, p[objCount][1].Y - p[objCount][0].Y);
                    }
                    if (mousedown && point_focus)
                    {
                        if (startX < endX)
                        {
                            if (startY < endY)
                            {
                                g.DrawEllipse(new Pen(Color.Red), startX, startY, Math.Abs(endX - startX), Math.Abs(endY - startY));
                            }
                            else
                            {
                                g.DrawEllipse(new Pen(Color.Red), startX, endY, Math.Abs(endX - startX), Math.Abs(endY - startY));
                            }
                        }
                        else
                        {
                            if (startY < endY)
                            {
                                g.DrawEllipse(new Pen(Color.Red), endX, startY, Math.Abs(endX - startX), Math.Abs(endY - startY));
                            }
                            else
                            {
                                g.DrawEllipse(new Pen(Color.Red), endX, endY, Math.Abs(endX - startX), Math.Abs(endY - startY));
                            }
                        }
                    }
                    if (point_focus)
                    {
                        if (startX < endX)
                        {
                            if (startY < endY)
                            {
                                g.DrawRectangle(dashPen, startX, startY, Math.Abs(endX - startX), Math.Abs(endY - startY));
                            }
                            else
                            {
                                g.DrawRectangle(dashPen, startX, endY, Math.Abs(endX - startX), Math.Abs(endY - startY));
                            }
                        }
                        else
                        {
                            if (startY < endY)
                            {
                                g.DrawRectangle(dashPen, endX, startY, Math.Abs(endX - startX), Math.Abs(endY - startY));
                            }
                            else
                            {
                                g.DrawRectangle(dashPen, endX, endY, Math.Abs(endX - startX), Math.Abs(endY - startY));
                            }
                        }
                    }
                }
                if (selectedTool == "Rectangle")
                {
                    Pen rectanglePen = new Pen(rectangle.GetColor(objCount), rectangle.GetWidth(objCount));
                    if (mousedown)
                    {
                        g.DrawRectangle(rectanglePen, p[objCount][0].X, p[objCount][0].Y, p[objCount][1].X - p[objCount][0].X, p[objCount][1].Y - p[objCount][0].Y);
                    }
                    if (point_focus)
                    {
                        g.DrawRectangle(new Pen(Color.Red), p[catch_line_index][catch_point_index_X].X - 5, p[catch_line_index][catch_point_index_Y].Y - 5, 10, 10);
                    }
                }
            }
        }
        /// <summary>
        /// Метод измения типа фигуры на линию
        /// </summary>
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            selectedTool = "Line";
            toolStripButton1.Checked = true;
            toolStripButton2.Checked = false;
            toolStripButton3.Checked = false;
        }
        /// <summary>
        /// Метод измения типа фигуры на эллипс
        /// </summary>
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            selectedTool = "Elipce";
            toolStripButton1.Checked = false;
            toolStripButton2.Checked = true;
            toolStripButton3.Checked = false;
        }
        /// <summary>
        /// Метод измения типа фигуры на прямоугольник
        /// </summary>
        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            selectedTool = "Rectangle";
            toolStripButton1.Checked = false;
            toolStripButton2.Checked = false;
            toolStripButton3.Checked = true;
        }
        /// <summary>
        /// Метод измения цвета фигуры на черный
        /// </summary>
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (selectedTool == "Line")
                line.SetColor(objCount, Color.Black);
            if (selectedTool == "Elipce")
                elipce.SetColor(objCount, Color.Black);
            if (selectedTool == "Rectangle")
                rectangle.SetColor(objCount, Color.Black);
        }
        /// <summary>
        /// Метод измения цвета фигуры на синий
        /// </summary>
        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (selectedTool == "Line")
                line.SetColor(objCount, Color.Blue);
            if (selectedTool == "Elipce")
                elipce.SetColor(objCount, Color.Blue);
            if (selectedTool == "Rectangle")
                rectangle.SetColor(objCount, Color.Blue);
        }
        /// <summary>
        /// Метод измения цвета фигуры на зеленый
        /// </summary>
        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            if (selectedTool == "Line")
                line.SetColor(objCount, Color.Green);
            if (selectedTool == "Elipce")
                elipce.SetColor(objCount, Color.Green);
            if (selectedTool == "Rectangle")
                rectangle.SetColor(objCount, Color.Green);
        }
        /// <summary>
        /// Метод измения цвета фигуры на желтый
        /// </summary>
        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            if (selectedTool == "Line")
                line.SetColor(objCount, Color.Yellow);
            if (selectedTool == "Elipce")
                elipce.SetColor(objCount, Color.Yellow);
            if (selectedTool == "Rectangle")
                rectangle.SetColor(objCount, Color.Yellow);
        }
        /// <summary>
        /// Метод измения цвета фигуры на красный
        /// </summary>
        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            if (selectedTool == "Line")
                line.SetColor(objCount, Color.Red);
            if (selectedTool == "Elipce")
                elipce.SetColor(objCount, Color.Red);
            if (selectedTool == "Rectangle")
                rectangle.SetColor(objCount, Color.Red);
        }
        /// <summary>
        /// Метод измения цвета фигуры на фиолетовый
        /// </summary>
        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            if (selectedTool == "Line")
                line.SetColor(objCount, Color.Purple);
            if (selectedTool == "Elipce")
                elipce.SetColor(objCount, Color.Purple);
            if (selectedTool == "Rectangle")
                rectangle.SetColor(objCount, Color.Purple);
        }
        /// <summary>
        /// Метод измения цвета фигуры на розовый
        /// </summary>
        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            if (selectedTool == "Line")
                line.SetColor(objCount, Color.Pink);
            if (selectedTool == "Elipce")
                elipce.SetColor(objCount, Color.Pink);
            if (selectedTool == "Rectangle")
                rectangle.SetColor(objCount, Color.Pink);
        }
        /// <summary>
        /// Метод измения ширины линии фигуры на 1 px
        /// </summary>
        private void toolStripMenuItem9_Click(object sender, EventArgs e)
        {
            if (selectedTool == "Line")
                line.SetWidth(objCount, 1);
            if (selectedTool == "Elipce")
                elipce.SetWidth(objCount, 1);
            if (selectedTool == "Rectangle")
                rectangle.SetWidth(objCount, 1);
        }
        /// <summary>
        /// Метод измения ширины линии фигуры на 2 px
        /// </summary>
        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {
            if (selectedTool == "Line")
                line.SetWidth(objCount, 2);
            if (selectedTool == "Elipce")
                elipce.SetWidth(objCount, 2);
            if (selectedTool == "Rectangle")
                rectangle.SetWidth(objCount, 2);
        }
        /// <summary>
        /// Метод измения ширины линии фигуры на 3 px
        /// </summary>
        private void toolStripMenuItem10_Click(object sender, EventArgs e)
        {
            if (selectedTool == "Line")
                line.SetWidth(objCount, 3);
            if (selectedTool == "Elipce")
                elipce.SetWidth(objCount, 3);
            if (selectedTool == "Rectangle")
                rectangle.SetWidth(objCount, 3);
        }
        /// <summary>
        /// Метод измения ширины линии фигуры на 4 px
        /// </summary>
        private void toolStripMenuItem11_Click(object sender, EventArgs e)
        {
            if (selectedTool == "Line")
                line.SetWidth(objCount, 4);
            if (selectedTool == "Elipce")
                elipce.SetWidth(objCount, 4);
            if (selectedTool == "Rectangle")
                rectangle.SetWidth(objCount, 4);
        }
        /// <summary>
        /// Метод измения ширины линии фигуры на 5 px
        /// </summary>
        private void toolStripMenuItem12_Click(object sender, EventArgs e)
        {
            if (selectedTool == "Line")
                line.SetWidth(objCount, 5);
            if (selectedTool == "Elipce")
                elipce.SetWidth(objCount, 5);
            if (selectedTool == "Rectangle")
                rectangle.SetWidth(objCount, 5);
        }
        /// <summary>
        /// Метод измения ширины линии фигуры на 6 px
        /// </summary>
        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < objCount; i++)
            {
                p[i][0] = Point.Empty;
                p[i][1] = Point.Empty;
                line.SetColor(i, Color.Empty);
                line.SetWidth(i, 1);
                line.ClearIndex();
                elipce.SetColor(i, Color.Empty);
                elipce.SetWidth(i, 1);
                elipce.ClearIndex();
                rectangle.SetColor(i, Color.Empty);
                rectangle.SetWidth(i, 1);
                rectangle.ClearIndex();
            }
            pictureBox1.Invalidate();
        }
        /// <summary>
        /// Метод удаления всех изменений
        /// </summary>
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < objCount; i++)
            {
                p[i][0] = Point.Empty;
                p[i][1] = Point.Empty;
                line.SetColor(i, Color.Empty);
                line.SetWidth(i, 1);
                line.ClearIndex();
                elipce.SetColor(i, Color.Empty);
                elipce.SetWidth(i, 1);
                elipce.ClearIndex();
                rectangle.SetColor(i, Color.Empty);
                rectangle.SetWidth(i, 1);
                rectangle.ClearIndex();
            }
            pictureBox1.Invalidate();
        }

        /// <summary>
        /// Метод закрытия приложения
        /// </summary>
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
