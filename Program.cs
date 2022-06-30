PrisonerProblem.Solve();

public static class PrisonerProblem
{
    private const int Prisoners = 100;

    private const int Iterations = 10_000;

    private static readonly Random Random = new();

    private static int[] _boxes;

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
        InitialiseBoxes();

        return SearchBoxes();
    }

    private static void InitialiseBoxes()
    {
        _boxes = new int[Prisoners];

        var numbers = new List<int>(Prisoners);

        for (var i = 0; i < Prisoners; i++)
        {
            numbers.Add(i);
        }

        var box = 0;

        while (numbers.Count > 0)
        {
            var index = Random.Next(numbers.Count);

            _boxes[box] = numbers[index];

            numbers.RemoveAt(index);

            box++;
        }
    }

    private static int SearchBoxes()
    {
        var maxLoopLength = 0;

        for (var i = 0; i < Prisoners; i++)
        {
            var box = i;

            var length = 1;

            while (true)
            {
                box = _boxes[box];

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