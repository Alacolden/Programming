namespace pract4;

public class Circle
{
    public double CenterX { get; set; }
    public double CenterY { get; set; }
    private double _radius;

    public double Radius
    {
        get => _radius;
        set
        {
            if (value < 0)
                throw new ArgumentException("радиус не может быть отрицательным");
            
            _radius = value;
        }
    }

    public Circle(double centerX, double centerY, double radius)
    {
        CenterX = centerX;
        CenterY = centerY;
        Radius = radius;
    }

    public double Perimeter => 2 * Math.PI * Radius;
    
    public double Area => Math.PI * Radius * Radius;
    
    public override string ToString() => $"Центр: ({CenterX}, {CenterY}); Радиус: {Radius:F3}.";
}