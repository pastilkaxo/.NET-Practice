using Шарпы15;
class Programm
{
    static void Main()
    {
        TPLTask.CalculateTasks();
        TPLAwaitAndGroupTask.CalcThree();
        TPLParallel.ParallelForAndForEach();
        TPLParallel.ParallelForEach();
        TPLParallel.ParallelFewTasks();
        BlockingCollection.RefreshShop();
        AsyncAwait.NewPrint();
    }
}