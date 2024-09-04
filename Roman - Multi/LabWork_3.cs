//Задание 3. Параметры потока
public class LabWork_3 
{
    private string _message = "";
    const string _tmp = "сообщение";
    AutoResetEvent waitHandler = new AutoResetEvent(true); 

    public void MainMethod()
    {
        Thread _thread_1 = new Thread(new ParameterizedThreadStart(Print));
        _thread_1.Name = "Поток первый";

        Thread _thread_2 = new Thread(new ParameterizedThreadStart(Print));
        _thread_2.Name = "Поток второй";

        Thread _thread_3 = new Thread(new ParameterizedThreadStart(Print));
        _thread_3.Name = "Поток третий";

        Thread _thread_4 = new Thread(new ParameterizedThreadStart(Print));
        _thread_4.Name = "Поток четвертый";

        _thread_1.Start(_tmp);
        _thread_2.Start(_tmp);
        _thread_3.Start(_tmp);
        _thread_4.Start(_tmp);
    }

    void Print(object? message)
    {
        waitHandler.WaitOne();

        if (message is string)
        {
            _message += message + "\t";
            Console.WriteLine($"{Thread.CurrentThread.Name}: {_message}");
            Thread.Sleep(200);
        }

        waitHandler.Set();
    }
}
