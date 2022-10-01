const int nSteps = 40;
var lines = File.ReadLines("./input.txt");

if (lines == null)
    throw new Exception("yikees");

var starting = lines.First();

var code = new Dictionary<string, string>(
    lines.Where(line => !string.IsNullOrEmpty(line))
        .Where(line => line.Contains("->"))
        .Select(line => line.Split(" -> "))
        .Select(split => new KeyValuePair<string, string>(split[0], split[1]))
);

string nextList(string currentList) =>
    currentList.ToCharArray().Aggregate(
        ("", default(char)),
        (current, next) =>
        current switch
        {
            ("", default(char)) => (next.ToString(), next),
            _ => (current.Item1 + code[$"{current.Item2}{next}"] + next.ToString(), next)
        }).Item1;

string finishedPolymer(int step, string polymer) =>
    step switch
    {
        nSteps => polymer,
        _ => finishedPolymer(step + 1, nextList(polymer))
    };

int solution(string polymer)
{
    var components = polymer.ToCharArray()
        .GroupBy(c => c)
        .OrderByDescending(gr => gr.Count());
    return components.First().Count() - components.Last().Count();
}

Console.WriteLine(finishedPolymer(0, starting));
Console.WriteLine(solution(finishedPolymer(0, starting)));