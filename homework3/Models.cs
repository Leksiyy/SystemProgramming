namespace homework3;

public class World // singleton
{
    private static World instance = null;

    public static World Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new World();
            }
            return instance;
        }
    }

    static public int[,] array = new int[10, 10];
    private List<Ant> ants = new List<Ant>();

    private World()
    {
        for (int i = 0; i < array.GetLength(0); i++)
        {
            for (int j = 0; j < array.GetLength(1); j++)
            {
                array[i, j] = 0;
            }
        }
    }

    public void AddEntity(Ant ant)
    {
        ants.Add(ant);
        UpdateEntityPosition(ant, isOccupied: true);
    }

    public bool IsCellEmpty(int x, int y)
    {
        if (x >= 0 && x < array.GetLength(1) && y >= 0 && y < array.GetLength(0))
        {
            return array[y, x] == 0;
        }
        return false;
    }

    public void UpdateEntityPosition(Ant ant, bool isOccupied)
    {
        array[ant.Y, ant.X] = isOccupied ? 1 : 0;
    }

    public static void DisplayWorld()
    {
        Console.Clear();
        for (int i = 0; i < array.GetLength(0); i++)
        {
            for (int j = 0; j < array.GetLength(1); j++)
            {
                Console.Write(array[i, j] + " ");
            }
            Console.WriteLine();
        }
    }
}


public class Ant
{
    public int X { get; set; }
    public int Y { get; set; }
    public int Stamina { get; set; }
    public string Role { get; set; }
    public DateTime Age { get; set; }

    public Ant (int y, int x, int stamina, string role)
    {
        X = x;
        Y = y;
        Stamina = stamina;
        Age = DateTime.Now;
        Role = role;
    }

    public async Task Move()
    {
        while (true)
        {
            if (Stamina <= 0)
            {
                return;
            }

            Random rnd = new Random();
            int direction = rnd.Next(0, 4); // 0-1 - horizontal, 2-3 - vertical

            int newX = X;
            int newY = Y;

            if (direction == 0) // right
            {
                newX += rnd.Next(1, 3);
            }
            else if (direction == 1) // left
            {
                newX -= rnd.Next(1, 3);
            }
            else if (direction == 2) // up
            {
                newY -= rnd.Next(1, 3);
            }
            else if (direction == 3) // down
            {
                newY += rnd.Next(1, 3);
            }

            if (World.Instance.IsCellEmpty(newX, newY))
            {
                
                World.Instance.UpdateEntityPosition(this, isOccupied: false);

                X = newX;
                Y = newY;
                
                World.Instance.UpdateEntityPosition(this, isOccupied: true);

                await Task.Delay(100); 
                
                Stamina -= 1;
                await AddStamina();
                
                World.DisplayWorld();
                
            } else await Task.Delay(100); // if no - just skip attempt to move
        }
    }
    
    private async Task AddStamina()
    {
        Random rnd = new Random();
        Thread.Sleep(rnd.Next(300, 401));
        Stamina += 1;
    }
}
