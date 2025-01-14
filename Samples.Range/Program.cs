int[] array = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
Console.WriteLine(string.Join(',', array));

var startIndex = new Index(1);
var endIndex = new Index(1, true);

Range range = new Range(startIndex, endIndex);

Span<int> span = array.AsSpan(range);

Console.WriteLine(string.Join(',', span.ToArray()));

Span<int> span1 = array.AsSpan(..3);

Console.WriteLine(string.Join(',', span1.ToArray()));

Span<int> span2 = array.AsSpan(3..);

Console.WriteLine(string.Join(',', span2.ToArray()));

Span<int> span3 = array.AsSpan(3..5);

Console.WriteLine(string.Join(',', span2.ToArray()));