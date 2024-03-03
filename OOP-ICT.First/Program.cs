List<int> values = new List<int>();
values.Add(1);
values.Add(2);
values.Add(3);
values.Add(4);
values.Add(5);
values.Add(6);
values.Add(7);
values.Add(8);
values.Add(9);
values.Add(10);
values.Add(11);
values.Add(12);
values.Add(13);

for (int ind = 0; ind < values.Count;ind++)
{
    switch (values[ind])
    {
        case 11:
            values[ind] = 10;
            break;
        case 12:
            values[ind] = 10;
            break;
        case 13:
            values[ind] = 10;
            break;
        case 14:
            values[ind] = 11;
            break;
    }
}

Console.WriteLine(values);