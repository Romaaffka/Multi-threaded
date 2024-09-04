//Задание 4. Принудительное завершение потока
public class LabWork_4 
{
    CancellationTokenSource tokenSource = new();

    public void MainMethod()
    {
        Thread _thread_1 = new Thread(Print);

        _thread_1.Start();
        Thread.Sleep(2000);
        tokenSource.Cancel();
    }

    void Print()
    {        
        for (int i = 0; i < 20 && !tokenSource.Token.IsCancellationRequested; i++)
        {
            Console.WriteLine("Hello");
            Thread.Sleep(200);
        }
    }
}
