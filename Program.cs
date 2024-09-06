// See https://aka.ms/new-console-template for more information
using Snake;
using System.Xml;

Coord gridDemension = new Coord(50, 20);
Coord snakePosition = new Coord(10, 1);
Random rand = new Random();
Coord apple = new Coord(rand.Next(gridDemension.X-1), rand.Next(gridDemension.Y-1));
int DelayMili = 100;
 Direction movementDirection= Direction.Down;//davame da pochva ot gore nadolu
List<Coord> snakePosHistory= new List<Coord>();
int tailLenght = 1;
int score = 0; 

while (true) //making the snake to move
{
 Console.Clear();
    Console.WriteLine("The Score is: "+ score);
    snakePosition.ApplyingDirections(movementDirection);
    for (int y = 0; y < gridDemension.Y; y++) // printing the grid
    {
        for (int x = 0; x < gridDemension.X; x++)
        {
            var currentCoord = new Coord(x, y);
            if (currentCoord.Equals(snakePosition) || snakePosHistory.Contains(currentCoord))
            {
                Console.Write("■");
            }
            else if (apple.Equals(currentCoord))
            {
                Console.Write("a");
            }
            else if (x == 0 || y == 0 || x == gridDemension.X - 1 || y == gridDemension.Y - 1)// stenite 
            {
                Console.Write("#");
            }
            else { Console.Write(" "); }

        }
        Console.WriteLine();
    }

    if (snakePosition.Equals(apple))
    {
        tailLenght++;
        score++;
        apple = new Coord(rand.Next(1, gridDemension.X - 1), rand.Next(1, gridDemension.Y - 1));
    }
    else if (snakePosition.X==0||snakePosition.Y==0|| snakePosition.X==gridDemension.X-1|| 
        snakePosition.Y==gridDemension.Y-1|| snakePosHistory.Contains(snakePosition))
    {
        score = 0;
        tailLenght = 1;
        snakePosHistory.Clear();
        snakePosition = new Coord(10, 1);
        movementDirection = Direction.Down;
        continue;
    }
    snakePosHistory.Add(new Coord(snakePosition.X, snakePosition.Y));
    //proverqvame dali tail a ne e mn dulug
    if (snakePosHistory.Count>tailLenght)
    {
        snakePosHistory.RemoveAt(0);
    }

    DateTime time = DateTime.Now;//pravim go 
    while ((DateTime.Now-time).Milliseconds< DelayMili)
    {
        if (Console.KeyAvailable)
        {
           ConsoleKey key = Console.ReadKey().Key;
            switch (key)
            {
                case ConsoleKey.LeftArrow: movementDirection = Direction.Left; break;
                    case ConsoleKey.RightArrow: movementDirection = Direction.Right; break;
                    case ConsoleKey.UpArrow: movementDirection = Direction.Up; break;
                    case ConsoleKey.DownArrow: movementDirection = Direction.Down; break;


            }
        }
    }

}
