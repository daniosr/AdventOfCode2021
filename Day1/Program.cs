// Get the data from the internet
System.Net.WebClient wc = new System.Net.WebClient();

// Sets the cookie information so correct data can be fetched
wc.Headers.Add(System.Net.HttpRequestHeader.Cookie, "session=53616c7465645f5f4b727ee5d0bc8441103fd0afc7551804037f39e2f6709bf183efb0c3cb68f25c5cca3edb319cb64b");
string raw = wc.DownloadString("https://adventofcode.com/2021/day/1/input");

// splits the array into lines
string[] rawArray = raw.Split("\n");

int count = 0;
int previous = int.MaxValue;
int current = 0;

bool success;

// Goes through each lines and calculates the count
foreach (string line in rawArray)
{
    success = Int32.TryParse(line, out current);

    if(success && current > previous)
    {
        count++;
    } 
    
    if(success)
    {
        previous = current;
    }
}

Console.WriteLine(count);