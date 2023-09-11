using System;
using System.Collections.Generic;

namespace AdventOfCode
{
    /// <summary>
    /// https://adventofcode.com/2022/day/13
    /// </summary>
    public class Day13
    {
        public class DistressSignal
        {
            private readonly List<Packet> packets = new List<Packet>();

            public DistressSignal(string input)
            {
                foreach (var pair in input.Split(string.Format("{0}{0}", Environment.NewLine)))
                {
                    var packageinputs = pair.Split(Environment.NewLine);
                    packets.Add(new Packet(packageinputs[0]));
                    packets.Add(new Packet(packageinputs[1]));
                }
            }

            public int FindRightOrderIndicesSum()
            {
                var sum = 0;
                for (int i = 0; i < packets.Count; i+=2)
                {
                    var p1 = packets[i];
                    var p2 = packets[i+1];
                    if (p1.CompareTo(p2) < 0)
                        sum += i / 2 + 1;
                }

                return sum;
            }

            public int FindDecoderKey()
            {
                var dividerPackage1 = new Packet("[[2]]");
                var dividerPackage2 = new Packet("[[6]]");
                packets.Add(dividerPackage1);
                packets.Add(dividerPackage2);

                var array = packets.ToArray();
                Common.Common.Quicksort.Sort(array);

                var key = 1;
                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i] == dividerPackage1)
                        key *= (i + 1);

                    if (array[i] == dividerPackage2)
                        key *= (i + 1);
                }

                return key;
            }

            public class Packet : IComparable
            {
                public Value value;

                public Packet(string input)
                {
                    var inputPos = 0;
                    value = new Value(input, ref inputPos);
                }

                public override string ToString()
                {
                    return $"Packet: {value}";
                }

                public bool ValidateOrder(Packet otherPacket)
                {
                    return value.ValidateOrder(otherPacket.value) ?? false;
                }

                public int CompareTo(object obj)
                {
                    if (obj == null) return 1;

                    var otherPacket = obj as Packet;
                    return value.ValidateOrder(otherPacket.value) ?? false ? -1 : 1;
                }

                public class Value
                {
                    public Vtype Type;
                    public int IntegerValue;
                    public List<Value> ListValues;

                    public Value(string input, ref int inputPos)
                    {
                        // Recursive constructor!
                        Type = input[inputPos] == '[' || input[inputPos] == ']' ? Vtype.list : Vtype.integer;

                        if (Type == Vtype.integer)
                        {
                            var indexEnd = input.IndexOf(']', inputPos);
                            var indexComma = input.IndexOf(',', inputPos);
                            indexEnd = indexComma != -1 && indexComma < indexEnd ? indexComma : indexEnd;
                            IntegerValue = int.Parse(input[inputPos..indexEnd]);
                            inputPos = indexEnd - 1;
                        }
                        else
                        {
                            ListValues = new List<Value>();
                            while (inputPos+1 < input.Length)
                            {
                                switch (input[++inputPos])
                                {
                                    case ']':
                                        return;
                                    case ',':
                                        continue;
                                    default:
                                        ListValues.Add(new Value(input, ref inputPos));
                                        break;
                                }
                            }
                        }
                    }

                    public Value(int integerValue, bool isList)
                    {
                        if (isList)
                        {
                            Type = Vtype.list;
                            ListValues = new List<Value>() { new Value(integerValue, isList: false)};
                        }
                        else
                        {
                            Type = Vtype.integer;
                            IntegerValue = integerValue;
                        }
                    }

                    public bool? ValidateOrder(Value otherValue)
                    {
                        // Check types and create list-wrapper as needed
                        if (Type != otherValue.Type)
                        {
                            if (Type == Vtype.integer)
                            {
                                var list = new Value(IntegerValue, isList: true);
                                return list.ValidateOrder(otherValue);
                            }
                            else
                            {
                                var list = new Value(otherValue.IntegerValue, isList: true);
                                return ValidateOrder(list);
                            }
                        }

                        // Both Integers
                        if (Type == Vtype.integer && otherValue.Type == Vtype.integer)
                        {
                            if (IntegerValue < otherValue.IntegerValue)
                                return true;
                            else if (IntegerValue > otherValue.IntegerValue)
                                return false;
                            else
                                return null;
                        }

                        // Both Lists
                        for (int i = 0; i < ListValues.Count; i++)
                        {
                            // Other list is empty -> order is not correct
                            if (otherValue.ListValues.Count <= i)
                                return false;

                            var correctOrder = ListValues[i].ValidateOrder(otherValue.ListValues[i]);

                            if (correctOrder == null)
                                continue;

                            return correctOrder;
                        }

                        // First list exhausted, order is correct if other list still has values
                        if (ListValues.Count < otherValue.ListValues.Count)
                            return true;

                        // Still not possible to determine correct order
                        return null;
                    }

                    public override string ToString()
                    {
                        return Type == Vtype.integer ? $"{IntegerValue}" : $" [{string.Join(", ", ListValues)}] ";
                    }
                }

                public enum Vtype
                {
                    integer,
                    list
                }
            }
        }

        // == == == == == Puzzle 1 == == == == ==
        public static string Puzzle1(string input)
        {
            var ds = new DistressSignal(input);
            return ds.FindRightOrderIndicesSum().ToString();
        }

        // == == == == == Puzzle 2 == == == == ==
        public static string Puzzle2(string input)
        {
            var ds = new DistressSignal(input);
            return ds.FindDecoderKey().ToString();
        }
    }
}
