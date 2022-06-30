PrisonerProblem.Solve();

public static class PrisonerProblem
{
    private const int Prisoners = 100;

    private const int Iterations = 10000;

    public static void Solve()
    {
        var wins = 0;

        for (var i = 0; i < Iterations; i++)
        {
            var length = Iteration();

            if (length < Prisoners / 2)
            {
                wins++;
            }
        }

        Console.WriteLine($"\nWins: {wins}/{Iterations}");
    }

    private static int Iteration()
    {
        var boxes = new int[Prisoners];

        var random = new Random();

        var numbers = new List<int>(Prisoners);

        for (var i = 0; i < Prisoners; i++)
        {
            numbers.Add(i);
        }

        var box = 0;

        while (numbers.Count > 0)
        {
            var index = random.Next(numbers.Count);

            boxes[box] = numbers[index];

            numbers.RemoveAt(index);

            box++;
        }

        var maxLoopLength = 0;

        for (var i = 0; i < Prisoners; i++)
        {
            box = i;

            var length = 1;

            while (true)
            {
                box = boxes[box];

                if (box == i)
                {
                    break;
                }

                length++;
            }

            if (length > maxLoopLength)
            {
                maxLoopLength = length;
            }
        }

        return maxLoopLength;
    }
}