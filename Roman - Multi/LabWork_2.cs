//Задание 2. Ожидание потока
public class LabWork_2 
{
    int x = 1;
    AutoResetEvent waitHandler = new AutoResetEvent(true);

    public void MainMethod()
    {
        Thread _thread_1 = new(Print);
        _thread_1.Name = "Поток первый";

        Thread _thread_2 = new(Print);
        _thread_2.Name = "Поток второй";

        _thread_1.Start();
        _thread_2.Start();
    }

    private void Print()
    {
        waitHandler.WaitOne();

        for (int i = 0; i < 5; i++)
        {
            Console.WriteLine($"{Thread.CurrentThread.Name}, строка: {x}");
            x++;
            Thread.Sleep(100);
        }

        waitHandler.Set();
    }
}
