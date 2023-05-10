using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode
{
    /// <summary>
    /// https://adventofcode.com/2022/day/11
    /// </summary>
    public class Day11
    {
        public class MonkeyInTheMiddle
        {
            private readonly List<Monkey> monkeys = new List<Monkey>();

            public MonkeyInTheMiddle(string input, bool limitWorryLevel = false)
            {
                var inputSections = input.Split(string.Format("{0}{0}", Environment.NewLine));

                // Calculate worry limit for Part 2
                var worryLimit = 0;
                if (limitWorryLevel)
                {
                    worryLimit = 1;
                    foreach (var sec in inputSections)
                    {
                        // Extract 'divisible by XX' to calculate limit
                        var index = sec.IndexOf("by");
                        worryLimit *= int.Parse(sec[(index + 3)..(index + 5)]);
                    }
                }

                // Parse monkey info
                foreach (var monkeydata in inputSections)
                {
                    monkeys.Add(new Monkey(monkeydata, worryLimit));
                }

                // Link monkeys
                foreach (var monkey in monkeys)
                {
                    monkey.TestTrueTarget = monkeys[monkey.TestTrueTargetId];
                    monkey.TestFalseTarget = monkeys[monkey.TestFalseTargetId];
                }
            }

            public long FindMonkeyBusinessLevel(int numRounds)
            {
                for (int i = 0; i < numRounds; i++)
                {
                    foreach (var monkey in monkeys)
                    {
                        monkey.ThrowAllItems();
                    }
                }

                return monkeys.OrderByDescending(m => m.ItemsThrown).Take(2).Aggregate((long)1, (x,y) => x * y.ItemsThrown);
            }

            public class Monkey
            {
                private readonly Queue<Item> Items = new Queue<Item> ();
                private readonly OperationType Operation;
                private readonly int OperationValue;

                public readonly int TestValue;
                public readonly int TestTrueTargetId;
                public readonly int TestFalseTargetId;
                public Monkey TestTrueTarget;
                public Monkey TestFalseTarget;
                public int ItemsThrown = 0;

                public Monkey(string input, int worryLimit)
                {
                    var lines = input.Split(Environment.NewLine);
                    foreach (var num in lines[1][18..].Split(','))
                    {
                        Items.Enqueue(new Item(int.Parse(num), worryLimit));
                    }
                    ParseOperation(lines[2][23..], out Operation, out OperationValue);
                    TestValue = int.Parse(lines[3][21..]);
                    TestTrueTargetId = lines[4][29] - '0';
                    TestFalseTargetId = lines[5][30] - '0';
                }

                public void CatchItem(Item item)
                {
                    Items.Enqueue(item);
                }

                public void ThrowAllItems()
                {
                    while(Items.Any())
                    {
                        InspectAndThrowItem(Items.Dequeue());
                        ItemsThrown++;
                    }
                }

                private void InspectAndThrowItem(Item item)
                {
                    item.ExecuteOperation(Operation, OperationValue);

                    // Test if divisible to TestValue, and throw to monkey depending on outcome.
                    if (item.WorryLevel % TestValue == 0)
                    {
                        TestTrueTarget.CatchItem(item);
                    }
                    else
                    {
                        TestFalseTarget.CatchItem(item);
                    }
                }

                private void ParseOperation(string input, out OperationType type, out int value)
                {
                    // Check if operation is *old
                    if (input[2] == 'o')
                    {
                        type = OperationType.MultiplySelf;
                        value = 0;
                        return;
                    }

                    // Parse value for +/* opearation
                    type = input[0] switch
                    {
                        '+' => OperationType.Add,
                        '*' => OperationType.Multiply,
                        _ => throw new NotImplementedException($"Unknown operation type {input[0]}"),
                    };
                    value = int.Parse(input[2..]);
                    return;
                }

                public override string ToString() => $"ItemsThrown: {ItemsThrown}";
            }

            public class Item
            {
                public long WorryLevel;
                private readonly int limit;

                public Item(long worryLevel, int limit)
                {
                    WorryLevel = worryLevel;
                    this.limit = limit;
                }

                public void ExecuteOperation(OperationType operation, int value)
                {
                    // Increase worry level
                    switch (operation)
                    {
                        case OperationType.Add:
                            WorryLevel += value;
                            break;
                        case OperationType.Multiply:
                            WorryLevel *= value;
                            break;
                        case OperationType.MultiplySelf:
                            WorryLevel *= WorryLevel;
                            break;
                        default:
                            break;
                    }

                    // Decrease Worry Level (Part 1) or limit it (Part 2)
                    WorryLevel = limit == 0 ? WorryLevel / 3 : WorryLevel % limit;
                }
            }

            public enum OperationType
            {
                Add,
                Multiply,
                MultiplySelf
            }
        }

        // == == == == == Puzzle 1 == == == == ==
        public static string Puzzle1(string input)
        {
            var mitm = new MonkeyInTheMiddle(input);
            return mitm.FindMonkeyBusinessLevel(20).ToString();
        }

        // == == == == == Puzzle 2 == == == == ==
        public static string Puzzle2(string input)
        {
            var mitm = new MonkeyInTheMiddle(input, limitWorryLevel: true);
            return mitm.FindMonkeyBusinessLevel(10000).ToString();
        }
    }
}
