using System;

public class Rectangle
{
    public double X { get; set; }
    public double Y { get; set; }
    public double Width { get; set; }
    public double Height { get; set; }

    public Rectangle(double x, double y, double width, double height)
    {
        if (width <= 0 || height <= 0)
        {
            throw new Exception("Ширина и высота должны быть положительными!");
        }
        
        X = x;
        Y = y;
        Width = width;
        Height = height;
    }

    public double Perimeter
    {
        get { return 2 * (Width + Height); }
    }

    public double Area
    {
        get { return Width * Height; }
    }

    public override string ToString()
    {
        return $"Прямоугольник: верхний левый угол ({X}, {Y}), ширина = {Width}, высота = {Height}, " +
               $"периметр = {Perimeter}, площадь = {Area}";
    }
}

class Program
{
    static void Main()
    {
        try
        {
            Rectangle rect1 = new Rectangle(10, 20, 15, 8);
            Console.WriteLine(rect1.ToString());
            
            Rectangle rect2 = new Rectangle(0, 0, 5, 10);
            Console.WriteLine(rect2.ToString());
            
            Console.WriteLine($"\nПериметр второго прямоугольника: {rect2.Perimeter}");
            Console.WriteLine($"Площадь второго прямоугольника: {rect2.Area}");
            
            rect2.Width = 7;
            Console.WriteLine($"\nПосле изменения ширины: {rect2}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
        }
    }
}