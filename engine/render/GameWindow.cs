using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using Game.World;
using Game.Util;
using Game.Datastore;

namespace Game.Renderer
{
  public class GameWindow
  {
    public const int HEX_SIZE = 40;

    public Window MainWindow { get; private set; }

    internal World.World World { get; private set; }

    private Canvas Canvas { get; set; }

    private List<UIElement> hexes = new();

    private static PointCollection HexagonPointCollection()
    {
      PointCollection collection = new();
      for (int i = 0; i <= 5; i++)
      {
        collection.Add(HexCorner(HEX_SIZE, i));
      }

      return collection;
    }

    private static Point HexCorner(double size, int index)
    {
      var angleInDegrees = 60 * index;
      var angleInRadians = Math.PI / 180 * angleInDegrees;
      return new Point(
        size * Math.Cos(angleInRadians),
        size * Math.Sin(angleInRadians)
      );
    }

    private Polygon GetHexagon(IReadonlyEntity? entity = null)
    {
      var poly = new Polygon
      {
        Stroke = Brushes.Black,
        Fill = Brushes.LightSeaGreen,
        StrokeThickness = 2,
        HorizontalAlignment = HorizontalAlignment.Left,
        VerticalAlignment = VerticalAlignment.Center,
        Points = HexagonPointCollection()
      };

      if (entity != null)
      {
        poly.Fill = Brushes.Red;
      }

      return poly;
    }

    private void ShowCoords(HexCoords hx, double x, double y)
    {
      TextBlock txt = new()
      {
        FontSize = 10,
        Text = hx.ToString()
      };

      Canvas.SetLeft(txt, x - HEX_SIZE / 2);
      Canvas.SetTop(txt, y - HEX_SIZE / 2);

      hexes.Add(txt);
      Canvas.Children.Add(txt);
    }

    private void RenderMap()
    {
      int MaxQ = 0;
      int MaxR = 0;
      int xOffset = 300;
      int yOffset = 300;

      var entities = World.GetAllMapEntities();

      foreach (var e in entities)
      {
        var coords = e!.GetComponent<Position>()!.Coords;

        if (MaxQ < Math.Abs(coords.Q))
          MaxQ = Math.Abs(coords.Q);

        if (MaxR < Math.Abs(coords.R))
          MaxR = Math.Abs(coords.R);
      }

      MaxQ = Math.Abs(MaxQ) + 1;
      MaxR = Math.Abs(MaxR) + 1;

      // terrain
      for (int q = -MaxQ; q <= MaxQ; q++)
      {
        for (int r = -MaxR; r <= MaxR; r++)
        {
          var hx = new HexCoords(q, r);
          if (hx.S > MaxQ || hx.S < -MaxQ)
          {
            //Console.WriteLine($"Skipped {hx}");
          }
          else
          {
            //Console.WriteLine(hx);
            var hex = GetHexagon();

            var x = hx.ToCartesian(HEX_SIZE)[0] + xOffset;
            var y = hx.ToCartesian(HEX_SIZE)[1] + yOffset;

            Canvas.SetLeft(hex, x);
            Canvas.SetTop(hex, y);

            hexes.Add(hex);
            Canvas.Children.Add(hex);
            ShowCoords(hx, x, y);
          }
        }
      }

      foreach (var entity in entities)
      {
        var position = entity.GetComponent<Position>();
        var hex = GetHexagon(entity);

        var hx = position!.Coords;
        var x = hx.ToCartesian(HEX_SIZE)[0] + xOffset;
        var y = hx.ToCartesian(HEX_SIZE)[1] + yOffset;

        Canvas.SetLeft(hex, x);
        Canvas.SetTop(hex, y);
        hexes.Add(hex);
        Canvas.Children.Add(hex);
      }
    }

    private void CleanCanvas()
    {
      foreach (var uie in hexes)
      {
        Canvas.Children.Remove(uie);
      }

      hexes.RemoveAll(value => true);
    }

    private void OnRendering(object? sender, EventArgs e)
    {
      CleanCanvas();
      RenderMap();
    }

    internal GameWindow(World.World world)
    {
      // Create the application's main window
      MainWindow = new Window();
      World = world;

      // Create a canvas sized to fill the window
      Canvas = new Canvas
      {
        Background = Brushes.LightSteelBlue
      };

      CompositionTarget.Rendering += OnRendering;

      MainWindow.Content = Canvas;
      MainWindow.Title = "Game";
      MainWindow.Show();
    }
  }
}