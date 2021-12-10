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

int lineLength = rawArray[0].Length;

int[] binaryCounts = new int[lineLength];

foreach (string line in rawArray)
{
    for (int i = 0; i < line.Length; i++)
    {
        if(line[i] == '0')
        {
            binaryCounts[i]--;
        } else if(line[i] == '1')
        {
            binaryCounts[i]++;
        }
    }
}

string gamma = "";
string epsilon = "";

foreach(int count in binaryCounts)
{
    if(count > 0)
    {
        gamma += "1";
        epsilon += "0";
    } else if(count < 0)
    {
        gamma += "0";
        epsilon += "1";
    }
}

Console.WriteLine(gamma);
Console.WriteLine(epsilon);

Console.WriteLine(Convert.ToInt32(gamma,2) * Convert.ToInt32(epsilon,2));