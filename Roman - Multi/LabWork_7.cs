//Задание 11. Синхронизационный вывод
public class LabWork_7 
{
    static Mutex mutex_1 = new();
    static Mutex mutex_2 = new();

    public void MainMethod()
    {
        while (true) 
        {
            mutex_1.WaitOne();
            Console.WriteLine($"Главный поток");
            Thread.Sleep(200);
            Thread _thread_1 = new(Print);
            _thread_1.Start();
            mutex_1.ReleaseMutex();
        }

    }

    private void Print()
    {
        mutex_2.WaitOne();
        Console.WriteLine($"Дочерний поток");
        Thread.Sleep(200);
        mutex_2.ReleaseMutex();
    }
}
