// Reads the data from the provided file
string raw = "";

try
{
    raw = System.IO.File.ReadAllText("..\\..\\..\\input.txt");
}
catch(Exception ex)
{
    Console.WriteLine(ex.Message);
    return;
}


// splits the array into lines
string[] rawArray = raw.Split("\n");

int NumberOfIncreases(string[] rawArray)
{
    int count = 0;
    int previous = int.MaxValue;
    int current = 0;

    bool success;

    // Goes through each lines and calculates the count
    foreach (string line in rawArray)
    {
        success = Int32.TryParse(line, out current);

        if (success && current > previous)
        {
            count++;
        }

        if (success)
        {
            previous = current;
        }
    }

    return count;
}

int NumberOfIncreasesWindow(string[] rawArray)
{
    int count = 0;
    bool success;
    int[] window = new int[3];

    int previousWindowTotal = Int32.MaxValue;
    int currentWindowTotal = 0;

    for(int i = 0; i < rawArray.Length-2; i++)
    {
        // TODO: Reduce inneficiency from parsing the same value multiple times
        success = Int32.TryParse(rawArray[i], out window[0]) && Int32.TryParse(rawArray[i+1], out window[1]) && Int32.TryParse(rawArray[i+2], out window[2]);
        
        if(success)
        {
            foreach(int value in window)
            {
                currentWindowTotal += value;
            }
            if(currentWindowTotal > previousWindowTotal)
            {
                count++;
            }
            previousWindowTotal = currentWindowTotal;
            currentWindowTotal = 0;
        }
    }

    return count;
}

int count = NumberOfIncreases(rawArray);
int windowCount = NumberOfIncreasesWindow(rawArray);

Console.WriteLine("Number of Increases without window: " + count);
Console.WriteLine("Number of Increases with window: " + windowCount);