
using System.Text;

//API endpoint to invoke (GET method)
string apiEndpoint = "https://example.com/sample";

// Set the duration to run the program in minutes
int durationInMinutes = 5;
TimeSpan duration = TimeSpan.FromMinutes(durationInMinutes);

// Create a timer that will signal when the specified duration elapses
Timer timer = new Timer(TimerCallback, null, duration, TimeSpan.FromMilliseconds(-1));

int iteration = 1;
while (true)
{
    Invoke();
    Console.WriteLine("Sent the request# {0}", iteration);

    //sleep for 1 second
    //Thread.Sleep(500);

    iteration++;
}

void TimerCallback(object state)
{
    Console.WriteLine("Program has completed running for {0} minutes.", durationInMinutes);

    // Exit the program gracefully
    Environment.Exit(0);
}

void Invoke()
{
    HttpClient httpClient = new HttpClient();
    var requestMessage = new HttpRequestMessage
    {
        Method = HttpMethod.Get,
        RequestUri = new Uri(apiEndpoint)
    };

    var response = httpClient.SendAsync(requestMessage);
}
