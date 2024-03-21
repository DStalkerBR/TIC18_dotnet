using ThreadEx;

Worker worker1 = new Worker();
Worker worker2 = new Worker();

Thread thread1 = new Thread(worker1.Work);
Thread thread2 = new Thread(worker2.Work);

thread1.Start();
thread2.Start();

thread1.Join();
thread2.Join();

Console.WriteLine("Programa principal finalizado");
