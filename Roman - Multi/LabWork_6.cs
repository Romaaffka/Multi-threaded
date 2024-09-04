//Задание 24. Производственная линия//
public class LabWork_6
{
    int _currentStep = 0;

    static Semaphore semaphore = new Semaphore(1, 1);
    Thread _productionLine;

    public void MainMethod()
    {
        while (true)
        {
            semaphore.WaitOne();

            if (_currentStep == 0)
            {
                _productionLine = new Thread(Step_1);
            }
            else if (_currentStep == 1) 
            {
                _productionLine = new Thread(Step_2);
            }
            else if (_currentStep == 2)
            {
                _productionLine = new Thread(Step_3);
            }
            else if (_currentStep == 3)
            {
                _productionLine = new Thread(Step_4);
            }
            else if (_currentStep == 4)
            {
                _productionLine = new Thread(EndStep);
            }

            _productionLine.Start();
            _currentStep++;
        }
    }

    void EndStep()
    {
        Thread.Sleep(1500);
        _currentStep = 0;
        semaphore.Release();
        Console.WriteLine("Винтик создан\n");
    }

    void Step_1()
    {
        Thread.Sleep(1000);
        semaphore.Release();
        Console.WriteLine("Деталь A создана");
    }

    void Step_2()
    {
        Thread.Sleep(2000);
        semaphore.Release();
        Console.WriteLine("Деталь B создана");
    }

    void Step_3()
    {
        Thread.Sleep(3000);
        semaphore.Release();
        Console.WriteLine("Деталь C создана");
    }

    void Step_4()
    {
        Thread.Sleep(500);
        semaphore.Release();
        Console.WriteLine("Модуль создан");
    }
}
