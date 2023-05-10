using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;

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

            public MonkeyInTheMiddle(string input)
            {
                // Parse monkey info
                foreach (var monkeydata in input.Split(string.Format("{0}{0}", Environment.NewLine)))
                {
                    monkeys.Add(new Monkey(monkeydata));
                }

                // Link monkeys
                foreach (var monkey in monkeys)
                {
                    monkey.TestTrueTarget = monkeys[monkey.TestTrueTargetId];
                    monkey.TestFalseTarget = monkeys[monkey.TestFalseTargetId];
                }
            }

            public int FineMonkeyBusinessLevel(int numRounds)
            {
                for (int i = 0; i < numRounds; i++)
                {
                    foreach (var monkey in monkeys)
                    {
                        monkey.ThrowAllItems();
                    }
                }

                return monkeys.OrderByDescending(m => m.ItemsThrown).Take(2).Aggregate(1, (x,y) => x * y.ItemsThrown);
            }

            public class Monkey
            {
                private int Id;
                private Queue<Item> Items = new Queue<Item> ();
                private OperationType Operation;
                private int OperationValue;
                private int TestValue;

                public int TestTrueTargetId;
                public int TestFalseTargetId;
                public Monkey TestTrueTarget;
                public Monkey TestFalseTarget;
                public int ItemsThrown = 0;
                
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

                    // Decrease Worry Level
                    item.WorryLevel /= 3;

                    // Test and throw item
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
                    // Check if operation is multiply old
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
            }

            public class Item
            {
                public int WorryLevel;

                public Item(int worryLevel)
                {
                    WorryLevel = worryLevel;
                }
            }

            
        }

        // == == == == == Puzzle 1 == == == == ==
        public static string Puzzle1(string input)
        {
            var mitm = new MonkeyInTheMiddle(input);
            return mitm.FineMonkeyBusinessLevel(20).ToString();
        }

        // == == == == == Puzzle 2 == == == == ==
        public static string Puzzle2(string input)
        {
            return "Puzzle2";
        }
    }
}
