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
                // Parse monkey info
                foreach (var monkeydata in input.Split(string.Format("{0}{0}", Environment.NewLine)))
                {
                    monkeys.Add(new Monkey(monkeydata));
                }

                var limit = limitWorryLevel ? monkeys.Aggregate(1, (x, y) => x * y.TestValue) : 0;

                // Link monkeys
                foreach (var monkey in monkeys)
                {
                    monkey.TestTrueTarget = monkeys[monkey.TestTrueTargetId];
                    monkey.TestFalseTarget = monkeys[monkey.TestFalseTargetId];
                    monkey.worryLevelLimit = limit;
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
                private readonly int Id;
                private readonly Queue<Item> Items = new Queue<Item> ();
                private readonly OperationType Operation;
                private readonly int OperationValue;

                public readonly int TestValue;
                public readonly int TestTrueTargetId;
                public readonly int TestFalseTargetId;
                public Monkey TestTrueTarget;
                public Monkey TestFalseTarget;
                public int ItemsThrown = 0;
                public int worryLevelLimit = 0;

                public Monkey(string input)
                {
                    var lines = input.Split(Environment.NewLine);

                    Id = lines[0][7] - '0';
                    foreach (var num in lines[1][18..].Split(','))
                    {
                        Items.Enqueue(new Item(int.Parse(num)));
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
                    // Increase Worry Level
                    switch (Operation)
                    {
                        case OperationType.Add:
                            item.WorryLevel += OperationValue;
                            break;
                        case OperationType.Multiply:
                            item.WorryLevel *= OperationValue;
                            break;
                        case OperationType.MultiplyOld:
                            item.WorryLevel *= item.WorryLevel;
                            break;
                    }

                    // Worry Level Decreases for Part 1
                    if (worryLevelLimit == 0)
                    {
                        item.WorryLevel /= 3;
                    }
                    // Worry Level can grow beyong long.MaxValue for Part 2, so need to limit it
                    else
                    {
                        item.WorryLevel %= worryLevelLimit;
                    }

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
                        type = OperationType.MultiplyOld;
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

                private enum OperationType
                {
                    Add,
                    Multiply,
                    MultiplyOld
                }

                public override string ToString() => $"ItemsThrown: {ItemsThrown}";
            }

            public class Item
            {
                public long WorryLevel;

                public Item(long worryLevel)
                {
                    WorryLevel = worryLevel;
                }
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
