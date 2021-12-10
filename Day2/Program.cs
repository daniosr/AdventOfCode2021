// Reads the data from the provided file
string raw = "";

try
{
    raw = System.IO.File.ReadAllText("..\\..\\..\\input.txt");
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
    return;
}


// splits the array into lines
string[] rawArray = raw.Split("\n");

int horizontal = 0;
int depth = 0;

foreach (string command in rawArray)
{
    switch(command)
    {
        case string com when com.Contains("forward"):
            horizontal += int.Parse(com.Split(" ")[1]);
            break;
        case string com when com.Contains("down"):
            depth += int.Parse(com.Split(" ")[1]);
            break;
        case string com when com.Contains("up"):
            depth -= int.Parse(com.Split(" ")[1]);
            break;
    }
}

Console.WriteLine(horizontal*depth);